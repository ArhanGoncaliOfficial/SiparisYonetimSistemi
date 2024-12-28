using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class MaterialManagament : Form
    {
        public MaterialManagament()
        {
            InitializeComponent();
        }

        private void LoadMaterials()
        {
            string query = @"
            SELECT 
                MaterialID, Name, Unit, StockQuantity
            FROM 
                Materials";

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
            {
                try
                {
                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading materials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            // AddStockForm'u aç
            AddStockForm addStockForm = new AddStockForm();
            addStockForm.ShowDialog();

            if (addStockForm.DialogResult == DialogResult.OK)
            {
                LoadMaterials(); // İşlemden sonra materyalleri güncelle
            }
        }

        private void MaterialManagament_Load_1(object sender, EventArgs e)
        {
            LoadMaterials(); // Materyalleri yükle
            sidebar1.ParentFormRef = this;
        }
    }
}
