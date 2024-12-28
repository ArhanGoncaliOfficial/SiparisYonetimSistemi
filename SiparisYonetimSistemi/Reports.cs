using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient; // MySQL kütüphanesi

namespace SiparisYonetimSistemi
{
    public partial class Reports : Form
    {
        private string connectionString = "Server=localhost;Database=SiparisYonetimDB;Uid=root;Pwd=;";

        public Reports()
        {
            InitializeComponent();
        }

        private void Reports_Load(object sender, EventArgs e)
        {
            LoadCharts();
            sidebar1.ParentFormRef = this;
        }

        private void LoadCharts()
        {
            LoadMonthlyIncomeChart();
            LoadMonthlyExpenseChart();
            LoadMaterialConsumptionChart();
            LoadPopularDishesChart();
            LoadTopTablesChart();
        }

        private void LoadMonthlyIncomeChart()
        {
            string query = "SELECT MONTHNAME(OrderDate) AS Month, SUM(Quantity * Price) AS MonthlyIncome FROM Orders o JOIN OrderDetails od ON o.OrderID = od.OrderID GROUP BY MONTH(OrderDate);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    chartMonthlyIncome.Series[0].Points.Clear();
                    chartMonthlyIncome.Titles.Clear();
                    chartMonthlyIncome.Titles.Add("Monthly Income");
                    while (reader.Read())
                    {
                        string month = reader["Month"].ToString();
                        decimal income = Convert.ToDecimal(reader["MonthlyIncome"]);
                        chartMonthlyIncome.Series[0].Points.AddXY(month, income);
                    }
                }
                catch
                {
                    chartMonthlyIncome.Titles.Clear();
                    chartMonthlyIncome.Titles.Add("No Data Available");
                }
            }
        }

        private void LoadMonthlyExpenseChart()
        {
            string query = "SELECT MONTHNAME(PurchaseDate) AS Month, SUM(Quantity * UnitPrice) AS MonthlyExpense FROM Purchases GROUP BY MONTH(PurchaseDate);";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    chartMonthlyExpense.Series[0].Points.Clear();
                    chartMonthlyExpense.Titles.Clear();
                    chartMonthlyExpense.Titles.Add("Monthly Expense");
                    while (reader.Read())
                    {
                        string month = reader["Month"].ToString();
                        decimal expense = Convert.ToDecimal(reader["MonthlyExpense"]);
                        chartMonthlyExpense.Series[0].Points.AddXY(month, expense);
                    }
                }
                catch
                {
                    chartMonthlyExpense.Titles.Clear();
                    chartMonthlyExpense.Titles.Add("No Data Available");
                }
            }
        }

        private void LoadMaterialConsumptionChart()
        {
            string query = "SELECT m.Name AS Material, SUM(mm.Quantity * od.Quantity) AS TotalConsumed FROM OrderDetails od JOIN MenuMaterials mm ON od.MenuItemID = mm.MenuItemID JOIN Materials m ON mm.MaterialID = m.MaterialID GROUP BY m.Name;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    chartMaterialConsumption.Series[0].Points.Clear();
                    chartMaterialConsumption.Titles.Clear();
                    chartMaterialConsumption.Titles.Add("Material Consumption");
                    while (reader.Read())
                    {
                        string material = reader["Material"].ToString();
                        decimal totalConsumed = Convert.ToDecimal(reader["TotalConsumed"]);
                        chartMaterialConsumption.Series[0].Points.AddXY(material, totalConsumed);
                    }
                }
                catch
                {
                    chartMaterialConsumption.Titles.Clear();
                    chartMaterialConsumption.Titles.Add("No Data Available");
                }
            }
        }

        private void LoadPopularDishesChart()
        {
            string query = "SELECT mi.Name AS Dish, SUM(od.Quantity) AS TotalOrdered FROM OrderDetails od JOIN MenuItems mi ON od.MenuItemID = mi.MenuItemID GROUP BY mi.Name ORDER BY TotalOrdered DESC LIMIT 5;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    chartPopularDishes.Series[0].Points.Clear();
                    chartPopularDishes.Titles.Clear();
                    chartPopularDishes.Titles.Add("Popular Dishes");
                    while (reader.Read())
                    {
                        string dish = reader["Dish"].ToString();
                        int totalOrdered = Convert.ToInt32(reader["TotalOrdered"]);
                        chartPopularDishes.Series[0].Points.AddXY(dish, totalOrdered);
                    }
                }
                catch
                {
                    chartPopularDishes.Titles.Clear();
                    chartPopularDishes.Titles.Add("No Data Available");
                }
            }
        }

        private void LoadTopTablesChart()
        {
            string query = "SELECT t.TableName AS TableName, COUNT(o.OrderID) AS TotalOrders FROM Orders o JOIN Tables t ON o.TableID = t.TableID GROUP BY t.TableName ORDER BY TotalOrders DESC;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    chartTopTables.Series[0].Points.Clear();
                    chartTopTables.Titles.Clear();
                    chartTopTables.Titles.Add("Top Tables");
                    while (reader.Read())
                    {
                        string tableName = reader["TableName"].ToString();
                        int totalOrders = Convert.ToInt32(reader["TotalOrders"]);
                        chartTopTables.Series[0].Points.AddXY(tableName, totalOrders);
                    }
                }
                catch
                {
                    chartTopTables.Titles.Clear();
                    chartTopTables.Titles.Add("No Data Available");
                }
            }
        }
    }
}
