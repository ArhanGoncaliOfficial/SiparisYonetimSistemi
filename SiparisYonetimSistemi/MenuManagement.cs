using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Microsoft.VisualBasic;

namespace SiparisYonetimSistemi
{
    public partial class MenuYonetimFormu : Form
    {
        private readonly string _connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";

        public MenuYonetimFormu()
        {
            InitializeComponent();
            ConfigureDataGridView();
            LoadMenuItems();
            AttachEventHandlers();
        }

        private void ConfigureDataGridView()
        {
            dataGridView_MenuTable.AutoGenerateColumns = false;

            // DataGridView sütunlarını manuel olarak tanımla
            DataGridViewTextBoxColumn menuItemIdColumn = new DataGridViewTextBoxColumn();
            menuItemIdColumn.DataPropertyName = "MenuItemID";
            menuItemIdColumn.HeaderText = "ID";
            menuItemIdColumn.Name = "MenuItemID";
            menuItemIdColumn.ReadOnly = true;
            dataGridView_MenuTable.Columns.Add(menuItemIdColumn);

            DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
            nameColumn.DataPropertyName = "Name";
            nameColumn.HeaderText = "Name";
            nameColumn.Name = "Name";
            dataGridView_MenuTable.Columns.Add(nameColumn);

            DataGridViewTextBoxColumn categoryColumn = new DataGridViewTextBoxColumn();
            categoryColumn.DataPropertyName = "Category";
            categoryColumn.HeaderText = "Category";
            categoryColumn.Name = "Category";
            dataGridView_MenuTable.Columns.Add(categoryColumn);

            DataGridViewTextBoxColumn priceColumn = new DataGridViewTextBoxColumn();
            priceColumn.DataPropertyName = "Price";
            priceColumn.HeaderText = "Price";
            priceColumn.Name = "Price";
            dataGridView_MenuTable.Columns.Add(priceColumn);

            DataGridViewTextBoxColumn descriptionColumn = new DataGridViewTextBoxColumn();
            descriptionColumn.DataPropertyName = "Description";
            descriptionColumn.HeaderText = "Description";
            descriptionColumn.Name = "Description";
            dataGridView_MenuTable.Columns.Add(descriptionColumn);

            // Edit butonu sütunu
            DataGridViewButtonColumn editColumn = new DataGridViewButtonColumn();
            editColumn.HeaderText = "Edit";
            editColumn.Text = "Edit";
            editColumn.Name = "EditButton";
            editColumn.UseColumnTextForButtonValue = true;
            dataGridView_MenuTable.Columns.Add(editColumn);

            // Delete butonu sütunu
            DataGridViewButtonColumn deleteColumn = new DataGridViewButtonColumn();
            deleteColumn.HeaderText = "Delete";
            deleteColumn.Text = "Delete";
            deleteColumn.Name = "DeleteButton";
            deleteColumn.UseColumnTextForButtonValue = true;
            dataGridView_MenuTable.Columns.Add(deleteColumn);
        }

        private void AttachEventHandlers()
        {
            dataGridView_MenuTable.CellClick += DataGridView_MenuTable_CellClick;
            addMenuItemButton.Click += AddMenuItemButton_Click;
        }

        private void LoadMenuItems()
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT MenuItemID, Name, Category, Price, Description FROM MenuItems";

                    using (var adapter = new MySqlDataAdapter(query, connection))
                    {
                        var menuItemsTable = new DataTable();
                        adapter.Fill(menuItemsTable);
                        dataGridView_MenuTable.DataSource = menuItemsTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Menü yüklenirken hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridView_MenuTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Edit butonuna tıklanması
            if (e.ColumnIndex == dataGridView_MenuTable.Columns["EditButton"].Index && e.RowIndex >= 0)
            {
                int menuItemId = Convert.ToInt32(dataGridView_MenuTable.Rows[e.RowIndex].Cells["MenuItemID"].Value);
                string name = dataGridView_MenuTable.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string category = dataGridView_MenuTable.Rows[e.RowIndex].Cells["Category"].Value.ToString();
                decimal price = Convert.ToDecimal(dataGridView_MenuTable.Rows[e.RowIndex].Cells["Price"].Value);
                string description = dataGridView_MenuTable.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                // Düzenleme formu açma veya mevcut form üzerinde düzenleme yapma
                EditMenuItem(menuItemId, name, category, price, description);
            }

            // Delete butonuna tıklanması
            if (e.ColumnIndex == dataGridView_MenuTable.Columns["DeleteButton"].Index && e.RowIndex >= 0)
            {
                int menuItemId = Convert.ToInt32(dataGridView_MenuTable.Rows[e.RowIndex].Cells["MenuItemID"].Value);
                DeleteMenuItem(menuItemId);
            }
        }

        private void EditMenuItem(int menuItemId, string name, string category, decimal price, string description)
        {
            try
            {
                using (var connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"UPDATE MenuItems 
                                     SET Name = @Name, 
                                         Category = @Category, 
                                         Price = @Price, 
                                         Description = @Description 
                                     WHERE MenuItemID = @MenuItemID";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MenuItemID", menuItemId);
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Category", category);
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@Description", description);

                        command.ExecuteNonQuery();
                    }

                    LoadMenuItems();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Güncelleme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteMenuItem(int menuItemId)
        {
            DialogResult result = MessageBox.Show("Bu öğeyi silmek istediğinizden emin misiniz?", "Silme Onayı",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();
                        string query = "DELETE FROM MenuItems WHERE MenuItemID = @MenuItemID";

                        using (var command = new MySqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@MenuItemID", menuItemId);
                            command.ExecuteNonQuery();
                        }

                        LoadMenuItems();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AddMenuItemButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Menu Item button clicked!");
            // Yeni menü öğesi ekleme formu açma
            AddNewMenuItem addNewMenuItemForm = new AddNewMenuItem();
            addNewMenuItemForm.Show();
        }

        private void InitializeComponent()
        {
            this.dataGridView_MenuTable = new System.Windows.Forms.DataGridView();
            this.menuManagementHeader = new System.Windows.Forms.Label();
            this.sidebar3 = new SiparisYonetimSistemi.sidebar();
            this.addMenuItemButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MenuTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_MenuTable
            // 
            this.dataGridView_MenuTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_MenuTable.Location = new System.Drawing.Point(221, 63);
            this.dataGridView_MenuTable.Name = "dataGridView_MenuTable";
            this.dataGridView_MenuTable.RowHeadersWidth = 51;
            this.dataGridView_MenuTable.Size = new System.Drawing.Size(630, 350);
            this.dataGridView_MenuTable.TabIndex = 1;
            // 
            // menuManagementHeader
            // 
            this.menuManagementHeader.AutoSize = true;
            this.menuManagementHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuManagementHeader.Location = new System.Drawing.Point(217, 26);
            this.menuManagementHeader.Name = "menuManagementHeader";
            this.menuManagementHeader.Size = new System.Drawing.Size(219, 29);
            this.menuManagementHeader.TabIndex = 2;
            this.menuManagementHeader.Tag = "";
            this.menuManagementHeader.Text = "Menu Management";
            // 
            // sidebar3
            // 
            this.sidebar3.Location = new System.Drawing.Point(0, 0);
            this.sidebar3.Margin = new System.Windows.Forms.Padding(2);
            this.sidebar3.Name = "sidebar3";
            this.sidebar3.ParentFormRef = null;
            this.sidebar3.Size = new System.Drawing.Size(186, 510);
            this.sidebar3.TabIndex = 0;
            // 
            // addMenuItemButton
            // 
            this.addMenuItemButton.Location = new System.Drawing.Point(763, 419);
            this.addMenuItemButton.Name = "addMenuItemButton";
            this.addMenuItemButton.Size = new System.Drawing.Size(88, 23);
            this.addMenuItemButton.TabIndex = 3;
            this.addMenuItemButton.Text = "Add Menu Item";
            this.addMenuItemButton.UseVisualStyleBackColor = true;
            // 
            // MenuYonetimFormu
            // 
            this.ClientSize = new System.Drawing.Size(886, 510);
            this.Controls.Add(this.addMenuItemButton);
            this.Controls.Add(this.menuManagementHeader);
            this.Controls.Add(this.dataGridView_MenuTable);
            this.Controls.Add(this.sidebar3);
            this.Name = "MenuYonetimFormu";
            this.Load += new System.EventHandler(this.MenuYonetimFormu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MenuTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void MenuYonetimFormu_Load(object sender, EventArgs e)
        {
            //sidebar1.ParentFormRef = this;
        }
    }
}