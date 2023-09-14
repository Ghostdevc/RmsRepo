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
    public partial class EditOrderAdmin : Form
    {
        public static readonly rmsDbEntities1 db = new rmsDbEntities1();

        struct ProductItem
        {
            public float price;

            public ProductItem(float price)
            {
                this.price = price;
            }
        }

        public EditOrderAdmin()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ViewOrdersFrmAdmin viewOrdersFrmAdmin = new ViewOrdersFrmAdmin();
            viewOrdersFrmAdmin.Show();
            this.Hide();
        }

        private void EditOrderAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.DataSource = Order.getProducts();
                dataGridView2.DataSource = Order.getPckProducts();
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
                MessageBox.Show(ex.Message);
            }
  
        }

        public void totalPriceCounter()
        {
            double totalPrice = 0;
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {
                totalPrice += double.Parse(dataGridView4.Rows[i].Cells[5].Value.ToString());
            }

            label7.Text = totalPrice.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView4.Rows[0].Clone();


                row.Cells[0].Value = txtId.Text;
                row.Cells[1].Value = txtName.Text;
                row.Cells[2].Value = txtPrice.Text;
                row.Cells[3].Value = txtAmount.Text;
                row.Cells[4].Value = txtType.Text;
                double totalPrice = double.Parse(row.Cells[2].Value.ToString()) * int.Parse(row.Cells[3].Value.ToString());
                row.Cells[5].Value = totalPrice;
                dataGridView4.Rows.Add(row);
                totalPriceCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
  
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                totalPriceCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView4.Rows[0].Clone();

                row.Cells[0].Value = txtId.Text;
                row.Cells[1].Value = txtName.Text;
                row.Cells[2].Value = txtPrice.Text;
                row.Cells[3].Value = txtAmount.Text;
                row.Cells[4].Value = txtType.Text;
                float totalPrice = float.Parse(row.Cells[2].Value.ToString()) * int.Parse(row.Cells[3].Value.ToString());
                row.Cells[5].Value = totalPrice;
                dataGridView4.Rows.Add(row);
                totalPriceCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
      
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView4.Rows.RemoveAt(dataGridView4.SelectedRows[0].Index);
                totalPriceCounter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
            txtAmount.Text = numericUpDown1.Value.ToString();
            txtType.Text = "Meal";
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txtId.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txtAmount.Text = numericUpDown2.Value.ToString();
            txtType.Text = "Packaged";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbTableNo.SelectedItem = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
    }
}
