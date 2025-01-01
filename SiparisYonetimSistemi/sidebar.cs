using AnaDash;
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
            MenuYonetimFormu MenuManagementForm = new MenuYonetimFormu();
            MenuManagementForm.StartPosition = FormStartPosition.CenterScreen;
            MenuManagementForm.Show();

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

        private void mtrlmng_btn_Click(object sender, EventArgs e)
        {
            MaterialManagament materialManagamentForm = new MaterialManagament();
            materialManagamentForm.StartPosition = FormStartPosition.CenterScreen;
            materialManagamentForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void ordrmng_btn_Click(object sender, EventArgs e)
        {
            OrderManagement orderManagementForm = new OrderManagement();
            orderManagementForm.StartPosition = FormStartPosition.CenterScreen;
            orderManagementForm.Show();

            if (ParentFormRef != null)
            {
                ParentFormRef.Hide();
            }
        }

        private void about_btn_Click(object sender, EventArgs e)
        {
            AboutUs AboutUsForm = new AboutUs();
            AboutUsForm.StartPosition = FormStartPosition.CenterScreen;
            AboutUsForm.Show();
        }
    }
}
