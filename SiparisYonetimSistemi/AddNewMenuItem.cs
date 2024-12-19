using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class AddNewMenuItem : Form
    {
        private readonly string _connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;SslMode=none;";

        // MaterialID'leri sabit olarak tanımlayalım
        private readonly Dictionary<string, int> materialIds = new Dictionary<string, int>()
        {
            {"Tavuk", 1},
            {"Pirinç", 2},
            {"Soğan", 3},
            {"Sarımsak", 4},
            {"Domates", 5},
            {"Salatalık", 6},
            {"Biber", 7},
            {"Et", 8},
            {"Makarna", 9},
            {"Roka", 10}
        };

        public AddNewMenuItem()
        {
            InitializeComponent();
            addMenuItem.Click += addMenuItem_Click;
        }

        private void addMenuItem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    MySqlTransaction transaction = connection.BeginTransaction();

                    try
                    {
                        // 1. Önce MenuItem'ı ekle
                        int menuItemId = InsertMenuItem(connection, transaction);

                        // 2. Seçili malzemeleri MenuMaterials tablosuna ekle
                        InsertMenuMaterials(connection, transaction, menuItemId);

                        transaction.Commit();
                        MessageBox.Show("Menü öğesi başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("İşlem sırasında hata oluştu: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int InsertMenuItem(MySqlConnection connection, MySqlTransaction transaction)
        {
            string query = @"INSERT INTO menuitems (Name, Category, Price, Description) 
                           VALUES (@Name, @Category, @Price, @Description);
                           SELECT LAST_INSERT_ID();";

            using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@Name", menuItemNameInput.Text.Trim());
                command.Parameters.AddWithValue("@Category", menuItemCategoryInput.Text.Trim());
                command.Parameters.AddWithValue("@Description", menuItemDescriptionInput.Text.Trim());
                command.Parameters.AddWithValue("@Price", decimal.Parse(menuItemPriceInput.Text.Trim()));

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertMenuMaterials(MySqlConnection connection, MySqlTransaction transaction, int menuItemId)
        {
            var selectedMaterials = new Dictionary<string, string>();
            if (tavuk.Checked) selectedMaterials["Tavuk"] = tavukInput.Text.Trim();
            if (pirinc.Checked) selectedMaterials["Pirinç"] = pirincInput.Text.Trim();
            if (sogan.Checked) selectedMaterials["Soğan"] = soganInput.Text.Trim();
            if (sarimsak.Checked) selectedMaterials["Sarımsak"] = sarimsakInput.Text.Trim();
            if (domates.Checked) selectedMaterials["Domates"] = domatesInput.Text.Trim();
            if (salatalik.Checked) selectedMaterials["Salatalık"] = salatalikInput.Text.Trim();
            if (biber.Checked) selectedMaterials["Biber"] = biberInput.Text.Trim();
            if (et.Checked) selectedMaterials["Et"] = etInput.Text.Trim();
            if (makarna.Checked) selectedMaterials["Makarna"] = makarnaInput.Text.Trim();
            if (roka.Checked) selectedMaterials["Roka"] = rokaInput.Text.Trim();

            string query = @"INSERT INTO menumaterials (MenuItemID, MaterialID, Quantity) 
                           VALUES (@MenuItemID, @MaterialID, @Quantity)";

            foreach (var material in selectedMaterials)
            {
                if (materialIds.TryGetValue(material.Key, out int materialId))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection, transaction))
                    {
                        command.Parameters.AddWithValue("@MenuItemID", menuItemId);
                        command.Parameters.AddWithValue("@MaterialID", materialId);
                        command.Parameters.AddWithValue("@Quantity", decimal.Parse(material.Value));
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(menuItemNameInput.Text))
            {
                MessageBox.Show("İsim alanı boş bırakılamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(menuItemCategoryInput.Text))
            {
                MessageBox.Show("Kategori alanı boş bırakılamaz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(menuItemPriceInput.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Geçerli bir fiyat giriniz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Seçili malzemelerin miktarlarını kontrol et
            var selectedMaterials = new Dictionary<string, TextBox>();
            if (tavuk.Checked) selectedMaterials["Tavuk"] = tavukInput;
            if (pirinc.Checked) selectedMaterials["Pirinç"] = pirincInput;
            if (sogan.Checked) selectedMaterials["Soğan"] = soganInput;
            if (sarimsak.Checked) selectedMaterials["Sarımsak"] = sarimsakInput;
            if (domates.Checked) selectedMaterials["Domates"] = domatesInput;
            if (salatalik.Checked) selectedMaterials["Salatalık"] = salatalikInput;
            if (biber.Checked) selectedMaterials["Biber"] = biberInput;
            if (et.Checked) selectedMaterials["Et"] = etInput;
            if (makarna.Checked) selectedMaterials["Makarna"] = makarnaInput;
            if (roka.Checked) selectedMaterials["Roka"] = rokaInput;

            foreach (var material in selectedMaterials)
            {
                if (string.IsNullOrWhiteSpace(material.Value.Text))
                {
                    MessageBox.Show($"{material.Key} için miktar girilmelidir.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (!decimal.TryParse(material.Value.Text, out decimal quantity) || quantity <= 0)
                {
                    MessageBox.Show($"{material.Key} için geçerli bir miktar giriniz.", "Doğrulama Hatası", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void ClearForm()
        {
            menuItemNameInput.Clear();
            menuItemCategoryInput.Clear();
            menuItemDescriptionInput.Clear();
            menuItemPriceInput.Clear();

            // Malzeme inputlarını temizle
            tavukInput.Clear();
            pirincInput.Clear();
            soganInput.Clear();
            sarimsakInput.Clear();
            domatesInput.Clear();
            salatalikInput.Clear();
            biberInput.Clear();
            etInput.Clear();
            makarnaInput.Clear();
            rokaInput.Clear();

            // Checkboxları temizle
            tavuk.Checked = false;
            pirinc.Checked = false;
            sogan.Checked = false;
            sarimsak.Checked = false;
            domates.Checked = false;
            salatalik.Checked = false;
            biber.Checked = false;
            et.Checked = false;
            makarna.Checked = false;
            roka.Checked = false;
        }
    }
}