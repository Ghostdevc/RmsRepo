using BLL;
using DAL;
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
    public partial class ViewOrdersFrmAdmin : Form
    {
        public static readonly rmsDbEntities db = new rmsDbEntities();

        public ViewOrdersFrmAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminFrm adminFrm = new AdminFrm();
            adminFrm.Show();
            this.Hide();
        }

        private void ViewOrdersFrmAdmin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Order.getAllOrders();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditOrderAdmin edtOFrmAdmn = new EditOrderAdmin();
            edtOFrmAdmn.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                var deletedOrder = Order.getOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
                Order.deleteOrder(deletedOrder);
                MessageBox.Show("Order Deleted!");
                dataGridView1.DataSource = Order.getAllOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot deleted!");
                Logger.writeLog(ex.Message);
                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var chngStatus = Order.getOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
            chngStatus.order_status = "Done";
            Order.editOrder(chngStatus);
            MessageBox.Show("Order status changed!");
            dataGridView1.DataSource = Order.getAllOrders();
        }

    }
}
