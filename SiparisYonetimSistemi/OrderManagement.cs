using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class OrderManagement : Form
    {
        private readonly string _connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;SslMode=none;";

        public OrderManagement()
        {
            InitializeComponent();
            this.Load += OrderManagement_Load;
            refreshButton.Click += RefreshButton_Click;
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dataGridView_OrderManagement.AutoGenerateColumns = false;
            dataGridView_OrderManagement.AllowUserToAddRows = false;
            dataGridView_OrderManagement.ReadOnly = true;
            dataGridView_OrderManagement.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_OrderManagement.MultiSelect = false;
            dataGridView_OrderManagement.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView_OrderManagement.Columns.Clear();
            dataGridView_OrderManagement.Columns.AddRange(
                new DataGridViewTextBoxColumn
                {
                    Name = "OrderID",
                    HeaderText = "Sipariş No",
                    DataPropertyName = "OrderID"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OrderDate",
                    HeaderText = "Sipariş Tarihi",
                    DataPropertyName = "OrderDate"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TableID",
                    HeaderText = "Masa No",
                    DataPropertyName = "TableID"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "OrderDetails",
                    HeaderText = "Sipariş Detayları",
                    DataPropertyName = "OrderDetails"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "TotalAmount",
                    HeaderText = "Toplam Tutar",
                    DataPropertyName = "TotalAmount",
                    DefaultCellStyle = new DataGridViewCellStyle { Format = "N2" }
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "FormattedTotal",
                    HeaderText = "Toplam Tutar",
                    DataPropertyName = "FormattedTotal"
                },
                new DataGridViewTextBoxColumn
                {
                    Name = "Status",
                    HeaderText = "Durum",
                    DataPropertyName = "Status"
                },
                new DataGridViewButtonColumn
                {
                    Name = "DeliveryButton",
                    HeaderText = "Teslim Et",
                    Text = "Teslim Et",
                    UseColumnTextForButtonValue = true
                }
            );

            // Buton tıklama olayını ekle
            dataGridView_OrderManagement.CellClick += DataGridView_OrderManagement_CellClick;
        }

        private void OrderManagement_Load(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            LoadOrderData();
        }

        private void DataGridView_OrderManagement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Teslim Et butonuna tıklandığında
            if (e.ColumnIndex == dataGridView_OrderManagement.Columns["DeliveryButton"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_OrderManagement.Rows[e.RowIndex];
                string currentStatus = row.Cells["Status"].Value.ToString();
                int orderId = Convert.ToInt32(row.Cells["OrderID"].Value);

                // Eğer sipariş zaten teslim edilmişse, işlem yapma
                if (currentStatus.Equals("Teslim", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Bu sipariş zaten teslim edilmiş.",
                                  "Bilgi",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Kullanıcıya onay sor
                var result = MessageBox.Show("Bu siparişi teslim etmek istediğinizden emin misiniz?",
                                           "Onay",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    UpdateOrderStatus(orderId);
                }
            }
        }

        private void UpdateOrderStatus(int orderId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string updateQuery = "UPDATE orders SET Status = 'Teslim' WHERE OrderID = @OrderID";

                    using (MySqlCommand command = new MySqlCommand(updateQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderId);
                        command.ExecuteNonQuery();
                    }
                }

                // Verileri yenile
                LoadOrderData();
                MessageBox.Show("Sipariş başarıyla teslim edildi.",
                              "Başarılı",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş durumu güncellenirken bir hata oluştu: {ex.Message}",
                              "Hata",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void LoadOrderData()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            o.OrderID,
                            o.OrderDate,
                            o.TableID,
                            o.Status,
                            GROUP_CONCAT(
                                CONCAT(
                                    m.Name,
                                    ' x',
                                    od.Quantity,
                                    ' (',
                                    FORMAT(od.Price * od.Quantity, 2),
                                    ' TL)'
                                )
                                SEPARATOR ', '
                            ) as OrderDetails,
                            CAST(SUM(od.Price * od.Quantity) AS DECIMAL(10,2)) as TotalAmount
                        FROM orders o
                        JOIN orderdetails od ON o.OrderID = od.OrderID
                        JOIN menuitems m ON od.MenuItemID = m.MenuItemID
                        GROUP BY o.OrderID, o.OrderDate, o.TableID, o.Status
                        ORDER BY o.OrderDate DESC";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dataTable.Columns.Add("FormattedTotal", typeof(string));

                        foreach (DataRow row in dataTable.Rows)
                        {
                            decimal totalAmount = Convert.ToDecimal(row["TotalAmount"]);
                            row["FormattedTotal"] = $"{totalAmount:N2} TL";
                        }

                        dataGridView_OrderManagement.DataSource = dataTable;

                        // Teslim edilmiş siparişlerin butonlarını devre dışı bırak
                        foreach (DataGridViewRow row in dataGridView_OrderManagement.Rows)
                        {
                            if (row.Cells["Status"].Value.ToString().Equals("Teslim", StringComparison.OrdinalIgnoreCase))
                            {
                                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)row.Cells["DeliveryButton"];
                                buttonCell.Style.BackColor = System.Drawing.Color.LightGray;
                                buttonCell.Style.ForeColor = System.Drawing.Color.DarkGray;
                                buttonCell.FlatStyle = FlatStyle.Flat;
                            }
                        }
                    }
                }

                dataGridView_OrderManagement.Columns["TotalAmount"].Visible = false;
                dataGridView_OrderManagement.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veriler yüklenirken bir hata oluştu: {ex.Message}",
                              "Hata",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        // İsteğe bağlı: Seçili siparişin detaylarını göster
        private void dataGridView_OrderManagement_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int orderId = Convert.ToInt32(dataGridView_OrderManagement.Rows[e.RowIndex].Cells["OrderID"].Value);
                ShowOrderDetails(orderId);
            }
        }

        private void ShowOrderDetails(int orderId)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            m.Name,
                            od.Quantity,
                            od.Price,
                            (od.Price * od.Quantity) as SubTotal
                        FROM orderdetails od
                        JOIN menuitems m ON od.MenuItemID = m.MenuItemID
                        WHERE od.OrderID = @OrderID";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderId);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            string details = $"Sipariş No: {orderId}\n\n";
                            decimal total = 0;

                            while (reader.Read())
                            {
                                string name = reader["Name"].ToString();
                                int quantity = Convert.ToInt32(reader["Quantity"]);
                                decimal price = Convert.ToDecimal(reader["Price"]);
                                decimal subTotal = Convert.ToDecimal(reader["SubTotal"]);

                                details += $"{name} x {quantity} = {subTotal:N2} TL\n";
                                total += subTotal;
                            }

                            details += $"\nToplam: {total:N2} TL";

                            MessageBox.Show(details, "Sipariş Detayları",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sipariş detayları gösterilirken bir hata oluştu: {ex.Message}",
                              "Hata",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void OrderManagement_Load_1(object sender, EventArgs e)
        {
            sidebar1.ParentFormRef = this;
        }
    }
}