using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class EditSupplierForm : Form
    {
        private int SupplierMaterialID;

        public EditSupplierForm(int supplierMaterialId)
        {
            InitializeComponent();
            this.SupplierMaterialID = supplierMaterialId;
            LoadSupplierMaterialDetails();
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
                    MaterialNameBox.Items.Clear();

                    while (reader.Read())
                    {
                        MaterialNameBox.Items.Add(new
                        {
                            Text = reader["Name"].ToString(),
                            Value = reader["MaterialID"].ToString()
                        });
                    }

                    MaterialNameBox.DisplayMember = "Text";
                    MaterialNameBox.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading materials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSupplierMaterialDetails()
        {
            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
            {
                string query = @"
                SELECT sm.SupplierMaterialID, s.SupplierName, s.ContactPhone, m.MaterialID, m.Name as MaterialName, sm.UnitPrice
                FROM SupplierMaterials sm
                JOIN Suppliers s ON sm.SupplierID = s.SupplierID
                JOIN Materials m ON sm.MaterialID = m.MaterialID
                WHERE sm.SupplierMaterialID = ?SupplierMaterialID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("?SupplierMaterialID", SupplierMaterialID);

                try
                {
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        SupplierNameBox.Text = reader["SupplierName"].ToString();
                        SupplierPhoneBox.Text = reader["ContactPhone"].ToString();
                        SupplierPriceBox.Text = reader["UnitPrice"].ToString();

                        LoadMaterials();
                        MaterialNameBox.SelectedValue = reader["MaterialID"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading supplier details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void EditButon_Click(object sender, EventArgs e)
        {
            string supplierName = SupplierNameBox.Text.Trim();
            string contactPhone = SupplierPhoneBox.Text.Trim();
            var selectedMaterial = MaterialNameBox.SelectedItem;
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

                    string supplierQuery = @"
                    UPDATE Suppliers
                    SET SupplierName = ?SupplierName, ContactPhone = ?ContactPhone
                    WHERE SupplierID = (SELECT SupplierID FROM SupplierMaterials WHERE SupplierMaterialID = ?SupplierMaterialID)";
                    MySqlCommand supplierCmd = new MySqlCommand(supplierQuery, conn);
                    supplierCmd.Parameters.AddWithValue("?SupplierName", supplierName);
                    supplierCmd.Parameters.AddWithValue("?ContactPhone", contactPhone);
                    supplierCmd.Parameters.AddWithValue("?SupplierMaterialID", SupplierMaterialID);
                    supplierCmd.ExecuteNonQuery();

                    string supplierMaterialQuery = @"
                    UPDATE SupplierMaterials
                    SET MaterialID = ?MaterialID, UnitPrice = ?UnitPrice
                    WHERE SupplierMaterialID = ?SupplierMaterialID";
                    MySqlCommand supplierMaterialCmd = new MySqlCommand(supplierMaterialQuery, conn);
                    supplierMaterialCmd.Parameters.AddWithValue("?MaterialID", ((dynamic)selectedMaterial).Value);
                    supplierMaterialCmd.Parameters.AddWithValue("?UnitPrice", unitPrice);
                    supplierMaterialCmd.Parameters.AddWithValue("?SupplierMaterialID", SupplierMaterialID);
                    supplierMaterialCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier and material details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating supplier material details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditSupplierForm_Load(object sender, EventArgs e)
        {
            SupplierUniteBox.Items.Add("kg");
            SupplierUniteBox.SelectedIndex = 0;
        }
    }
}
