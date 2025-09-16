namespace GUI_TicketSalesSystem
{
    partial class FormRegister
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbFirstName = new System.Windows.Forms.Label();
            this.lbLastName = new System.Windows.Forms.Label();
            this.lbBirthday = new System.Windows.Forms.Label();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbPhone = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.btnBackLogin = new System.Windows.Forms.Button();
            this.dateNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.btnRegister = new System.Windows.Forms.Button();
            this.lblUsernameError = new System.Windows.Forms.Label();
            this.lblConfirmPasswordError = new System.Windows.Forms.Label();
            this.lblPasswordError = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblNgaySinhError = new System.Windows.Forms.Label();
            this.lblEmailError = new System.Windows.Forms.Label();
            this.lblPhoneError = new System.Windows.Forms.Label();
            this.lblLastNameError = new System.Windows.Forms.Label();
            this.lblFirstNameError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(204, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng ký tài khoản";
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(37, 79);
            this.lbUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(124, 24);
            this.lbUsername.TabIndex = 1;
            this.lbUsername.Text = "Tên tài khoản";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassword.Location = new System.Drawing.Point(37, 126);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(86, 24);
            this.lbPassword.TabIndex = 1;
            this.lbPassword.Text = "Mật khẩu";
            // 
            // lbFirstName
            // 
            this.lbFirstName.AutoSize = true;
            this.lbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirstName.Location = new System.Drawing.Point(37, 225);
            this.lbFirstName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbFirstName.Name = "lbFirstName";
            this.lbFirstName.Size = new System.Drawing.Size(35, 24);
            this.lbFirstName.TabIndex = 1;
            this.lbFirstName.Text = "Họ";
            // 
            // lbLastName
            // 
            this.lbLastName.AutoSize = true;
            this.lbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastName.Location = new System.Drawing.Point(36, 270);
            this.lbLastName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLastName.Name = "lbLastName";
            this.lbLastName.Size = new System.Drawing.Size(44, 24);
            this.lbLastName.TabIndex = 1;
            this.lbLastName.Text = "Tên";
            // 
            // lbBirthday
            // 
            this.lbBirthday.AutoSize = true;
            this.lbBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBirthday.Location = new System.Drawing.Point(36, 314);
            this.lbBirthday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbBirthday.Name = "lbBirthday";
            this.lbBirthday.Size = new System.Drawing.Size(94, 24);
            this.lbBirthday.TabIndex = 1;
            this.lbBirthday.Text = "Ngày sinh";
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmail.Location = new System.Drawing.Point(36, 357);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(57, 24);
            this.lbEmail.TabIndex = 1;
            this.lbEmail.Text = "Email";
            // 
            // lbPhone
            // 
            this.lbPhone.AutoSize = true;
            this.lbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPhone.Location = new System.Drawing.Point(36, 399);
            this.lbPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPhone.Name = "lbPhone";
            this.lbPhone.Size = new System.Drawing.Size(121, 24);
            this.lbPhone.TabIndex = 1;
            this.lbPhone.Text = "Số điện thoại";
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(211, 73);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(316, 29);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(211, 116);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(316, 29);
            this.txtPassword.TabIndex = 2;
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(211, 214);
            this.txtLastName.Margin = new System.Windows.Forms.Padding(4);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(316, 29);
            this.txtLastName.TabIndex = 2;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(211, 264);
            this.txtFirstName.Margin = new System.Windows.Forms.Padding(4);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(316, 29);
            this.txtFirstName.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(211, 351);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(316, 29);
            this.txtEmail.TabIndex = 2;
            // 
            // txtPhone
            // 
            this.txtPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Location = new System.Drawing.Point(211, 393);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(316, 29);
            this.txtPhone.TabIndex = 2;
            // 
            // btnBackLogin
            // 
            this.btnBackLogin.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnBackLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnBackLogin.Location = new System.Drawing.Point(42, 451);
            this.btnBackLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnBackLogin.Name = "btnBackLogin";
            this.btnBackLogin.Size = new System.Drawing.Size(200, 44);
            this.btnBackLogin.TabIndex = 3;
            this.btnBackLogin.Text = "Quay về đăng nhập";
            this.btnBackLogin.UseVisualStyleBackColor = false;
            this.btnBackLogin.Click += new System.EventHandler(this.btnBackLogin_Click);
            // 
            // dateNgaySinh
            // 
            this.dateNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateNgaySinh.Location = new System.Drawing.Point(211, 308);
            this.dateNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.dateNgaySinh.Name = "dateNgaySinh";
            this.dateNgaySinh.Size = new System.Drawing.Size(316, 29);
            this.dateNgaySinh.TabIndex = 4;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.Lime;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnRegister.Location = new System.Drawing.Point(396, 451);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(131, 44);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // lblUsernameError
            // 
            this.lblUsernameError.AutoSize = true;
            this.lblUsernameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsernameError.ForeColor = System.Drawing.Color.Red;
            this.lblUsernameError.Location = new System.Drawing.Point(555, 73);
            this.lblUsernameError.Name = "lblUsernameError";
            this.lblUsernameError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblUsernameError.Size = new System.Drawing.Size(135, 17);
            this.lblUsernameError.TabIndex = 5;
            this.lblUsernameError.Text = "lableUsernameError";
            // 
            // lblConfirmPasswordError
            // 
            this.lblConfirmPasswordError.AutoSize = true;
            this.lblConfirmPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordError.Location = new System.Drawing.Point(555, 166);
            this.lblConfirmPasswordError.Name = "lblConfirmPasswordError";
            this.lblConfirmPasswordError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblConfirmPasswordError.Size = new System.Drawing.Size(179, 17);
            this.lblConfirmPasswordError.TabIndex = 6;
            this.lblConfirmPasswordError.Text = "lableConfirmPasswordError";
            // 
            // lblPasswordError
            // 
            this.lblPasswordError.AutoSize = true;
            this.lblPasswordError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordError.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordError.Location = new System.Drawing.Point(555, 120);
            this.lblPasswordError.Name = "lblPasswordError";
            this.lblPasswordError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPasswordError.Size = new System.Drawing.Size(131, 17);
            this.lblPasswordError.TabIndex = 7;
            this.lblPasswordError.Text = "lablePasswordError";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(211, 167);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(316, 29);
            this.txtConfirmPassword.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 172);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 24);
            this.label4.TabIndex = 8;
            this.label4.Text = "Xác nhận MK";
            // 
            // lblNgaySinhError
            // 
            this.lblNgaySinhError.AutoSize = true;
            this.lblNgaySinhError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinhError.ForeColor = System.Drawing.Color.Red;
            this.lblNgaySinhError.Location = new System.Drawing.Point(555, 308);
            this.lblNgaySinhError.Name = "lblNgaySinhError";
            this.lblNgaySinhError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNgaySinhError.Size = new System.Drawing.Size(131, 17);
            this.lblNgaySinhError.TabIndex = 10;
            this.lblNgaySinhError.Text = "lableNgaySinhError";
            // 
            // lblEmailError
            // 
            this.lblEmailError.AutoSize = true;
            this.lblEmailError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmailError.ForeColor = System.Drawing.Color.Red;
            this.lblEmailError.Location = new System.Drawing.Point(555, 355);
            this.lblEmailError.Name = "lblEmailError";
            this.lblEmailError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEmailError.Size = new System.Drawing.Size(104, 17);
            this.lblEmailError.TabIndex = 11;
            this.lblEmailError.Text = "lableEmailError";
            // 
            // lblPhoneError
            // 
            this.lblPhoneError.AutoSize = true;
            this.lblPhoneError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneError.ForeColor = System.Drawing.Color.Red;
            this.lblPhoneError.Location = new System.Drawing.Point(555, 397);
            this.lblPhoneError.Name = "lblPhoneError";
            this.lblPhoneError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblPhoneError.Size = new System.Drawing.Size(111, 17);
            this.lblPhoneError.TabIndex = 12;
            this.lblPhoneError.Text = "lablePhoneError";
            // 
            // lblLastNameError
            // 
            this.lblLastNameError.AutoSize = true;
            this.lblLastNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastNameError.ForeColor = System.Drawing.Color.Red;
            this.lblLastNameError.Location = new System.Drawing.Point(555, 218);
            this.lblLastNameError.Name = "lblLastNameError";
            this.lblLastNameError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLastNameError.Size = new System.Drawing.Size(134, 17);
            this.lblLastNameError.TabIndex = 13;
            this.lblLastNameError.Text = "lableLastNameError";
            // 
            // lblFirstNameError
            // 
            this.lblFirstNameError.AutoSize = true;
            this.lblFirstNameError.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstNameError.ForeColor = System.Drawing.Color.Red;
            this.lblFirstNameError.Location = new System.Drawing.Point(555, 268);
            this.lblFirstNameError.Name = "lblFirstNameError";
            this.lblFirstNameError.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblFirstNameError.Size = new System.Drawing.Size(134, 17);
            this.lblFirstNameError.TabIndex = 14;
            this.lblFirstNameError.Text = "lableFirstNameError";
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 512);
            this.Controls.Add(this.lblFirstNameError);
            this.Controls.Add(this.lblLastNameError);
            this.Controls.Add(this.lblPhoneError);
            this.Controls.Add(this.lblEmailError);
            this.Controls.Add(this.lblNgaySinhError);
            this.Controls.Add(this.txtConfirmPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblPasswordError);
            this.Controls.Add(this.lblConfirmPasswordError);
            this.Controls.Add(this.lblUsernameError);
            this.Controls.Add(this.dateNgaySinh);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnBackLogin);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.lbPhone);
            this.Controls.Add(this.lbEmail);
            this.Controls.Add(this.lbBirthday);
            this.Controls.Add(this.lbLastName);
            this.Controls.Add(this.lbFirstName);
            this.Controls.Add(this.lbPassword);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký";
            this.Load += new System.EventHandler(this.FormRegister_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbFirstName;
        private System.Windows.Forms.Label lbLastName;
        private System.Windows.Forms.Label lbBirthday;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbPhone;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Button btnBackLogin;
        private System.Windows.Forms.DateTimePicker dateNgaySinh;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Label lblUsernameError;
        private System.Windows.Forms.Label lblConfirmPasswordError;
        private System.Windows.Forms.Label lblPasswordError;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblNgaySinhError;
        private System.Windows.Forms.Label lblEmailError;
        private System.Windows.Forms.Label lblPhoneError;
        private System.Windows.Forms.Label lblLastNameError;
        private System.Windows.Forms.Label lblFirstNameError;
    }
}