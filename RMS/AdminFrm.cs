using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class AdminFrm : Form
    {

        
        public AdminFrm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewOrdersFrmAdmin viewOrdersFrmAdmin = new ViewOrdersFrmAdmin();
            viewOrdersFrmAdmin.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LogFrm logFrm = new LogFrm();
            logFrm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductListFrm productListFrm = new ProductListFrm();
            productListFrm.Show();
            this.Hide();
        }
    }
}
