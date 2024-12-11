using AnaDash;
using System;
using System.Data;
using System.Data.SqlClient;
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

        // SQL Connection string (Update as needed)
        private string connectionString = @"Server=.;Database=SiparisYonetimDB;Trusted_Connection=True;";

        public LoginForm()
        {
            InitializeComponent();
            InitializeCustomComponents();

            // Form load event handler
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

        // Toggle password visibility
        private void ShowPasswordCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            passwordInputField.UseSystemPasswordChar = !showPasswordCheckbox.Checked;
        }

        // Close the form
        private void loginFormCloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Test the SQL database connection
        private void TestSqlConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
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

        // Create default admin user if not exists
        private void CreateDefaultAdminUser()
        {
            string defaultUsername = "root";
            string defaultPassword = "root";
            string hashedPassword = ComputeSha256Hash(defaultPassword);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check if admin user already exists
                    string checkAdminQuery = "SELECT COUNT(1) FROM Users WHERE Username = @username";
                    using (SqlCommand checkCommand = new SqlCommand(checkAdminQuery, connection))
                    {
                        checkCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar) { Value = defaultUsername });
                        int userCount = Convert.ToInt32(checkCommand.ExecuteScalar());

                        // If no admin user exists, create one
                        if (userCount == 0)
                        {
                            string insertAdminQuery = @"INSERT INTO Users (Username, Email, PasswordHash, FirstName, LastName, PhoneNumber, Role, LastLoginDate)
                                                         VALUES (@username, @adminEmail, @hashedPassword, 'Admin', 'User', '000-000-0000', 1, GETDATE())";
                            using (SqlCommand insertCommand = new SqlCommand(insertAdminQuery, connection))
                            {
                                insertCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.NVarChar) { Value = defaultUsername });
                                insertCommand.Parameters.Add(new SqlParameter("@adminEmail", SqlDbType.NVarChar) { Value = "admin@example.com" });
                                insertCommand.Parameters.Add(new SqlParameter("@hashedPassword", SqlDbType.NVarChar) { Value = hashedPassword });

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

        // Login button click event
        private void loginButton_Click(object sender, EventArgs e)
        {
            string email = emailInputField.Text.Trim(); // Using email only
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

        // Validate user credentials using email and hashed password
        private bool ValidateUser(string email, string hashedPassword)
        {
            bool isValidUser = false;
            string query = @"SELECT COUNT(1) FROM Users 
                             WHERE Email = @Email 
                             AND PasswordHash = @hashedPassword";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar) { Value = email });
                        command.Parameters.Add(new SqlParameter("@hashedPassword", SqlDbType.NVarChar) { Value = hashedPassword });

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

        // Compute SHA256 hash for the given string
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
            emailInputField.TabIndex= 0;
            passwordInputField.TabIndex= 1;
            loginButton.TabIndex= 2;
            showPasswordCheckbox.TabIndex= 3;
            this.AcceptButton = loginButton;

        }
    }
}
