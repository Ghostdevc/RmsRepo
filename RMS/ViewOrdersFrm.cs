using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class ViewOrdersFrm : Form
    {
        public static readonly rmsDbEntities1 db = new rmsDbEntities1();
        public ViewOrdersFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WaiterFrm waiterFrm= new WaiterFrm();
            waiterFrm.Show();
            this.Hide();
        }

        private void ViewOrdersFrm_Load(object sender, EventArgs e)
        {

            var order = from Order in db.tbl_order
                        select new
                        {
                            Order.order_id,
                            Order.order_status,
                            Order.order_date,
                            Order.order_totalPrice,
                            Order.tbl_check.fk_table_id
                        };
            dataGridView1.DataSource = order.ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                var chngStatus = Order.getOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
                chngStatus.order_status = "Cancelled";
                Order.editOrder(chngStatus);
                MessageBox.Show("Order Status Changed!");
                
                var order = from Order in db.tbl_order
                            select new
                            {
                                Order.order_id,
                                Order.order_status,
                                Order.order_date,
                                Order.order_totalPrice,
                                Order.tbl_check.fk_table_id
                            };
                dataGridView1.DataSource = order.ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot deleted!");
                //Logger.writeLog(ex.Message);
               
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var chngStatus = Order.getOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
            chngStatus.order_status = "Done";
            Order.editOrder(chngStatus);
            MessageBox.Show("Order status changed!");
            var order = from Order in db.tbl_order
                        select new
                        {
                            Order.order_id,
                            Order.order_status,
                            Order.order_date,
                            Order.order_totalPrice,
                            Order.tbl_check.fk_table_id
                        };
            dataGridView1.DataSource = order.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            EditOrderFrm edtOFrm = new EditOrderFrm();
            edtOFrm.Show();
            this.Hide();
        }

    }
}
