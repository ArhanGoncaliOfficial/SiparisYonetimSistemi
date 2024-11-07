namespace SiparisYonetimSistemi
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.banner = new System.Windows.Forms.Panel();
            this.formHeader = new System.Windows.Forms.Label();
            this.emailInputLabel = new System.Windows.Forms.Label();
            this.emailInputField = new System.Windows.Forms.TextBox();
            this.paswordInputLabel = new System.Windows.Forms.Label();
            this.passwordInputField = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginFormCloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // banner
            // 
            this.banner.BackColor = System.Drawing.Color.Crimson;
            this.banner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("banner.BackgroundImage")));
            this.banner.Location = new System.Drawing.Point(0, 0);
            this.banner.Name = "banner";
            this.banner.Size = new System.Drawing.Size(300, 500);
            this.banner.TabIndex = 0;
            // 
            // formHeader
            // 
            this.formHeader.AutoSize = true;
            this.formHeader.BackColor = System.Drawing.Color.Transparent;
            this.formHeader.Font = new System.Drawing.Font("Edwardian Script ITC", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formHeader.Location = new System.Drawing.Point(380, 80);
            this.formHeader.Name = "formHeader";
            this.formHeader.Size = new System.Drawing.Size(342, 76);
            this.formHeader.TabIndex = 1;
            this.formHeader.Text = "Welcome Back";
            // 
            // emailInputLabel
            // 
            this.emailInputLabel.AutoSize = true;
            this.emailInputLabel.BackColor = System.Drawing.Color.Transparent;
            this.emailInputLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailInputLabel.Location = new System.Drawing.Point(453, 196);
            this.emailInputLabel.Name = "emailInputLabel";
            this.emailInputLabel.Size = new System.Drawing.Size(42, 20);
            this.emailInputLabel.TabIndex = 2;
            this.emailInputLabel.Text = "Email";
            // 
            // emailInputField
            // 
            this.emailInputField.BackColor = System.Drawing.Color.Bisque;
            this.emailInputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.emailInputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailInputField.Location = new System.Drawing.Point(458, 219);
            this.emailInputField.Name = "emailInputField";
            this.emailInputField.Size = new System.Drawing.Size(200, 22);
            this.emailInputField.TabIndex = 3;
            // 
            // paswordInputLabel
            // 
            this.paswordInputLabel.AutoSize = true;
            this.paswordInputLabel.BackColor = System.Drawing.Color.Transparent;
            this.paswordInputLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paswordInputLabel.Location = new System.Drawing.Point(455, 254);
            this.paswordInputLabel.Name = "paswordInputLabel";
            this.paswordInputLabel.Size = new System.Drawing.Size(68, 20);
            this.paswordInputLabel.TabIndex = 2;
            this.paswordInputLabel.Text = "Password";
            // 
            // passwordInputField
            // 
            this.passwordInputField.BackColor = System.Drawing.Color.Bisque;
            this.passwordInputField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordInputField.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInputField.Location = new System.Drawing.Point(459, 277);
            this.passwordInputField.Name = "passwordInputField";
            this.passwordInputField.Size = new System.Drawing.Size(200, 22);
            this.passwordInputField.TabIndex = 3;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.Bisque;
            this.loginButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.loginButton.FlatAppearance.BorderSize = 0;
            this.loginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginButton.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(459, 329);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(200, 40);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = false;
            // 
            // loginFormCloseButton
            // 
            this.loginFormCloseButton.BackColor = System.Drawing.Color.Transparent;
            this.loginFormCloseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginFormCloseButton.FlatAppearance.BorderSize = 0;
            this.loginFormCloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginFormCloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginFormCloseButton.Location = new System.Drawing.Point(758, 12);
            this.loginFormCloseButton.Name = "loginFormCloseButton";
            this.loginFormCloseButton.Size = new System.Drawing.Size(30, 30);
            this.loginFormCloseButton.TabIndex = 5;
            this.loginFormCloseButton.Text = "X";
            this.loginFormCloseButton.UseVisualStyleBackColor = false;
            this.loginFormCloseButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.loginFormCloseButton);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.passwordInputField);
            this.Controls.Add(this.emailInputField);
            this.Controls.Add(this.paswordInputLabel);
            this.Controls.Add(this.emailInputLabel);
            this.Controls.Add(this.formHeader);
            this.Controls.Add(this.banner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel banner;
        private System.Windows.Forms.Label formHeader;
        private System.Windows.Forms.Label emailInputLabel;
        private System.Windows.Forms.TextBox emailInputField;
        private System.Windows.Forms.Label paswordInputLabel;
        private System.Windows.Forms.TextBox passwordInputField;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Button loginFormCloseButton;
    }
}

