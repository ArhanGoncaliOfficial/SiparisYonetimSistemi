using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class SupplierAdd : Form
    {
        public SupplierAdd()
        {
            InitializeComponent();
        }

        private void SupplierAdd_Load(object sender, EventArgs e)
        {
            // Material ComboBox'ı doldur
            LoadMaterials();

            // Tab index ayarları
            SupplierNameBox.TabIndex = 0;
            SupplierPhoneBox.TabIndex = 1;
            MaterialComboBox.TabIndex = 2;
            SupplierPriceBox.TabIndex = 3;
            AddButton.TabIndex = 4;
            SupplierUniteBox.Items.Add("kg");
            SupplierUniteBox.SelectedIndex = 0;
        }

        private void LoadMaterials()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
            {
                string query = "SELECT MaterialID, Name FROM Materials";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    MaterialComboBox.Items.Clear();

                    // Material verilerini ComboBox'a ekle
                    while (reader.Read())
                    {
                        MaterialComboBox.Items.Add(new
                        {
                            Text = reader["Name"].ToString(),
                            Value = reader["MaterialID"].ToString()
                        });
                    }

                    // ComboBox'ın Display ve ValueMember ayarlarını yap
                    MaterialComboBox.DisplayMember = "Text";
                    MaterialComboBox.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading materials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string supplierName = SupplierNameBox.Text.Trim();
            string contactPhone = SupplierPhoneBox.Text.Trim();
            var selectedMaterial = MaterialComboBox.SelectedItem;
            decimal unitPrice;

            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactPhone) ||
                selectedMaterial == null || !decimal.TryParse(SupplierPriceBox.Text.Trim(), out unitPrice))
            {
                MessageBox.Show("Please fill in all fields correctly!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
                {
                    conn.Open();

                    // Supplier ekle
                    string supplierQuery = @"
                    INSERT INTO Suppliers (SupplierName, ContactPhone)
                    VALUES (?SupplierName, ?ContactPhone);
                    SELECT LAST_INSERT_ID();";
                    MySqlCommand supplierCmd = new MySqlCommand(supplierQuery, conn);
                    supplierCmd.Parameters.AddWithValue("?SupplierName", supplierName);
                    supplierCmd.Parameters.AddWithValue("?ContactPhone", contactPhone);
                    int supplierId = Convert.ToInt32(supplierCmd.ExecuteScalar());

                    // SupplierMaterial ekle
                    string supplierMaterialQuery = @"
                    INSERT INTO SupplierMaterials (SupplierID, MaterialID, UnitPrice)
                    VALUES (?SupplierID, ?MaterialID, ?UnitPrice);";
                    MySqlCommand supplierMaterialCmd = new MySqlCommand(supplierMaterialQuery, conn);
                    supplierMaterialCmd.Parameters.AddWithValue("?SupplierID", supplierId);
                    supplierMaterialCmd.Parameters.AddWithValue("?MaterialID", ((dynamic)selectedMaterial).Value);
                    supplierMaterialCmd.Parameters.AddWithValue("?UnitPrice", unitPrice);
                    supplierMaterialCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier and material link added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
