using AnaDash;
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

namespace deneme001
{
    public partial class AccountingDetails : Form
    {
        public AccountingDetails()
        {
            InitializeComponent();
        }

        private void overview_btn_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm();
            homePageForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            homePageForm.Show();
        }

        private void user_m_btn_Click(object sender, EventArgs e)
        {
            UserManagement userManagementForm = new UserManagement();
            userManagementForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            userManagementForm.Show();
        }

        private void menu_m_btn_Click(object sender, EventArgs e)
        {
            MenuManagament menuManagementForm = new MenuManagament();
            menuManagementForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            menuManagementForm.Show();
        }

        private void acc_btn_Click(object sender, EventArgs e)
        {
            AccountingDetails accountingDetailsForm = new AccountingDetails();
            accountingDetailsForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            accountingDetailsForm.Show();
        }

        private void reports_btn_Click(object sender, EventArgs e)
        {
            Reports reportsForm = new Reports();
            reportsForm.StartPosition = FormStartPosition.CenterScreen;
            this.Hide();
            reportsForm.Show();
        }
    }
}
