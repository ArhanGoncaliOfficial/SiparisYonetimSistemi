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
            //birimler eklenicek
            UniteComboBox.Items.Add("Kg");
            UniteComboBox.Items.Add("g");
            UniteComboBox.Items.Add("LT");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SupplierBox.Text) || string.IsNullOrEmpty(MaterialBox.Text) ||
                string.IsNullOrEmpty(UniteComboBox.Text) || string.IsNullOrEmpty(UnitePriceBox.Text) ||
                string.IsNullOrEmpty(SupplierEmailBox.Text)) 
            {
                MessageBox.Show("All fields must be filled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!System.Text.RegularExpressions.Regex.IsMatch(SupplierEmailBox.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit the function if email is invalid
            }

            string connectionString = "Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "";
            }
        }
    }
}
