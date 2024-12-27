using MySql.Data.MySqlClient;
using SiparisYonetimSistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnaDash
{
    public partial class HomePageForm : Form
    {
        private readonly string _connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";
        private System.Windows.Forms.Timer updateTimer;
        private int currentSelectedTableId = -1; // Seçili masayı takip etmek için

        public HomePageForm()
        {
            InitializeComponent();
            InitializePaymentButton();
            AttachEventHandlersToTables();
            InitializeTimer();
            UpdateAllData();
        }

        private void HomePageForm_Load(object sender, EventArgs e)
        {
            sidebar1.ParentFormRef = this; 
        }

        private void AttachEventHandlersToTables()
        {
            // Form üzerindeki tüm kontrolleri tara
            foreach (Control control in this.Controls)
            {
                // Eğer kontrol bir buton ve ismi "table" ile başlıyorsa
                if (control is Button && control.Name.StartsWith("table"))
                {
                    // Bu butona click event'ini bağla
                    control.Click += Table_Click;
                }
            }
        }

        private void InitializeTimer()
        {
            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 5000; // 5 saniye
            updateTimer.Tick += Timer_Tick;
            updateTimer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateAllData();
        }

        private void UpdateAllData()
        {
            UpdateTableStatus();
            UpdateCounters();
        }

        private void UpdateTableStatus()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = @"
                    SELECT 
                        t.TableID,
                        CASE 
                            WHEN MAX(o.Status) = 'Hazırlanıyor' THEN 'Ordered'
                            WHEN MAX(o.Status) = 'Teslim' THEN 'Taken'
                            ELSE 'Available'
                        END as TableStatus
                    FROM (
                        SELECT 1 as TableID UNION SELECT 2 UNION SELECT 3 UNION 
                        SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION 
                        SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION 
                        SELECT 10 UNION SELECT 11 UNION SELECT 12
                    ) t
                    LEFT JOIN orders o ON t.TableID = o.TableID 
                    AND DATE(o.OrderDate) = CURDATE() 
                    AND o.Status IN ('Hazırlanıyor', 'Teslim')
                    GROUP BY t.TableID";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int tableId = reader.GetInt32("TableID");
                            string status = reader.GetString("TableStatus");
                            Button tableButton = this.Controls.Find($"table{tableId}", true).FirstOrDefault() as Button;

                            if (tableButton != null)
                            {
                                switch (status)
                                {
                                    case "Ordered":
                                        tableButton.BackColor = Color.Yellow;
                                        break;
                                    case "Taken":
                                        tableButton.BackColor = Color.Red;
                                        break;
                                    case "Available":
                                        tableButton.BackColor = Color.LimeGreen;
                                        break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Masa durumları güncellenirken hata oluştu: " + ex.Message);
                }
            }
        }
        
        private void UpdateCounters()
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = @"
            WITH TableStatuses AS (
                SELECT 
                    t.TableID,
                    CASE
                        WHEN o.Status = 'Hazırlanıyor' THEN 'Ordered'
                        WHEN o.Status = 'Teslim' THEN 'Taken'
                        ELSE 'Available'
                    END as TableStatus
                FROM (
                    SELECT 1 as TableID UNION SELECT 2 UNION SELECT 3 UNION 
                    SELECT 4 UNION SELECT 5 UNION SELECT 6 UNION 
                    SELECT 7 UNION SELECT 8 UNION SELECT 9 UNION 
                    SELECT 10 UNION SELECT 11 UNION SELECT 12
                ) t
                LEFT JOIN (
                    SELECT DISTINCT TableID, Status 
                    FROM orders 
                    WHERE DATE(OrderDate) = CURDATE() 
                    AND Status IN ('Hazırlanıyor', 'Teslim')
                    AND Status != 'Odendi'
                    GROUP BY TableID
                    HAVING MAX(CASE WHEN Status = 'Odendi' THEN 1 ELSE 0 END) = 0
                ) o ON t.TableID = o.TableID
            )
            SELECT 
                COUNT(CASE WHEN TableStatus = 'Available' THEN 1 END) as AvailableTables,
                COUNT(CASE WHEN TableStatus = 'Ordered' THEN 1 END) as OrderedTables,
                COUNT(CASE WHEN TableStatus = 'Taken' THEN 1 END) as TakenTables
            FROM TableStatuses";

                    using (var cmd = new MySqlCommand(query, connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            aval_count.Text = reader.GetInt32("AvailableTables").ToString();
                            ordered_count.Text = reader.GetInt32("OrderedTables").ToString();
                            tkn_count.Text = reader.GetInt32("TakenTables").ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sayaçlar güncellenirken hata oluştu: " + ex.Message);
                }
            }
        }
        private void Table_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                int tableId = int.Parse(clickedButton.Name.Replace("table", ""));
                ShowTableOrders(tableId);
            }
        }

        private void ShowTableOrders(int tableId)
        {
            currentSelectedTableId = tableId; // Seçili masayı kaydet
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    var query = @"
                    SELECT 
                        o.Status as OrderStatus,
                        mi.Name as FoodName,
                        od.Quantity,
                        od.Price,
                        (od.Quantity * od.Price) as TotalPrice
                    FROM orders o
                    JOIN orderdetails od ON o.OrderID = od.OrderID
                    JOIN menuitems mi ON od.MenuItemID = mi.MenuItemID
                    WHERE o.TableID = @TableId 
                    AND DATE(o.OrderDate) = CURDATE()
                    AND o.Status IN ('Hazırlanıyor', 'Teslim')";

                    using (var cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TableId", tableId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            flowLayoutPanelOrders.Controls.Clear();
                            decimal totalAmount = 0;
                            string orderStatus = "";

                            while (reader.Read())
                            {
                                orderStatus = reader["OrderStatus"].ToString();
                                Panel orderPanel = new Panel
                                {
                                    Width = flowLayoutPanelOrders.Width - 20,
                                    Height = 60,
                                    Margin = new Padding(20)
                                };

                                Label lblFoodName = new Label
                                {
                                    Text = reader["FoodName"].ToString(),
                                    Location = new Point(10, 10)
                                };

                                Label lblPrice = new Label
                                {
                                    Text = $"₺{reader["Price"].ToString()} x {reader["Quantity"].ToString()}",
                                    Location = new Point(10, 30),
                                    Margin = new Padding(20)
                                };

                                decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);
                                totalAmount += totalPrice;

                                orderPanel.Controls.Add(lblFoodName);
                                orderPanel.Controls.Add(lblPrice);
                                flowLayoutPanelOrders.Controls.Add(orderPanel);
                            }

                            lblTotal.Text = $"Toplam: ₺{totalAmount:F2}";

                            // Ödeme butonunu göster/gizle ve durumunu ayarla
                            if (paymentButton != null)
                            {
                                paymentButton.Visible = true;
                                paymentButton.Enabled = orderStatus == "Teslim";
                                paymentButton.Text = orderStatus == "Teslim" ? "Ödeme Al" : "Sipariş Teslim Edilmedi";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sipariş detayları görüntülenirken hata oluştu: " + ex.Message);
                }
            }
        }
        private void InitializePaymentButton()
        {
            paymentButton = new Button
            {
                Text = "Ödeme Al",
                Size = new Size(120, 40),
                Location = new Point(flowLayoutPanelOrders.Left + 40, flowLayoutPanelOrders.Bottom + 30),
                Enabled = false // Başlangıçta devre dışı
            };
            paymentButton.Click += PaymentButton_Click;
            this.Controls.Add(paymentButton);
        }

        private void PaymentButton_Click(object sender, EventArgs e)
        {
            if (currentSelectedTableId > 0)
            {
                var result = MessageBox.Show(
                    "Ödemeyi onaylıyor musunuz?",
                    "Ödeme Onayı",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    ProcessPayment(currentSelectedTableId);
                }
            }
        }

        private void ProcessPayment(int tableId)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Siparişleri arşivle veya sil
                            var deleteQuery = @"
                            DELETE FROM orders 
                            WHERE TableID = @TableId 
                            AND DATE(OrderDate) = CURDATE() 
                            AND Status = 'Teslim'";

                            using (var cmd = new MySqlCommand(deleteQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TableId", tableId);
                                cmd.ExecuteNonQuery();
                            }

                            transaction.Commit();

                            // UI'ı güncelle
                            UpdateAllData();
                            flowLayoutPanelOrders.Controls.Clear();
                            lblTotal.Text = "Toplam: ₺0.00";
                            if (paymentButton != null)
                            {
                                paymentButton.Visible = false;
                            }

                            MessageBox.Show("Ödeme başarıyla alındı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ödeme işlemi sırasında hata oluştu: " + ex.Message);
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            updateTimer.Stop();
            base.OnFormClosing(e);
        }
    }
}
