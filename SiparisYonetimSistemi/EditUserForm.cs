using System;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using MySql.Data.MySqlClient; // MySQL kütüphanesi

namespace SiparisYonetimSistemi
{
    public partial class EditUserForm : Form
    {
        private int _id; // Kullanıcı ID'si
        private string _connectionString = "Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;";
        private const string AdminPassword = "root"; // Admin şifresi

        public EditUserForm(int id)
        {
            InitializeComponent();
            _id = id;
            LoadUserData();
        }

        private void LoadRoles()
        {
            RoleBox.Items.Clear();
            RoleBox.Items.Add("Admin");
            RoleBox.Items.Add("User");
        }

        private void EditUsersForm_Load(object sender, EventArgs e)
        {
            LoadRoles();
        }

        private void LoadUserData()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT Username, FirstName, LastName, Email, PhoneNumber, Role FROM Users WHERE UserID = @UserID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", _id);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            UsernameBox.Text = reader["Username"].ToString();
                            NameBox.Text = reader["FirstName"].ToString();
                            LastNameBox.Text = reader["LastName"].ToString();
                            EmailBox.Text = reader["Email"].ToString();
                            phoneNumberBox.Text = reader["PhoneNumber"].ToString();
                            RoleBox.SelectedItem = reader["Role"].ToString();
                        }
                    }
                }
            }
        }

        private bool CheckOldPassword(int id, string oldPassword)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "SELECT PasswordHash FROM Users WHERE UserID = @UserID";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserID", id);
                    string storedHash = command.ExecuteScalar()?.ToString();

                    if (string.IsNullOrEmpty(storedHash))
                        return false;

                    // Eski şifreyi kontrol et
                    return VerifyPasswordHash(oldPassword, storedHash);
                }
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPasswordHash(string inputPassword, string storedHash)
        {
            string inputHash = HashPassword(inputPassword);
            return inputHash == storedHash;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameBox.Text) ||
                string.IsNullOrWhiteSpace(LastNameBox.Text) ||
                string.IsNullOrWhiteSpace(EmailBox.Text) ||
                string.IsNullOrWhiteSpace(phoneNumberBox.Text))
            {
                MessageBox.Show("Please fill in all fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (RoleBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a role!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Yeni şifre değişikliği için kontrol
            if (!string.IsNullOrWhiteSpace(NewPasswordBox.Text))
            {
                if (string.IsNullOrWhiteSpace(OldPasswordHash.Text))
                {
                    MessageBox.Show("To change your password, you need to enter your old password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (OldPasswordHash.Text != AdminPassword && !CheckOldPassword(_id, OldPasswordHash.Text))
                {
                    MessageBox.Show("Old password is incorrect! Password cannot be changed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, Role = @Role" +
                               (!string.IsNullOrWhiteSpace(NewPasswordBox.Text) ? ", PasswordHash = @PasswordHash" : "") +
                               " WHERE UserID = @UserID";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", NameBox.Text);
                    command.Parameters.AddWithValue("@LastName", LastNameBox.Text);
                    command.Parameters.AddWithValue("@Email", EmailBox.Text);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumberBox.Text);
                    command.Parameters.AddWithValue("@Role", RoleBox.SelectedItem?.ToString() ?? "");
                    command.Parameters.AddWithValue("@UserID", _id);

                    if (!string.IsNullOrWhiteSpace(NewPasswordBox.Text))
                    {
                        string hashedPassword = HashPassword(NewPasswordBox.Text);
                        command.Parameters.AddWithValue("@PasswordHash", hashedPassword);
                    }

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("User information updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
