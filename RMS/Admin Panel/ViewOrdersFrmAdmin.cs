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
        public static readonly rmsDbEntities1 db = new rmsDbEntities1();

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
            EditOrderAdmin edtOFrmAdmn = new EditOrderAdmin();
            edtOFrmAdmn.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {       
                var changeStatus = Order.getOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
                changeStatus.order_status = "Cancelled";
                Order.editOrder(changeStatus);
                MessageBox.Show("Order Cancelled!");
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
                Logger.writeLog(ex.Message);
               
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

    }
}
