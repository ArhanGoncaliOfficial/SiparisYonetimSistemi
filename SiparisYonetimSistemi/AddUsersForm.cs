using System;
using MySql.Data.MySqlClient;
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
                return;
            }

            if (PasswordHashBox.Text != PasswordAgainBox.Text)
            {
                MessageBox.Show("Passwords do not match. Please try again.");
                return;
            }

            // Email validation using Regex
            if (!System.Text.RegularExpressions.Regex.IsMatch(EmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the password before storing it
            string hashedPassword = HashPassword(PasswordHashBox.Text);

            // MySQL Connection string
            string connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "INSERT INTO Users (Username, PasswordHash, FirstName, LastName, Email, PhoneNumber, Role) VALUES (@Username, @PasswordHash, @FirstName, @LastName, @Email, @PhoneNumber, @Role)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Username", UsernameBox.Text);
                    cmd.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    cmd.Parameters.AddWithValue("@FirstName", NameBox.Text);
                    cmd.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                    cmd.Parameters.AddWithValue("@Email", EmailBox.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumberBox.Text);
                    cmd.Parameters.AddWithValue("@Role", RoleBox.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
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
                return builder.ToString();
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
                RoleBox.SelectedIndex = 0;
            }
            this.AcceptButton = AddButton;
        }

        private void RoleBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = RoleBox.SelectedItem.ToString();

            if (selectedRole == "Admin")
            {
                MessageBox.Show("Admin role selected");
            }
            else if (selectedRole == "User")
            {
                MessageBox.Show("User role selected");
            }
            else
            {
                MessageBox.Show("Please select a valid role.");
            }
        }
    }
}
