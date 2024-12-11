namespace SiparisYonetimSistemi
{
    partial class AddUsersForm
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
            this.NameBox = new System.Windows.Forms.TextBox();
            this.LastNameBox = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.Label();
            this.LastName = new System.Windows.Forms.Label();
            this.PasswordHashBox = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.Label();
            this.AddButton = new System.Windows.Forms.Button();
            this.PasswordAgain = new System.Windows.Forms.Label();
            this.PasswordAgainBox = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.Label();
            this.EmailBox = new System.Windows.Forms.TextBox();
            this.PhoneNumber = new System.Windows.Forms.Label();
            this.phoneNumberBox = new System.Windows.Forms.TextBox();
            this.Role = new System.Windows.Forms.Label();
            this.ShowPassCheckBox = new System.Windows.Forms.CheckBox();
            this.RoleBox = new System.Windows.Forms.ComboBox();
            this.UserName = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(103, 58);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(144, 20);
            this.NameBox.TabIndex = 0;
            // 
            // LastNameBox
            // 
            this.LastNameBox.Location = new System.Drawing.Point(103, 93);
            this.LastNameBox.Name = "LastNameBox";
            this.LastNameBox.Size = new System.Drawing.Size(144, 20);
            this.LastNameBox.TabIndex = 0;
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Location = new System.Drawing.Point(12, 61);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(35, 13);
            this.Name.TabIndex = 1;
            this.Name.Text = "Name";
            // 
            // LastName
            // 
            this.LastName.AutoSize = true;
            this.LastName.Location = new System.Drawing.Point(12, 96);
            this.LastName.Name = "LastName";
            this.LastName.Size = new System.Drawing.Size(58, 13);
            this.LastName.TabIndex = 2;
            this.LastName.Text = "Last Name";
            // 
            // PasswordHashBox
            // 
            this.PasswordHashBox.Location = new System.Drawing.Point(101, 128);
            this.PasswordHashBox.Name = "PasswordHashBox";
            this.PasswordHashBox.PasswordChar = '*';
            this.PasswordHashBox.Size = new System.Drawing.Size(144, 20);
            this.PasswordHashBox.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(12, 131);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(53, 13);
            this.Password.TabIndex = 3;
            this.Password.Text = "Password";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(103, 346);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 4;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // PasswordAgain
            // 
            this.PasswordAgain.AutoSize = true;
            this.PasswordAgain.Location = new System.Drawing.Point(12, 169);
            this.PasswordAgain.Name = "PasswordAgain";
            this.PasswordAgain.Size = new System.Drawing.Size(83, 13);
            this.PasswordAgain.TabIndex = 5;
            this.PasswordAgain.Text = "Password Again";
            // 
            // PasswordAgainBox
            // 
            this.PasswordAgainBox.Location = new System.Drawing.Point(101, 166);
            this.PasswordAgainBox.Name = "PasswordAgainBox";
            this.PasswordAgainBox.PasswordChar = '*';
            this.PasswordAgainBox.Size = new System.Drawing.Size(144, 20);
            this.PasswordAgainBox.TabIndex = 0;
            // 
            // Email
            // 
            this.Email.AutoSize = true;
            this.Email.Location = new System.Drawing.Point(12, 218);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(32, 13);
            this.Email.TabIndex = 6;
            this.Email.Text = "Email";
            // 
            // EmailBox
            // 
            this.EmailBox.Location = new System.Drawing.Point(103, 215);
            this.EmailBox.Name = "EmailBox";
            this.EmailBox.Size = new System.Drawing.Size(144, 20);
            this.EmailBox.TabIndex = 0;
            // 
            // PhoneNumber
            // 
            this.PhoneNumber.AutoSize = true;
            this.PhoneNumber.Location = new System.Drawing.Point(12, 258);
            this.PhoneNumber.Name = "PhoneNumber";
            this.PhoneNumber.Size = new System.Drawing.Size(78, 13);
            this.PhoneNumber.TabIndex = 7;
            this.PhoneNumber.Text = "Phone Number";
            // 
            // phoneNumberBox
            // 
            this.phoneNumberBox.Location = new System.Drawing.Point(103, 255);
            this.phoneNumberBox.Name = "phoneNumberBox";
            this.phoneNumberBox.Size = new System.Drawing.Size(144, 20);
            this.phoneNumberBox.TabIndex = 0;
            // 
            // Role
            // 
            this.Role.AutoSize = true;
            this.Role.Location = new System.Drawing.Point(12, 298);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(29, 13);
            this.Role.TabIndex = 7;
            this.Role.Text = "Role";
            // 
            // ShowPassCheckBox
            // 
            this.ShowPassCheckBox.AutoSize = true;
            this.ShowPassCheckBox.Location = new System.Drawing.Point(145, 192);
            this.ShowPassCheckBox.Name = "ShowPassCheckBox";
            this.ShowPassCheckBox.Size = new System.Drawing.Size(102, 17);
            this.ShowPassCheckBox.TabIndex = 8;
            this.ShowPassCheckBox.Text = "Show Password";
            this.ShowPassCheckBox.UseVisualStyleBackColor = true;
            this.ShowPassCheckBox.CheckedChanged += new System.EventHandler(this.ShowPassCheckBox_CheckedChanged);
            // 
            // RoleBox
            // 
            this.RoleBox.FormattingEnabled = true;
            this.RoleBox.Location = new System.Drawing.Point(103, 298);
            this.RoleBox.Name = "RoleBox";
            this.RoleBox.Size = new System.Drawing.Size(144, 21);
            this.RoleBox.TabIndex = 9;
            this.RoleBox.SelectedIndexChanged += new System.EventHandler(this.RoleBox_SelectedIndexChanged);
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(12, 24);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(55, 13);
            this.UserName.TabIndex = 1;
            this.UserName.Text = "Username";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(103, 21);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(144, 20);
            this.UsernameBox.TabIndex = 0;
            // 
            // AddUsersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 391);
            this.Controls.Add(this.RoleBox);
            this.Controls.Add(this.ShowPassCheckBox);
            this.Controls.Add(this.Role);
            this.Controls.Add(this.PhoneNumber);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.PasswordAgain);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.LastName);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.phoneNumberBox);
            this.Controls.Add(this.EmailBox);
            this.Controls.Add(this.PasswordAgainBox);
            this.Controls.Add(this.PasswordHashBox);
            this.Controls.Add(this.LastNameBox);
            this.Controls.Add(this.UsernameBox);
            this.Controls.Add(this.NameBox);
            this.Text = "AddUsersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddUsers";
            this.Load += new System.EventHandler(this.AddUsersForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.TextBox LastNameBox;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.Label LastName;
        private System.Windows.Forms.TextBox PasswordHashBox;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label PasswordAgain;
        private System.Windows.Forms.TextBox PasswordAgainBox;
        private System.Windows.Forms.Label Email;
        private System.Windows.Forms.TextBox EmailBox;
        private System.Windows.Forms.Label PhoneNumber;
        private System.Windows.Forms.TextBox phoneNumberBox;
        private System.Windows.Forms.Label Role;
        private System.Windows.Forms.CheckBox ShowPassCheckBox;
        private System.Windows.Forms.ComboBox RoleBox;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox UsernameBox;
    }
}