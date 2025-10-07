namespace BT_Tuan_3
{
    partial class SignUp
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
            tb_username = new TextBox();
            lb_signup = new Label();
            btn_signup = new Button();
            linklb_signin = new LinkLabel();
            lb_signin = new Label();
            tb_email = new TextBox();
            tb_psw = new TextBox();
            tb_cf_psw = new TextBox();
            tb_phone = new TextBox();
            tb_address = new TextBox();
            cbb_gender = new ComboBox();
            checkBox1 = new CheckBox();
            tb_age = new TextBox();
            SuspendLayout();
            // 
            // tb_username
            // 
            tb_username.Location = new Point(153, 186);
            tb_username.Name = "tb_username";
            tb_username.Size = new Size(177, 27);
            tb_username.TabIndex = 0;
            // 
            // lb_signup
            // 
            lb_signup.AutoSize = true;
            lb_signup.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 163);
            lb_signup.Location = new Point(218, 62);
            lb_signup.Name = "lb_signup";
            lb_signup.Size = new Size(377, 54);
            lb_signup.TabIndex = 1;
            lb_signup.Text = "Đăng Ký Tài Khoản";
            // 
            // btn_signup
            // 
            btn_signup.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 163);
            btn_signup.Location = new Point(338, 386);
            btn_signup.Name = "btn_signup";
            btn_signup.Size = new Size(108, 35);
            btn_signup.TabIndex = 2;
            btn_signup.Text = "Đăng Ký";
            btn_signup.UseVisualStyleBackColor = true;
            btn_signup.Click += btn_signup_Click;
            // 
            // linklb_signin
            // 
            linklb_signin.AutoSize = true;
            linklb_signin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            linklb_signin.Location = new Point(422, 424);
            linklb_signin.Name = "linklb_signin";
            linklb_signin.Size = new Size(95, 23);
            linklb_signin.TabIndex = 3;
            linklb_signin.TabStop = true;
            linklb_signin.Text = "Đăng nhập";
            linklb_signin.LinkClicked += linklb_signin_LinkClicked;
            // 
            // lb_signin
            // 
            lb_signin.AutoSize = true;
            lb_signin.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lb_signin.Location = new Point(278, 424);
            lb_signin.Name = "lb_signin";
            lb_signin.Size = new Size(138, 23);
            lb_signin.TabIndex = 4;
            lb_signin.Text = "Đã có tài khoản?";
            // 
            // tb_email
            // 
            tb_email.Location = new Point(153, 232);
            tb_email.Name = "tb_email";
            tb_email.Size = new Size(177, 27);
            tb_email.TabIndex = 5;
            // 
            // tb_psw
            // 
            tb_psw.Location = new Point(153, 279);
            tb_psw.Name = "tb_psw";
            tb_psw.Size = new Size(177, 27);
            tb_psw.TabIndex = 6;
            // 
            // tb_cf_psw
            // 
            tb_cf_psw.Location = new Point(153, 327);
            tb_cf_psw.Name = "tb_cf_psw";
            tb_cf_psw.Size = new Size(177, 27);
            tb_cf_psw.TabIndex = 7;
            tb_cf_psw.TextChanged += tb_cf_psw_TextChanged;
            // 
            // tb_phone
            // 
            tb_phone.Location = new Point(479, 327);
            tb_phone.Name = "tb_phone";
            tb_phone.Size = new Size(177, 27);
            tb_phone.TabIndex = 8;
            // 
            // tb_address
            // 
            tb_address.Location = new Point(479, 232);
            tb_address.Name = "tb_address";
            tb_address.Size = new Size(177, 27);
            tb_address.TabIndex = 12;
            // 
            // cbb_gender
            // 
            cbb_gender.FormattingEnabled = true;
            cbb_gender.Location = new Point(479, 279);
            cbb_gender.Name = "cbb_gender";
            cbb_gender.Size = new Size(177, 28);
            cbb_gender.TabIndex = 13;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(479, 397);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(180, 24);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Đồng ý với điều khoản";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // tb_age
            // 
            tb_age.Location = new Point(479, 186);
            tb_age.Name = "tb_age";
            tb_age.Size = new Size(177, 27);
            tb_age.TabIndex = 15;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(846, 504);
            Controls.Add(tb_age);
            Controls.Add(checkBox1);
            Controls.Add(cbb_gender);
            Controls.Add(tb_address);
            Controls.Add(tb_phone);
            Controls.Add(tb_cf_psw);
            Controls.Add(tb_psw);
            Controls.Add(tb_email);
            Controls.Add(lb_signin);
            Controls.Add(linklb_signin);
            Controls.Add(btn_signup);
            Controls.Add(lb_signup);
            Controls.Add(tb_username);
            Name = "SignUp";
            Text = "SignUp";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_username;
        private Label lb_signup;
        private Button btn_signup;
        private LinkLabel linklb_signin;
        private Label lb_signin;
        private TextBox tb_email;
        private TextBox tb_psw;
        private TextBox tb_cf_psw;
        private TextBox tb_phone;
        private TextBox tb_;
        private TextBox textBox7;
        private TextBox textBox8;
        private TextBox tb_address;
        private ComboBox cbb_gender;
        private CheckBox checkBox1;
        private TextBox tb_age;
    }
}