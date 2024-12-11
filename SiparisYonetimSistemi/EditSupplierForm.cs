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
    public partial class EditSupplierForm : Form
    {
        private int SupplierID;

        public EditSupplierForm(int supplierId)
        {
            InitializeComponent();
            this.SupplierID = supplierId;
            LoadSupplierDetails();
        }
        private void LoadSupplierDetails()
        {
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;"))
            {
                string query = @"
                select s.SupplierName, s.ContactPhone, m.Name as MaterialName, m.Unit, m.UnitPrice
                from Suppliers s
                left join Purchases p on s.SupplierID = p.SupplierID
                left join Materials m on p.MaterialID = m.MaterialID
                where s.SupplierID = @SupplierID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SupplierID", SupplierID);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // TextBox'ları doldur
                    SupplierNameBox.Text = reader["SupplierName"].ToString();
                    SupplierPhoneBox.Text = reader["ContactPhone"].ToString();
                    SupplierMaterialBox.Text = reader["MaterialName"].ToString();
                    SupplierPriceBox.Text = reader["UnitPrice"].ToString();

                    // ComboBox'u doldur ve seçili hale getir
                    SupplierUniteBox.Items.Clear();
                    SupplierUniteBox.Items.Add("kg");
                    SupplierUniteBox.Items.Add("litre");
                    SupplierUniteBox.Items.Add("piece");
                    SupplierUniteBox.Items.Add("box");

                    string unit = reader["Unit"].ToString();
                    if (SupplierUniteBox.Items.Contains(unit))
                    {
                        SupplierUniteBox.SelectedItem = unit;
                    }
                }
                conn.Close();
            }
        }

        private void EditButon_Click(object sender, EventArgs e)
        {
            string supplierName = SupplierNameBox.Text.Trim();
            string contactPhone = SupplierPhoneBox.Text.Trim();
            string materialName = SupplierMaterialBox.Text.Trim();
            string unit = SupplierUniteBox.SelectedItem?.ToString();
            decimal unitPrice;

            if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(contactPhone) ||
                string.IsNullOrWhiteSpace(materialName) || string.IsNullOrWhiteSpace(unit) ||
                !decimal.TryParse(SupplierPriceBox.Text.Trim(), out unitPrice))
            {
                MessageBox.Show("Please fill in all fields correctly!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection("Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;"))
                {
                    conn.Open();

                    // Supplier güncelle
                    string supplierQuery = @"
                update Suppliers
                set SupplierName = @SupplierName, ContactPhone = @ContactPhone
                where SupplierID = @SupplierID";
                    SqlCommand supplierCmd = new SqlCommand(supplierQuery, conn);
                    supplierCmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    supplierCmd.Parameters.AddWithValue("@ContactPhone", contactPhone);
                    supplierCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                    supplierCmd.ExecuteNonQuery();

                    // Material güncelle
                    string materialQuery = @"
                update Materials
                set Name = @MaterialName, Unit = @Unit, UnitPrice = @UnitPrice
                where MaterialID = (
                    select MaterialID from Purchases where SupplierID = @SupplierID)";
                    SqlCommand materialCmd = new SqlCommand(materialQuery, conn);
                    materialCmd.Parameters.AddWithValue("@MaterialName", materialName);
                    materialCmd.Parameters.AddWithValue("@Unit", unit);
                    materialCmd.Parameters.AddWithValue("@UnitPrice", unitPrice);
                    materialCmd.Parameters.AddWithValue("@SupplierID", SupplierID);
                    materialCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Supplier details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
