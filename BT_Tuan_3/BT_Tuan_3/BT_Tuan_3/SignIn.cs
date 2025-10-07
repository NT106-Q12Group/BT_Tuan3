using Microsoft.Data.Sqlite;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace BT_Tuan_3
{
    public partial class SignIn : Form
    {
        private const string PH_USERNAME = "Tên đăng nhập";
        private const string PH_PASSWORD = "Mật khẩu";

        public SignIn()
        {
            InitializeComponent();

            // ⚠️ RẤT QUAN TRỌNG: gắn event cho nút Đăng nhập
            this.btn_signin.Click += btn_signin_Click;

            // Enter = đăng nhập
            this.AcceptButton = btn_signin;

            SetPlaceholder(tb_username, PH_USERNAME);
            SetPswPlaceholder(tb_psw, PH_PASSWORD);

            tb_username.KeyPress += (s, e) =>
            {
                if (char.IsWhiteSpace(e.KeyChar)) { e.Handled = true; MessageBox.Show("Tên đăng nhập không có khoảng trắng!"); }
            };
            tb_psw.KeyPress += (s, e) =>
            {
                if (char.IsWhiteSpace(e.KeyChar)) { e.Handled = true; MessageBox.Show("Mật khẩu không có khoảng trắng!"); }
            };

            // Link chuyển sang SignUp
            //this.linklb_signup.LinkClicked += linklb_signup_LinkClicked;
        }

        private void SetPlaceholder(TextBox tb, string text)
        {
            tb.Text = text; tb.ForeColor = Color.Gray;
            tb.Enter += (s, e) => { if (tb.Text == text) { tb.Text = ""; tb.ForeColor = Color.Black; } };
            tb.Leave += (s, e) => { if (string.IsNullOrEmpty(tb.Text)) { tb.Text = text; tb.ForeColor = Color.Gray; } };
        }

        private void SetPswPlaceholder(TextBox tb, string text)
        {
            tb.Text = text; tb.ForeColor = Color.Gray; tb.UseSystemPasswordChar = false;
            tb.Enter += (s, e) =>
            {
                if (tb.Text == text) { tb.UseSystemPasswordChar = true; tb.Text = ""; tb.ForeColor = Color.Black; }
            };
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(tb.Text)) { tb.UseSystemPasswordChar = false; tb.Text = text; tb.ForeColor = Color.Gray; }
            };
        }

        private void linklb_signup_LinkClicked(object s, LinkLabelLinkClickedEventArgs e)
        {
            new SignUp().Show();
            this.Hide();
        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            if (tb_username.Text == PH_USERNAME || string.IsNullOrWhiteSpace(tb_username.Text))
            { MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_username.Focus(); return; }

            if (tb_psw.Text == PH_PASSWORD || string.IsNullOrWhiteSpace(tb_psw.Text))
            { MessageBox.Show("Vui lòng nhập mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); tb_psw.Focus(); return; }

            string usernameInput = tb_username.Text.Trim();
            string passwordInput = tb_psw.Text;

            try
            {
                AppDb.EnsureCreated();
                using var conn = AppDb.GetConn();

                // tìm user không phân biệt hoa/thường
                using var findUser = new SqliteCommand(@"
                    SELECT Id, Username, Email, Phone, Address, Birthdate, Gender, CreatedAt, PasswordHash
                    FROM Users
                    WHERE lower(Username) = lower(@u)
                    LIMIT 1;", conn);
                findUser.Parameters.AddWithValue("@u", usernameInput);

                using var r = findUser.ExecuteReader();
                if (!r.Read())
                {
                    MessageBox.Show("Tài khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string dbHash = r["PasswordHash"]?.ToString() ?? "";
                string inputHash = AppDb.Sha256(passwordInput);

                if (!string.Equals(dbHash, inputHash, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Sai mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // OK → mở Dashboard
                var user = new User
                {
                    Id = r["Id"] is DBNull ? 0 : Convert.ToInt32(r["Id"]),
                    Username = r["Username"] as string ?? "",
                    Email = r["Email"] as string ?? "",
                    Phone = r["Phone"] as string,
                    Address = r["Address"] as string,
                    Birthdate = r["Birthdate"] as string,
                    Gender = r["Gender"] as string,
                    CreatedAt = r["CreatedAt"] as string ?? ""
                };
                r.Close();

                new Dashboard(user).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
