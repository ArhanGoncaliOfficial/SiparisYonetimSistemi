using AnaDash;
using MySql.Data.MySqlClient; // MySQL kütüphanesi
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class LoginForm : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        // MySQL Connection string
        private string connectionString = "Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;";

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomComponents();
            this.Load += LoginForm_Load;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            TestSqlConnection();
            CreateDefaultAdminUser();
        }

        private void InitializeCustomComponents()
        {
            this.CenterToScreen();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));

            passwordInputField.UseSystemPasswordChar = true;
            showPasswordCheckbox.CheckedChanged += ShowPasswordCheckbox_CheckedChanged;
        }

        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            passwordInputField.UseSystemPasswordChar = !showPasswordCheckbox.Checked;
        }

        private void loginFormCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TestSqlConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Database connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CreateDefaultAdminUser()
        {
            string defaultUsername = "root";
            string defaultPassword = "root";
            string hashedPassword = ComputeSha256Hash(defaultPassword);

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string checkAdminQuery = "SELECT COUNT(1) FROM Users WHERE Username = @username";
                    using (MySqlCommand checkCommand = new MySqlCommand(checkAdminQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@username", defaultUsername);
                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (userCount == 0)
                        {
                            string insertAdminQuery = @"INSERT INTO Users (Username, Email, PasswordHash, FirstName, LastName, PhoneNumber, Role, LastLoginDate)
                                                        VALUES (@username, @adminEmail, @hashedPassword, 'Admin', 'User', '000-000-0000', 'Admin', NOW())";
                            using (MySqlCommand insertCommand = new MySqlCommand(insertAdminQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@username", defaultUsername);
                                insertCommand.Parameters.AddWithValue("@adminEmail", "admin@example.com");
                                insertCommand.Parameters.AddWithValue("@hashedPassword", hashedPassword);

                                insertCommand.ExecuteNonQuery();
                                MessageBox.Show("Default admin user created: \nEmail: admin@example.com\nPassword: root", "Admin User Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating default admin user: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailInputField.Text.Trim();
            string password = passwordInputField.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill out every input!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Hash the input password
            string hashedPassword = ComputeSha256Hash(password);

            // Validate the user
            if (ValidateUser(email, hashedPassword))
            {
                UpdateLastLoginDate(email); // Giriş tarihini güncelle
                MessageBox.Show("Login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HomePageForm homePageForm = new HomePageForm(); // Redirect the user to Home Page
                homePageForm.Show();
                this.Hide(); // Hide the current form
            }
            else
            {
                MessageBox.Show("Invalid email or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Kullanıcının son giriş tarihini güncelleyen metod
        private void UpdateLastLoginDate(string email)
        {
            string updateQuery = "UPDATE Users SET LastLoginDate = NOW() WHERE Email = @Email";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating last login date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool ValidateUser(string email, string hashedPassword)
        {
            bool isValidUser = false;
            string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND PasswordHash = @hashedPassword";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@hashedPassword", hashedPassword);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        isValidUser = userCount == 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isValidUser;
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
            emailInputField.TabIndex = 0;
            passwordInputField.TabIndex = 1;
            loginButton.TabIndex = 2;
            showPasswordCheckbox.TabIndex = 3;
            this.AcceptButton = loginButton;
        }
    }
}
