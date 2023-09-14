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
    public partial class KitchenOrderFrm : Form
    {
        rmsDbEntities1 db = new rmsDbEntities1 ();
        public KitchenOrderFrm()
        {
            InitializeComponent();
        }

        public void listActiveOrders()
        {
            var orders = from order in db.tbl_order_has_meal
                         select new
                         {
                             order.tbl_order.order_id,
                             order.tbl_order.order_date,
                             order.tbl_order.order_status,
                             order.tbl_meals.meal_name,
                             order.order_has_meal_amount
                         };
            dgvActiveOrders.DataSource = orders.Where(x => x.order_status == "Active").ToList();
        }

        private void KitchenOrderFrm_Load(object sender, EventArgs e)
        {
            listActiveOrders();
        }

        private void btnBackToMain_Click(object sender, EventArgs e)
        {

            KitchenFrm kitchenFrm = new KitchenFrm();
            kitchenFrm.Show();
            this.Hide();
        }

        private void btnMarkReady_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_order order = new tbl_order();
                order.order_id = int.Parse(txtOrderID.Text.ToString());
                order.order_status = "Ready";
                Kitchen.UpdateOrderStatus(order);
                MessageBox.Show("Order status changed.");
                listActiveOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnMarkCancelled_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_order order = new tbl_order();
                order.order_id = int.Parse(txtOrderID.Text);
                order.order_status = "Cancelled";
                Kitchen.UpdateOrderStatus(order);
                MessageBox.Show("Order status changed.");
                listActiveOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
 

        private void btnMarkActive_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_order order = new tbl_order();
                order.order_id = int.Parse(txtOrderID.Text);
                order.order_status = "Active";
                Kitchen.UpdateOrderStatus(order);
                MessageBox.Show("Order status changed.");
                listActiveOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgvActiveOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtOrderID.Text = dgvActiveOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtStatus.Text = dgvActiveOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
