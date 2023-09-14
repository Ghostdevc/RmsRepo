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
    public partial class WaiterFrm : Form
    {
        public WaiterFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderFrm orderFrm= new OrderFrm();
            orderFrm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewOrdersFrm cancelOrderFrm = new ViewOrdersFrm();
            cancelOrderFrm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
