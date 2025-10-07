using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BT_Tuan_3
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Email { get; set; } = "";
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Birthdate { get; set; }
        public string? Gender { get; set; }
        public string CreatedAt { get; set; } = "";
    }

    public class Dashboard : Form
    {
        private readonly User user;
        private Label lblInfo;
        private Button btnLogout;

        public Dashboard(User u)
        {
            this.user = u;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Dashboard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(640, 360);

            lblInfo = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 11),
                Location = new Point(20, 20),
                Text = BuildUserInfo(user)
            };
            this.Controls.Add(lblInfo);

            btnLogout = new Button
            {
                Text = "Đăng xuất",
                AutoSize = true,
                Location = new Point(20, 280)
            };
            btnLogout.Click += btn_logout_Click;
            this.Controls.Add(btnLogout);
        }

        private string BuildUserInfo(User u)
        {
            string phone = string.IsNullOrWhiteSpace(u.Phone) ? "(trống)" : u.Phone;
            string addr = string.IsNullOrWhiteSpace(u.Address) ? "(trống)" : u.Address;
            string birth = string.IsNullOrWhiteSpace(u.Birthdate) ? "(trống)" : u.Birthdate;
            string gender = string.IsNullOrWhiteSpace(u.Gender) ? "(không tiết lộ)" : u.Gender;

            var sb = new StringBuilder();
            sb.AppendLine($"Xin chào, {u.Username}!");
            sb.AppendLine();
            sb.AppendLine($"Email: {u.Email}");
            sb.AppendLine($"Giới tính: {gender}");
            sb.AppendLine($"SĐT: {phone}");
            sb.AppendLine($"Địa chỉ: {addr}");
            sb.AppendLine($"Ngày sinh: {birth}");
            sb.AppendLine($"Tạo tài khoản: {u.CreatedAt}");
            return sb.ToString();
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            new SignIn().Show();
            this.Close();
        }
    }
}
