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
    public partial class SupplierAdd : Form
    {
        public SupplierAdd()
        {
            InitializeComponent();
        }

        private void SupplierAdd_Load(object sender, EventArgs e)
        {
            // Unit ComboBox'u doldur
            SupplierUniteBox.Items.Add("kg");
            SupplierUniteBox.Items.Add("litre");
            SupplierUniteBox.Items.Add("piece");
            SupplierUniteBox.Items.Add("box");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string supplierName = SupplierNameBox.Text.Trim();
            string contactPhone = SupplierPhoneBox.Text.Trim();
            string materialName = SupplierMaterialBox.Text.Trim();
            string unit = SupplierUniteBox.SelectedItem?.ToString();
            decimal unitPrice;

            // Gerekli alanları kontrol et
            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactPhone) ||
                string.IsNullOrWhiteSpace(materialName) || string.IsNullOrWhiteSpace(unit) ||
                !decimal.TryParse(SupplierPriceBox.Text.Trim(), out unitPrice))
            {
                MessageBox.Show("Please fill in all fields correctly!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Veritabanına bağlan ve ekle
                using (SqlConnection conn = new SqlConnection("Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;"))
                {
                    conn.Open();

                    // Supplier ekle
                    string supplierQuery = @"
                insert into Suppliers (SupplierName, ContactPhone)
                values (@SupplierName, @ContactPhone);
                select scope_identity();"; // Yeni eklenen SupplierID'yi alır
                    SqlCommand supplierCmd = new SqlCommand(supplierQuery, conn);
                    supplierCmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    supplierCmd.Parameters.AddWithValue("@ContactPhone", contactPhone);
                    int supplierId = Convert.ToInt32(supplierCmd.ExecuteScalar());

                    // Material ekle
                    string materialQuery = @"
                insert into Materials (Name, Unit, UnitPrice)
                values (@MaterialName, @Unit, @UnitPrice);
                select scope_identity();"; // Yeni eklenen MaterialID'yi alır
                    SqlCommand materialCmd = new SqlCommand(materialQuery, conn);
                    materialCmd.Parameters.AddWithValue("@MaterialName", materialName);
                    materialCmd.Parameters.AddWithValue("@Unit", unit);
                    materialCmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    int materialId = Convert.ToInt32(materialCmd.ExecuteScalar());

                    // Purchase bağlantısı ekle
                    string purchaseQuery = @"
                insert into Purchases (MaterialID, SupplierID, Quantity, UnitPrice, TotalPrice, PurchaseDate)
                values (@MaterialID, @SupplierID, @Quantity, @UnitPrice, @TotalPrice, GETDATE());";
                    SqlCommand purchaseCmd = new SqlCommand(purchaseQuery, conn);
                    purchaseCmd.Parameters.AddWithValue("@MaterialID", materialId);
                    purchaseCmd.Parameters.AddWithValue("@SupplierID", supplierId);
                    purchaseCmd.Parameters.AddWithValue("@Quantity", 0); // Varsayılan 0
                    purchaseCmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    purchaseCmd.Parameters.AddWithValue("@TotalPrice", 0); // Varsayılan 0
                    purchaseCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier and material added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Ana forma değişiklik bildirimi gönder
                this.Close(); // Formu kapat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
