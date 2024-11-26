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

        private void AccountingDetails_Load(object sender, EventArgs e)
        {
            sidebar1.ParentFormRef = this;
        }
    }
}
