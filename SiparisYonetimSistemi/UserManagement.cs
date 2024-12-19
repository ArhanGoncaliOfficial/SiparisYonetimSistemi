using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL kütüphanesi

namespace SiparisYonetimSistemi
{
    public partial class UserManagement : Form
    {
        private string connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";

        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            LoadData(); // Kullanıcıları yükle
            sidebar1.ParentFormRef = this;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddUsersForm addUserForm = new AddUsersForm();
                addUserForm.ShowDialog();
                if (addUserForm.DialogResult == DialogResult.OK)
                {
                    LoadData(); // Veri ekledikten sonra listeyi yenile
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this data?",
                                             "Deletion Confirmation",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value.ToString();
                    using (MySqlConnection connection = new MySqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Users WHERE UserId = @Id";

                        using (MySqlCommand command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    MessageBox.Show("Data deleted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (e.ColumnIndex == dataGridView1.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                string selectedId = dataGridView1.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
                int id = Convert.ToInt32(selectedId);
                EditUserForm editForm = new EditUserForm(id);
                editForm.ShowDialog();
                if (editForm.DialogResult == DialogResult.OK)
                {
                    LoadData(); // Düzenlemeden sonra veriyi yenile
                }
            }
        }

        private void LoadData()
        {
            string query = "SELECT * FROM Users";
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        adapter.Fill(dataTable);
                    }

                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData(); // Veriyi yenile
        }
    }
}
