using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class AddUsersForm : Form
    {
        public AddUsersForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // Check if all necessary fields are filled
            if (string.IsNullOrWhiteSpace(UsernameBox.Text) || string.IsNullOrWhiteSpace(PasswordHashBox.Text) ||
                string.IsNullOrWhiteSpace(NameBox.Text) || string.IsNullOrWhiteSpace(LastNameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailBox.Text))
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the function if a field is missing
            }

            if (PasswordHashBox.Text != PasswordAgainBox.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return; // Do not proceed if passwords do not match
            }

            // Email validation using Regex
            if (!System.Text.RegularExpressions.Regex.IsMatch(EmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the function if email is invalid
            }

            // Here you can hash the password before storing it
            string hashedPassword = HashPassword(PasswordHashBox.Text); // Example of password hashing method

            // Connection string for SiparisYonetimDB database
            string connectionString = "Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, PasswordHash, FirstName, LastName, Email, PhoneNumber, Role) VALUES (@Username, @PasswordHash, @FirstName, @LastName, @Email, @PhoneNumber, @Role)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UsernameBox.Text);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@FirstName", NameBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumberBox.Text);
                    cmd.Parameters.AddWithValue("@Role", RoleBox.SelectedItem.ToString());


                    cmd.ExecuteNonQuery(); // Execute the insert query
                    MessageBox.Show("User added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Close();
        }

        private void ShowPassCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordHashBox.UseSystemPasswordChar = !ShowPassCheckBox.Checked;
            PasswordAgainBox.UseSystemPasswordChar = !ShowPassCheckBox.Checked;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte t in bytes)
                {
                    builder.Append(t.ToString("x2"));
                }
                return builder.ToString(); // Returns the hashed password
            }
        }

        private void AddUsersForm_Load(object sender, EventArgs e)
        {
            RoleBox.Items.Add("Admin");
            RoleBox.Items.Add("User");
            UsernameBox.TabIndex = 0;
            NameBox.TabIndex = 1;
            LastNameBox.TabIndex = 2;
            PasswordHashBox.TabIndex = 3;
            PasswordAgainBox.TabIndex = 4;
            EmailBox.TabIndex = 5;
            phoneNumberBox.TabIndex = 6;

            if (RoleBox.Items.Count > 0)
            {
                RoleBox.SelectedIndex = 0; // Varsayılan olarak ilk elemanı seç
            }

            this.AcceptButton = AddButton;

            //RoleBox.SelectedIndex = 0; // Optional: set a default selection
        }

        private void RoleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = RoleBox.SelectedItem.ToString();

            // Example of what to do based on the selected role
            if (selectedRole == "Admin")
            {
                // Code to execute for Admin role
                MessageBox.Show("Admin role selected");
            }
            else if (selectedRole == "User")
            {
                // Code to execute for User role
                MessageBox.Show("User role selected");
            }
            else
            {
                MessageBox.Show("Please select a valid role.");
            }
        }
    }
}
