using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class SupplierManagament : Form
    {
        public SupplierManagament()
        {
            InitializeComponent();
        }

        private void LoadSuppliers()
        {
            // Veritabanı bağlantı dizesi
            string connectionString = "Server=localhost;Database=RestaurantManagement;Trusted_Connection=True;";
            string query = "SELECT p.SupplierName, m.Name AS MaterialName, m.Unit, p.UnitPrice " +
                           "FROM Purchases p " +
                           "JOIN Materials m ON p.MaterialID = m.MaterialID;";

            // DataTable oluşturuyoruz
            DataTable supplierTable = new DataTable();

            try
            {
                // Veritabanı bağlantısını aç
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // SQL sorgusunu çalıştır
                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        // Verileri DataTable'a doldur
                        adapter.Fill(supplierTable);
                    }
                }

                // DataGridView'e verileri yükle
                dataGridView1.DataSource = supplierTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler yüklenirken bir hata oluştu: " + ex.Message);
            }
        }

        private void SupplierManagament_Load(object sender, EventArgs e)
        {
            LoadSuppliers();

        }
    }
}
