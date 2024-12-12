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
    public partial class SupplierManagament : Form
    {
        public SupplierManagament()
        {
            InitializeComponent();
        }

        private void LoadSuppliers()
        {
            string query = @"
        select 
            s.SupplierID,
            s.SupplierName,
            s.ContactPhone,
            m.Name as MaterialName,
            m.Unit,
            m.UnitPrice
        from 
            Suppliers s
        left join 
            Purchases p on s.SupplierID = p.SupplierID
        left join 
            Materials m on p.MaterialID = m.MaterialID";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection("Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;"))
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
            }
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.AutoGenerateColumns = true;
            }
            else
            {
                MessageBox.Show("No data found!");
            }

            // Edit ve Remove butonlarını ekle
            if (!dataGridView1.Columns.Contains("Edit"))
            {
                DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
                editButton.Name = "Edit";
                editButton.Text = "Edit";
                editButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(editButton);
            }

            if (!dataGridView1.Columns.Contains("Remove"))
            {
                DataGridViewButtonColumn removeButton = new DataGridViewButtonColumn();
                removeButton.Name = "Remove";
                removeButton.Text = "Remove";
                removeButton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(removeButton);
            }
        }


        private void SupplierManagament_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            sidebar1.ParentFormRef = this;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SupplierAdd addSupplierForm = new SupplierAdd();
            addSupplierForm.ShowDialog();

            if (addSupplierForm.DialogResult == DialogResult.OK)
            {
                LoadSuppliers();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
        {
            int supplierId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SupplierID"].Value);
            EditSupplierForm editForm = new EditSupplierForm(supplierId);
            editForm.ShowDialog();

            if (editForm.DialogResult == DialogResult.OK)
            {
                LoadSuppliers();
            }
        }
        else if (dataGridView1.Columns[e.ColumnIndex].Name == "Remove")
        {
            int supplierId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["SupplierID"].Value);
            DialogResult confirm = MessageBox.Show("Are you sure to delete this supplier?", "Confirm", MessageBoxButtons.YesNo);

            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection("Server=localhost; Database=SiparisYonetimDB; Integrated Security=True;"))
                {
                    string query = "delete from Suppliers where SupplierID = @SupplierID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                LoadSuppliers();
            }
        }
            }
        }
}
