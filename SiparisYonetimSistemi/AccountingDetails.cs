using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SiparisYonetimSistemi
{
    public partial class AccountingDetails : Form
    {
        private readonly string connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";
        private DataTable transactionsData;

        public AccountingDetails()
        {
            InitializeComponent();
        }

        private void AccountingDetails_Load(object sender, EventArgs e)
        {
            InitializeControls();
            LoadComboBoxItems();
            LoadData();
            sidebar1.ParentFormRef = this;
        }

        private void InitializeControls()
        {
            // DateTimePicker varsayılan değerleri
            TimeBoxStart.Value = DateTime.Today.AddMonths(-1);
            TimeBoxFinish.Value = DateTime.Today;

            // DataGridView ayarları
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ReadOnly = true;
        }

        private void LoadComboBoxItems()
        {
            try
            {
                // Transaction Type ComboBox
                SellOrBuyCombobox.Items.Clear();
                SellOrBuyCombobox.Items.AddRange(new string[] { "All Transactions", "Sales", "Purchases" });
                SellOrBuyCombobox.SelectedIndex = 0;

                // Product ComboBox
                comboBoxProducterName.Items.Clear();
                comboBoxProducterName.Items.Add("All Products");

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                        SELECT DISTINCT Name 
                        FROM (
                            SELECT Name FROM Materials 
                            UNION 
                            SELECT Name FROM MenuItems
                        ) AS CombinedProducts 
                        ORDER BY Name;";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBoxProducterName.Items.Add(reader.GetString("Name"));
                        }
                    }
                }
                comboBoxProducterName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading combo box items: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData(string transactionType = null, string productName = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            try
            {
                string query = @"
                    SELECT 
                        TransactionType,
                        ProductName,
                        Quantity,
                        UnitPrice,
                        TotalPrice,
                        Date
                    FROM (
                        SELECT 
                            'Sales' AS TransactionType,
                            mi.Name AS ProductName,
                            od.Quantity,
                            od.Price AS UnitPrice,
                            (od.Quantity * od.Price) AS TotalPrice,
                            o.OrderDate AS Date
                        FROM Orders o
                        JOIN OrderDetails od ON o.OrderID = od.OrderID
                        JOIN MenuItems mi ON od.MenuItemID = mi.MenuItemID
                        WHERE o.Status = 'Teslim'
                        
                        UNION ALL
                        
                        SELECT 
                            'Purchases' AS TransactionType,
                            m.Name AS ProductName,
                            p.Quantity,
                            p.UnitPrice,
                            p.TotalPrice,
                            p.PurchaseDate AS Date
                        FROM Purchases p
                        JOIN Materials m ON p.MaterialID = m.MaterialID
                    ) AS Combined
                    WHERE (@TransactionType IS NULL OR TransactionType = @TransactionType)
                        AND (@ProductName IS NULL OR ProductName = @ProductName)
                        AND (@StartDate IS NULL OR Date >= @StartDate)
                        AND (@EndDate IS NULL OR Date <= @EndDate)
                    ORDER BY Date DESC;";

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // Null kontrolü yapılan parametre atamaları
                        if (transactionType == "All Transactions")
                            cmd.Parameters.AddWithValue("@TransactionType", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@TransactionType", transactionType);

                        if (productName == "All Products")
                            cmd.Parameters.AddWithValue("@ProductName", DBNull.Value);
                        else
                            cmd.Parameters.AddWithValue("@ProductName", productName);

                        if (startDate.HasValue)
                            cmd.Parameters.AddWithValue("@StartDate", startDate.Value);
                        else
                            cmd.Parameters.AddWithValue("@StartDate", DBNull.Value);

                        if (endDate.HasValue)
                            cmd.Parameters.AddWithValue("@EndDate", endDate.Value);
                        else
                            cmd.Parameters.AddWithValue("@EndDate", DBNull.Value);

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            transactionsData = new DataTable();
                            adapter.Fill(transactionsData);
                        }
                    }
                }

                FormatDataGridView();
                CalculateAndDisplayTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            dataGridView1.DataSource = transactionsData;

            if (dataGridView1.Columns["TransactionType"] != null)
                dataGridView1.Columns["TransactionType"].HeaderText = "Transaction Type";

            if (dataGridView1.Columns["ProductName"] != null)
                dataGridView1.Columns["ProductName"].HeaderText = "Product Name";

            if (dataGridView1.Columns["UnitPrice"] != null)
            {
                dataGridView1.Columns["UnitPrice"].HeaderText = "Unit Price";
                dataGridView1.Columns["UnitPrice"].DefaultCellStyle.Format = "#,##0.00 ₺";
            }

            if (dataGridView1.Columns["TotalPrice"] != null)
            {
                dataGridView1.Columns["TotalPrice"].HeaderText = "Total Price";
                dataGridView1.Columns["TotalPrice"].DefaultCellStyle.Format = "#,##0.00 ₺";
            }

            if (dataGridView1.Columns["Date"] != null)
            {
                dataGridView1.Columns["Date"].HeaderText = "Transaction Date";
                dataGridView1.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void CalculateAndDisplayTotals()
        {
            if (transactionsData == null) return;

            decimal totalIncome = transactionsData.AsEnumerable()
                .Where(row => row.Field<string>("TransactionType") == "Sales")
                .Sum(row => row.Field<decimal>("TotalPrice"));

            decimal totalExpense = transactionsData.AsEnumerable()
                .Where(row => row.Field<string>("TransactionType") == "Purchases")
                .Sum(row => row.Field<decimal>("TotalPrice"));

            decimal profit = totalIncome - totalExpense;

            // Doğrudan string formatı kullanarak TL sembolü ekleme
            incomlabel.Text = string.Format("{0:N2} ₺", totalIncome);
            ExpenseLabel.Text = string.Format("{0:N2} ₺", totalExpense);
            ProfitLabel.Text = string.Format("{0:N2} ₺", profit);

            // Profit/Loss renk gösterimi
            ProfitLabel.ForeColor = profit >= 0 ? System.Drawing.Color.Green : System.Drawing.Color.Red;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            string transactionType = null;
            string productName = null;
            DateTime? startDate = null;
            DateTime? endDate = null;

            if (SellOrBuyCombobox.SelectedItem != null)
                transactionType = SellOrBuyCombobox.SelectedItem.ToString();

            if (comboBoxProducterName.SelectedItem != null)
                productName = comboBoxProducterName.SelectedItem.ToString();

            startDate = TimeBoxStart.Value.Date;
            endDate = TimeBoxFinish.Value.Date.AddDays(1).AddSeconds(-1);

            LoadData(transactionType, productName, startDate, endDate);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SellOrBuyCombobox.SelectedIndex = 0;
            comboBoxProducterName.SelectedIndex = 0;
            TimeBoxStart.Value = DateTime.Today.AddMonths(-1);
            TimeBoxFinish.Value = DateTime.Today;
            TimeBoxStart.Checked = true;
            TimeBoxFinish.Checked = true;

            LoadData();
        }
    }
}