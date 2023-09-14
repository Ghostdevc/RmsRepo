using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class KitchenFrm : Form
    {
        public KitchenFrm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void btnViewActiveOrders_Click(object sender, EventArgs e)
        {
            KitchenOrderFrm kitchenOrderFrm = new KitchenOrderFrm(); 
            kitchenOrderFrm.Show();
            this.Hide();
        }
    }
}
