using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT_Tuan_3
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            SetPlaceholder(tb_email, "Email");
            SetPlaceholder(tb_username, "Tên đăng nhập");
            SetPlaceholder(tb_phone, "Số điện thoại");
            SetPswPlaceholder(tb_psw, "Mật khẩu");
            SetPswPlaceholder(tb_cf_psw, "Xác nhận mật khẩu");
            SetPlaceholder(tb_address, "Địa chỉ");
            SetPlaceholder(tb_age, "Ngày sinh");
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        private void SetPswPlaceholder(TextBox tb, string placeholder)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb_psw.UseSystemPasswordChar = true;
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrEmpty(tb.Text))
                {
                    tb_psw.UseSystemPasswordChar = false;
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        private void linklb_signin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignIn signinform = new SignIn();
            signinform.Show();
            this.Hide();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {

        }
    }
}
