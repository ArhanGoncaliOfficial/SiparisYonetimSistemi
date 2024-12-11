namespace SiparisYonetimSistemi
{
    partial class EditUserForm
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
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.ShowPassCheckBox = new System.Windows.Forms.CheckBox();
            this.Role = new System.Windows.Forms.Label();
            this.PhoneNumber = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.Label();
            this.NewPassword = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.OldPassword = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.Name = new System.Windows.Forms.Label();
            this.phoneNumberBox = new System.Windows.Forms.TextBox();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.NewPasswordBox = new System.Windows.Forms.TextBox();
            this.OldPasswordHash = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RoleBox
            // 
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(109, 298);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(144, 21);
            this.RoleBox.TabIndex = 27;
            // 
            // ShowPassCheckBox
            // 
            this.ShowPassCheckBox.AutoSize = true;
            this.ShowPassCheckBox.Location = new System.Drawing.Point(151, 192);
            this.ShowPassCheckBox.Name = "ShowPassCheckBox";
            this.ShowPassCheckBox.Size = new System.Drawing.Size(102, 17);
            this.ShowPassCheckBox.TabIndex = 26;
            this.ShowPassCheckBox.Text = "Show Password";
            this.ShowPassCheckBox.UseVisualStyleBackColor = true;
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Location = new System.Drawing.Point(18, 298);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(29, 13);
            this.Role.TabIndex = 25;
            this.Role.Text = "Role";
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSize = true;
            this.PhoneNumber.Location = new System.Drawing.Point(18, 258);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.PhoneNumber.TabIndex = 24;
            this.PhoneNumber.Text = "Phone Number";
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(18, 218);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 23;
            this.Email.Text = "Email";
            // 
            // NewPassword
            // 
            this.NewPassword.AutoSize = true;
            this.NewPassword.Location = new System.Drawing.Point(18, 169);
            this.NewPassword.Name = "NewPassword";
            this.NewPassword.Size = new System.Drawing.Size(78, 13);
            this.NewPassword.TabIndex = 22;
            this.NewPassword.Text = "New Password";
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(109, 346);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 21;
            this.EditButton.Text = "Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // OldPassword
            // 
            this.OldPassword.AutoSize = true;
            this.OldPassword.Location = new System.Drawing.Point(18, 131);
            this.OldPassword.Name = "OldPassword";
            this.OldPassword.Size = new System.Drawing.Size(75, 13);
            this.OldPassword.TabIndex = 20;
            this.OldPassword.Text = " Old Password";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(18, 96);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(58, 13);
            this.LastName.TabIndex = 19;
            this.LastName.Text = "Last Name";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(18, 24);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(55, 13);
            this.UserName.TabIndex = 18;
            this.UserName.Text = "Username";
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(18, 61);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(35, 13);
            this.Name.TabIndex = 17;
            this.Name.Text = "Name";
            // 
            // phoneNumberBox
            // 
            this.phoneNumberBox.Location = new System.Drawing.Point(109, 255);
            this.phoneNumberBox.Name = "phoneNumberBox";
            this.phoneNumberBox.Size = new System.Drawing.Size(144, 20);
            this.phoneNumberBox.TabIndex = 15;
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(109, 215);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(144, 20);
            this.EmailBox.TabIndex = 14;
            // 
            // NewPasswordBox
            // 
            this.NewPasswordBox.Location = new System.Drawing.Point(107, 166);
            this.NewPasswordBox.Name = "NewPasswordBox";
            this.NewPasswordBox.PasswordChar = '*';
            this.NewPasswordBox.Size = new System.Drawing.Size(144, 20);
            this.NewPasswordBox.TabIndex = 13;
            // 
            // OldPasswordHash
            // 
            this.OldPasswordHash.Location = new System.Drawing.Point(107, 128);
            this.OldPasswordHash.Name = "OldPasswordHash";
            this.OldPasswordHash.PasswordChar = '*';
            this.OldPasswordHash.Size = new System.Drawing.Size(144, 20);
            this.OldPasswordHash.TabIndex = 12;
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(109, 93);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(144, 20);
            this.LastNameBox.TabIndex = 11;
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(109, 21);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(144, 20);
            this.UsernameBox.TabIndex = 16;
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(109, 58);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(144, 20);
            this.NameBox.TabIndex = 10;
            // 
            // EditUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 391);
            this.Controls.Add(this.RoleBox);
            this.Controls.Add(this.ShowPassCheckBox);
            this.Controls.Add(this.Role);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.NewPassword);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.OldPassword);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.phoneNumberBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.NewPasswordBox);
            this.Controls.Add(this.OldPasswordHash);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.NameBox);
            this.Text = "EditUserForm";
            this.Text = "EditUsersForm";
            this.Load += new System.EventHandler(this.EditUsersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.CheckBox ShowPassCheckBox;
        private System.Windows.Forms.Label Role;
        private System.Windows.Forms.Label PhoneNumber;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.Label NewPassword;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label OldPassword;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.TextBox phoneNumberBox;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.TextBox NewPasswordBox;
        private System.Windows.Forms.TextBox OldPasswordHash;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.TextBox NameBox;
    }
}