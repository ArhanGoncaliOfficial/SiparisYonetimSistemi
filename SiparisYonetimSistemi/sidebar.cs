using AnaDash;
using deneme001;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisYonetimSistemi
{
    public partial class sidebar : UserControl
    {
        public sidebar()
        {
            InitializeComponent();
        }
        public Form ParentFormRef { get; set; }

        private void overview_btn_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.StartPosition = FormStartPosition.CenterScreen;
            homePageForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void user_m_btn_Click(object sender, EventArgs e)
        {
            UserManagement userManagementForm = new UserManagement();
            userManagementForm.StartPosition = FormStartPosition.CenterScreen;
            userManagementForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void menu_m_btn_Click(object sender, EventArgs e)
        {
            MenuManagament menuManagementForm = new MenuManagament();
            menuManagementForm.StartPosition = FormStartPosition.CenterScreen;
            menuManagementForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void acc_btn_Click(object sender, EventArgs e)
        {
            AccountingDetails accountingDetailsForm = new AccountingDetails();
            accountingDetailsForm.StartPosition = FormStartPosition.CenterScreen;
            accountingDetailsForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
            Reports reportsForm = new Reports();
            reportsForm.StartPosition = FormStartPosition.CenterScreen;
            reportsForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void suppmng_btn_Click(object sender, EventArgs e)
        {
            SupplierManagament supplierManagamentForm = new SupplierManagament();
            supplierManagamentForm.StartPosition = FormStartPosition.CenterScreen;
            supplierManagamentForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }
    }
}
