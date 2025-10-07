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
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
            SetPlaceholder(tb_username, "Tên đăng nhập");
            SetPswPlaceholder(tb_psw, "Mật khẩu");
            tb_username.KeyPress += tb_username_KeyPress;
            tb_psw.KeyPress += tb_psw_KeyPress;
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

        private void linklb_signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp sigupform = new SignUp();
            sigupform.Show();

            this.Hide();
        }

        private void tb_username_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên đăng nhập không được chứa khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tb_psw_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Tên mật khẩu không được chứa khoảng trắng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tb_psw_TextChanged(object sender, EventArgs e)
        {


        }

        private void btn_signin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_username.Text) && tb_username.Text.Length > 0 && tb_username.Text.Length < 8)
            {
                MessageBox.Show("Tên đăng nhập phải có ít nhất 8 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tb_username.Focus();
            }
        }

        private void tb_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
