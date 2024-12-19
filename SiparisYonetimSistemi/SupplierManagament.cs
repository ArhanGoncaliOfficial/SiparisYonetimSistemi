using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            string query = @"
            SELECT 
                sm.SupplierMaterialID,
                s.SupplierName,
                s.ContactPhone,
                m.Name AS MaterialName,
                sm.UnitPrice
            FROM 
                SupplierMaterials sm
            JOIN 
                Suppliers s ON sm.SupplierID = s.SupplierID
            JOIN 
                Materials m ON sm.MaterialID = m.MaterialID";

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
            {
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                da.Fill(dt);
            }

            dataGridView1.DataSource = dt;
            dataGridView1.AutoGenerateColumns = true;

            // Edit butonunu ekle
            if (!dataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.HeaderText = "Edit";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                editButton.FlatStyle = FlatStyle.Standard;
                dataGridView1.Columns.Add(editButton);
            }

            // Remove butonunu ekle
            if (!dataGridView1.Columns.Contains("Remove"))
            {
                DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn();
                removeButton.Name = "Remove";
                removeButton.HeaderText = "Remove";
                removeButton.Text = "Remove";
                removeButton.UseColumnTextForButtonValue = true;
                removeButton.FlatStyle = FlatStyle.Standard;
                dataGridView1.Columns.Add(removeButton);
            }
        }

        private void SupplierManagament_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            sidebar1.ParentFormRef = this;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SupplierAdd addSupplierMaterialForm = new SupplierAdd();
            addSupplierMaterialForm.ShowDialog();

            if (addSupplierMaterialForm.DialogResult == DialogResult.OK)
            {
                LoadSuppliers();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                int supplierMaterialId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SupplierMaterialID"].Value);
                EditSupplierForm editForm = new EditSupplierForm(supplierMaterialId);
                editForm.ShowDialog();

                if (editForm.DialogResult == DialogResult.OK)
                {
                    LoadSuppliers();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Remove")
            {
                int supplierMaterialId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SupplierMaterialID"].Value);
                DialogResult confirm = MessageBox.Show("Are you sure to delete this entry?", "Confirm", MessageBoxButtons.YesNo);

                if (confirm == DialogResult.Yes)
                {
                    try
                    {
                        using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
                        {
                            string query = "DELETE FROM SupplierMaterials WHERE SupplierMaterialID = @SupplierMaterialID";
                            MySqlCommand cmd = new MySqlCommand(query, conn);
                            cmd.Parameters.AddWithValue("@SupplierMaterialID", supplierMaterialId);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                        LoadSuppliers();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
