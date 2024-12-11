using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SiparisYonetimSistemi
{
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void UserManagement_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'siparisYonetimDBDataSet.Users' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.usersTableAdapter.Fill(this.siparisYonetimDBDataSet.Users);
            // TODO: Bu kod satırı 'siparisYonetimDBDataSet.Users' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.usersTableAdapter.Fill(this.siparisYonetimDBDataSet.Users);
            sidebar1.ParentFormRef = this;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                AddUsersForm addUserForm = new AddUsersForm();
                addUserForm.Show();
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
                // Silme onayı iste
                var result = MessageBox.Show("Are you sure about want the delete this data?",
                                             "Deletion Confirmation",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Seçilen satırdaki ID değerini al
                    string id = dataGridView1.Rows[e.RowIndex].Cells["UserId"].Value.ToString();

                    // Veritabanından sil
                    string connectionString = "Server=LocalHost;Database=SiparisYonetimDB;Trusted_Connection=True;";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Users WHERE UserId = @Id";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Id", id);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }

                    // DataGridView'den satırı kaldır
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
            }

        }
        private void LoadData()
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Server=localhost;Database=SiparisYonetimDB;Trusted_Connection=True;";

            // SQL sorgusu
            string query = "SELECT * FROM Users";

            // DataTable oluşturuyoruz
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // SQL komutunu çalıştır
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dataTable); 
                    }

                    // DataGridView'e bağla
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message); // Hata mesajını göster
                }
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
