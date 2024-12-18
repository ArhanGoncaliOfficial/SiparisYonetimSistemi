using System;
using System.Data;
using MySql.Data.MySqlClient; // MySQL kütüphanesi
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class AddStockForm : Form
    {
        private int MaterialID;
        private string MaterialName;
        private bool isUpdating = false;

        public AddStockForm()
        {
            InitializeComponent();
        }

        public AddStockForm(int materialId, string materialName)
        {
            InitializeComponent();
            this.MaterialID = materialId;
            this.MaterialName = materialName;

            LoadSuppliers(materialId);
            MaterialComboBox.Text = materialName;
        }

        private void LoadMaterials()
        {
            string query = "SELECT MaterialID, Name FROM Materials";

            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    MaterialComboBox.Items.Clear();

                    while (reader.Read())
                    {
                        MaterialComboBox.Items.Add(new
                        {
                            Text = reader["Name"].ToString(),
                            Value = reader["MaterialID"]
                        });
                    }

                    MaterialComboBox.DisplayMember = "Text";
                    MaterialComboBox.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading materials: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadSuppliers(int materialId)
        {
            string query = @"
                SELECT 
                    sm.SupplierID, s.SupplierName, sm.UnitPrice
                FROM 
                    SupplierMaterials sm
                JOIN 
                    Suppliers s ON sm.SupplierID = s.SupplierID
                WHERE 
                    sm.MaterialID = @MaterialID";

            using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaterialID", materialId);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    SupplierComboBox.Items.Clear();

                    while (reader.Read())
                    {
                        SupplierComboBox.Items.Add(new
                        {
                            Text = $"{reader["SupplierName"]} - {reader["UnitPrice"]} per unit",
                            Value = reader["SupplierID"],
                            UnitPrice = reader["UnitPrice"]
                        });
                    }

                    SupplierComboBox.DisplayMember = "Text";
                    SupplierComboBox.ValueMember = "Value";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading suppliers: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CalculateTotalPrice()
        {
            if (SupplierComboBox.SelectedItem != null && QuantityNumericUpDown.Value > 0)
            {
                var selectedSupplier = (dynamic)SupplierComboBox.SelectedItem;
                decimal unitPrice = Convert.ToDecimal(selectedSupplier.UnitPrice);
                int quantity = (int)QuantityNumericUpDown.Value;

                decimal totalPrice = unitPrice * quantity;
                TotalPriceLabel.Text = $"Total Price: {totalPrice:C}";
            }
            else
            {
                TotalPriceLabel.Text = "Total Price: N/A";
            }
        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            if (MaterialComboBox.SelectedItem == null || SupplierComboBox.SelectedItem == null || QuantityNumericUpDown.Value <= 0)
            {
                MessageBox.Show("Please select a valid material, supplier, and enter a valid quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedMaterial = (dynamic)MaterialComboBox.SelectedItem;
            int materialId = Convert.ToInt32(selectedMaterial.Value);

            var selectedSupplier = (dynamic)SupplierComboBox.SelectedItem;
            int supplierId = Convert.ToInt32(selectedSupplier.Value);

            int quantity = (int)QuantityNumericUpDown.Value;
            decimal unitPrice = Convert.ToDecimal(selectedSupplier.UnitPrice);
            decimal totalPrice = unitPrice * quantity;

            DialogResult confirm = MessageBox.Show(
                $"Are you sure you want to buy {quantity} unit(s) of {selectedMaterial.Text} for {totalPrice:C}?",
                "Confirm Purchase",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (MySqlConnection conn = new MySqlConnection("Server=localhost; Database=SiparisYonetimDB; Uid=root; Pwd=;"))
                    {
                        conn.Open();

                        // Stok güncelle
                        string updateStockQuery = "UPDATE Materials SET StockQuantity = StockQuantity + @Quantity WHERE MaterialID = @MaterialID";
                        MySqlCommand updateStockCmd = new MySqlCommand(updateStockQuery, conn);
                        updateStockCmd.Parameters.AddWithValue("@Quantity", quantity);
                        updateStockCmd.Parameters.AddWithValue("@MaterialID", materialId);
                        updateStockCmd.ExecuteNonQuery();

                        // Purchases tablosuna kayıt
                        string purchaseQuery = @"
                        insert into Purchases (MaterialID, SupplierID, Quantity, UnitPrice, PurchaseDate)
                        values (@MaterialID, @SupplierID, @Quantity, @UnitPrice, NOW())";
                        MySqlCommand purchaseCmd = new MySqlCommand(purchaseQuery, conn);
                        purchaseCmd.Parameters.AddWithValue("@MaterialID", materialId);
                        purchaseCmd.Parameters.AddWithValue("@SupplierID", supplierId);
                        purchaseCmd.Parameters.AddWithValue("@Quantity", quantity);
                        purchaseCmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                        purchaseCmd.Parameters.AddWithValue("@TotalPrice", totalPrice);
                        purchaseCmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Stock added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding stock: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddStockForm_Load(object sender, EventArgs e)
        {
            LoadMaterials();
            LoadSuppliers(MaterialID);
            QuantityNumericUpDown.Minimum = 1;
        }

        private void MaterialComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MaterialComboBox.SelectedItem != null)
            {
                var selectedMaterial = (dynamic)MaterialComboBox.SelectedItem;
                int materialId = Convert.ToInt32(selectedMaterial.Value);
                LoadSuppliers(materialId);
            }
        }

        private void SupplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void QuantityNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void MaterialComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (MaterialComboBox.SelectedItem != null)
            {
                var selectedMaterial = (dynamic)MaterialComboBox.SelectedItem;
                int materialId = Convert.ToInt32(selectedMaterial.Value);

                LoadSuppliers(materialId);
            }
        }

        private void SupplierComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void QuantityNumericUpDown_ValueChanged_1(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

    }
}
