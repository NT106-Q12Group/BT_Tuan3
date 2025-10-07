namespace BT_Tuan_3
{
    partial class SignIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lb_signin = new Label();
            linklb_signup = new LinkLabel();
            btn_signin = new Button();
            tb_username = new TextBox();
            lb_signup = new Label();
            tb_psw = new TextBox();
            SuspendLayout();
            // 
            // lb_signin
            // 
            lb_signin.AutoSize = true;
            lb_signin.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_signin.Location = new Point(66, 85);
            lb_signin.Name = "lb_signin";
            lb_signin.Size = new Size(135, 31);
            lb_signin.TabIndex = 0;
            lb_signin.Text = "Đăng Nhập";
            // 
            // linklb_signup
            // 
            linklb_signup.AutoSize = true;
            linklb_signup.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            linklb_signup.Location = new Point(170, 315);
            linklb_signup.Name = "linklb_signup";
            linklb_signup.Size = new Size(122, 25);
            linklb_signup.TabIndex = 1;
            linklb_signup.TabStop = true;
            linklb_signup.Text = "Đăng ký ngay";
            linklb_signup.LinkClicked += linklb_signup_LinkClicked;
            // 
            // btn_signin
            // 
            btn_signin.Location = new Point(66, 243);
            btn_signin.Name = "btn_signin";
            btn_signin.Size = new Size(135, 37);
            btn_signin.TabIndex = 2;
            btn_signin.Text = "Đăng Nhập";
            btn_signin.UseVisualStyleBackColor = true;
            // 
            // tb_username
            // 
            tb_username.Location = new Point(30, 134);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(212, 27);
            tb_username.TabIndex = 3;
            // 
            // lb_signup
            // 
            lb_signup.AutoSize = true;
            lb_signup.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lb_signup.Location = new Point(12, 315);
            lb_signup.Name = "lb_signup";
            lb_signup.Size = new Size(163, 25);
            lb_signup.TabIndex = 4;
            lb_signup.Text = "Chưa có tài khoản?";
            // 
            // tb_psw
            // 
            tb_psw.Location = new Point(30, 189);
            tb_psw.Name = "tb_psw";
            tb_psw.Size = new Size(212, 27);
            tb_psw.TabIndex = 5;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tb_psw);
            Controls.Add(lb_signup);
            Controls.Add(tb_username);
            Controls.Add(btn_signin);
            Controls.Add(linklb_signup);
            Controls.Add(lb_signin);
            Name = "SignIn";
            Text = "SignIn";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lb_signin;
        private LinkLabel linklb_signup;
        private Button btn_signin;
        private TextBox tb_username;
        private Label lb_signup;
        private TextBox tb_psw;
    }
}