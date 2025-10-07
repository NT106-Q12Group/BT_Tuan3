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
        }

        private void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;

            tb.Enter += (s,e) =>{
                if (tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };
            tb.Leave += (s,e) => 
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

            tb.Enter += (s, e) => {
                if (tb.Text == placeholder)
                {
                    tb_psw.UseSystemPasswordChar = true;
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.Leave += (s,e) => {
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
    }
}
