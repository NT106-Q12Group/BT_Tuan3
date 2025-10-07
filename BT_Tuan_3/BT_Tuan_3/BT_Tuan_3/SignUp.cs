using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Security.Cryptography;
using System.IO;

namespace BT_Tuan_3
{
    public partial class SignUp : Form
    {
        private const string PH_EMAIL = "Email";
        private const string PH_USERNAME = "Tên đăng nhập";
        private const string PH_PHONE = "Số điện thoại";
        private const string PH_PASSWORD = "Mật khẩu";
        private const string PH_CONFIRM = "Xác nhận mật khẩu";
        private const string PH_ADDRESS = "Địa chỉ";
        private const string PH_BIRTH = "Ngày sinh";
        private const string PH_GENDER = "— Chọn giới tính —";

        public SignUp()
        {
            InitializeComponent();
            SetPlaceholder(tb_email, PH_EMAIL);
            SetPlaceholder(tb_username, PH_USERNAME);
            SetPlaceholder(tb_phone, PH_PHONE);
            SetPswPlaceholder(tb_psw, PH_PASSWORD);
            SetPswPlaceholder(tb_cf_psw, PH_CONFIRM);
            SetPlaceholder(tb_address, PH_ADDRESS);
            SetPlaceholder(tb_age, PH_BIRTH);

            InitGenderCombo();

            tb_psw.KeyPress += BlockWhitespace_KeyPress;
            tb_cf_psw.KeyPress += BlockWhitespace_KeyPress;

            tb_cf_psw.Leave += (s, e) =>
            {
                if (tb_psw.Text != PH_PASSWORD && tb_cf_psw.Text != PH_CONFIRM)
                {
                    if (!string.Equals(tb_psw.Text, tb_cf_psw.Text, StringComparison.Ordinal))
                    {
                        MessageBox.Show("Mật khẩu xác nhận không khớp!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tb_cf_psw.Focus();
                    }
                }
            };
        }

        private void BlockWhitespace_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Mật khẩu không được chứa khoảng trắng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitGenderCombo()
        {
            cbb_gender.Items.Clear();
            cbb_gender.Items.Add(PH_GENDER);
            cbb_gender.Items.Add("Không tiết lộ");
            cbb_gender.Items.Add("Nam");
            cbb_gender.Items.Add("Nữ");
            cbb_gender.SelectedIndex = 0;
            cbb_gender.ForeColor = Color.Gray;

            cbb_gender.SelectedIndexChanged += (s, e) =>
            {
                cbb_gender.ForeColor = (cbb_gender.SelectedIndex == 0) ? Color.Gray : Color.Black;
            };
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder) { tb.Text = ""; tb.ForeColor = Color.Black; }
            };
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(tb.Text)) { tb.Text = placeholder; tb.ForeColor = Color.Gray; }
            };
        }

        private void SetPswPlaceholder(TextBox tb, string placeholder)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;
            tb.UseSystemPasswordChar = false;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.UseSystemPasswordChar = true; 
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb.UseSystemPasswordChar = false;
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        private void linklb_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new SignIn().Show();
            Hide();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            var error = new ErrorProvider();
            string email = tb_email.Text.Trim();
            string username = tb_username.Text.Trim();
            string password = tb_psw.Text;
            string confirm = tb_cf_psw.Text;

            bool ok = true;

            if (email == PH_EMAIL || !email.Contains('@') || !email.Contains('.'))
            { error.SetError(tb_email, "Email không hợp lệ!"); ok = false; }
            else error.SetError(tb_email, "");

            if (username == PH_USERNAME || username.Length < 4 || username.Length > 20)
            { error.SetError(tb_username, "Tên đăng nhập phải 4–20 ký tự!"); ok = false; }
            else if (!tb_username.Text.All(char.IsLetterOrDigit))
            { error.SetError(tb_username, "Tên đăng nhập chỉ gồm chữ & số!"); ok = false; }
            else error.SetError(tb_username, "");

            if (password == PH_PASSWORD) password = "";
            if (confirm == PH_CONFIRM) confirm = "";

            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else if (!char.IsLetterOrDigit(c)) hasSpecial = true;
            }
            if (password.Length < 8 || !hasUpper || !hasLower || !hasDigit || !hasSpecial)
            { error.SetError(tb_psw, "Mật khẩu ≥8, gồm hoa, thường, số, ký tự đặc biệt!"); ok = false; }
            else error.SetError(tb_psw, "");

            if (!string.Equals(password, confirm, StringComparison.Ordinal))
            { error.SetError(tb_cf_psw, "Mật khẩu xác nhận không khớp!"); ok = false; }
            else error.SetError(tb_cf_psw, "");

            if (cbb_gender.SelectedIndex <= 0)
            {
                error.SetError(cbb_gender, "Vui lòng chọn giới tính!");
                ok = false;
            }
            else error.SetError(cbb_gender, "");

            if (!ok) return;

            try
            {
                AppDb.EnsureCreated();

                using var conn = AppDb.GetConn();

                using (var check = new SqliteCommand("SELECT 1 FROM Users WHERE Username=@u OR Email=@e;", conn))
                {
                    check.Parameters.AddWithValue("@u", username);
                    check.Parameters.AddWithValue("@e", email);
                    if (check.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Tên đăng nhập hoặc email đã tồn tại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string hash = AppDb.Sha256(password);
                string gender = cbb_gender.SelectedItem?.ToString() ?? "Không tiết lộ";
                string phone = (tb_phone.Text == PH_PHONE) ? "" : tb_phone.Text.Trim();
                string addr = (tb_address.Text == PH_ADDRESS) ? "" : tb_address.Text.Trim();
                string birth = (tb_age.Text == PH_BIRTH) ? "" : tb_age.Text.Trim();

                using var cmd = new SqliteCommand(@"
                    INSERT INTO Users(Username,Email,Phone,Address,Birthdate,Gender,PasswordHash)
                    VALUES(@u,@e,@p,@a,@b,@g,@h);", conn);
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@p", phone);
                cmd.Parameters.AddWithValue("@a", addr);
                cmd.Parameters.AddWithValue("@b", birth);
                cmd.Parameters.AddWithValue("@g", gender);
                cmd.Parameters.AddWithValue("@h", hash);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đăng ký thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                new SignIn().Show(); Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public static class AppDb
    {
        static readonly string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "app.db");

        public static SqliteConnection GetConn()
        {
            var c = new SqliteConnection($"Data Source={path};");
            c.Open(); return c;
        }

        public static void EnsureCreated()
        {
            using var c = GetConn();

            string sql = @"CREATE TABLE IF NOT EXISTS Users(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Username     TEXT NOT NULL UNIQUE,
                Email        TEXT NOT NULL UNIQUE,
                Phone        TEXT,
                Address      TEXT,
                Birthdate    TEXT,
                Gender       TEXT,
                PasswordHash TEXT NOT NULL,
                CreatedAt    TEXT DEFAULT (datetime('now'))
            );";
            new SqliteCommand(sql, c).ExecuteNonQuery();

            try { new SqliteCommand("ALTER TABLE Users ADD COLUMN Gender TEXT;", c).ExecuteNonQuery(); }
            catch { /* đã có cột → bỏ qua */ }
        }

        public static string Sha256(string input)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }
    }
}
