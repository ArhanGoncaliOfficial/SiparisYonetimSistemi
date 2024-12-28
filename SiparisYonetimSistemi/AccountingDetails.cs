using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL kütüphanesi

namespace SiparisYonetimSistemi
{
    public partial class AccountingDetails : Form
    {
        private string connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";

        public AccountingDetails()
        {
            InitializeComponent();
        }

        private void AccountingDetails_Load(object sender, EventArgs e)
        {
            LoadComboBoxItems();
            LoadData();
            sidebar1.ParentFormRef = this;
        }

        private void LoadComboBoxItems()
        {
            SellOrBuyCombobox.Items.Clear();
            SellOrBuyCombobox.Items.Add("All Transactions");
            SellOrBuyCombobox.Items.Add("Sales");
            SellOrBuyCombobox.Items.Add("Purchases");
            SellOrBuyCombobox.SelectedIndex = 0;

            comboBoxProducterName.Items.Clear();
            comboBoxProducterName.Items.Add("All Products");

            string query = "SELECT Name FROM Materials UNION SELECT Name FROM MenuItems;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBoxProducterName.Items.Add(reader.GetString("Name"));
                }
                comboBoxProducterName.SelectedIndex = 0;
            }
        }

        private void LoadData(string transactionType = null, string productName = null, DateTime? startDate = null, DateTime? endDate = null)
        {
            string query = @"
            SELECT * FROM (
                SELECT 'Sales' AS TransactionType, mi.Name AS ProductName, od.Quantity AS Quantity,
                       od.Price AS UnitPrice, (od.Quantity * od.Price) AS TotalPrice, o.OrderDate AS Date
                FROM Orders o
                JOIN OrderDetails od ON o.OrderID = od.OrderID
                JOIN MenuItems mi ON od.MenuItemID = mi.MenuItemID
                UNION ALL
                SELECT 'Purchases' AS TransactionType, m.Name AS ProductName, p.Quantity AS Quantity,
                       p.UnitPrice AS UnitPrice, p.TotalPrice AS TotalPrice, p.PurchaseDate AS Date
                FROM Purchases p
                JOIN Materials m ON p.MaterialID = m.MaterialID
            ) AS Combined
            WHERE (@TransactionType IS NULL OR TransactionType = @TransactionType)
              AND (@ProductName IS NULL OR ProductName = @ProductName)
              AND (@StartDate IS NULL OR Date >= @StartDate)
              AND (@EndDate IS NULL OR Date <= @EndDate);";

            DataTable dt = new DataTable();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TransactionType", string.IsNullOrEmpty(transactionType) ? (object)DBNull.Value : transactionType);
                cmd.Parameters.AddWithValue("@ProductName", string.IsNullOrEmpty(productName) ? (object)DBNull.Value : productName);
                cmd.Parameters.AddWithValue("@StartDate", startDate.HasValue ? (object)startDate.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@EndDate", endDate.HasValue ? (object)endDate.Value : DBNull.Value);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;

                CalculateTotals(dt);
            }
        }

        private void CalculateTotals(DataTable dt)
        {
            decimal totalIncome = 0;
            decimal totalExpense = 0;

            foreach (DataRow row in dt.Rows)
            {
                string transactionType = row["TransactionType"].ToString();
                decimal totalPrice = Convert.ToDecimal(row["TotalPrice"]);

                if (transactionType == "Sales")
                {
                    totalIncome += totalPrice;
                }
                else if (transactionType == "Purchases")
                {
                    totalExpense += totalPrice;
                }
            }

            decimal profit = totalIncome - totalExpense;

            incomlabel.Text = totalIncome.ToString("C");
            ExpenseLabel.Text = totalExpense.ToString("C");
            ProfitLabel.Text = profit.ToString("C");
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            string transactionType = SellOrBuyCombobox.SelectedItem.ToString();
            string productName = comboBoxProducterName.SelectedItem.ToString();

            DateTime? startDate = TimeBoxStart.Checked ? TimeBoxStart.Value.Date : (DateTime?)null;
            DateTime? endDate = TimeBoxFinish.Checked ? TimeBoxFinish.Value.Date : (DateTime?)null;

            LoadData(transactionType == "All Transactions" ? null : transactionType,
                     productName == "All Products" ? null : productName,
                     startDate, endDate);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SellOrBuyCombobox.SelectedIndex = 0;
            comboBoxProducterName.SelectedIndex = 0;
            TimeBoxStart.Value = DateTime.Now;
            TimeBoxFinish.Value = DateTime.Now;

            LoadData();
        }
    }
}
