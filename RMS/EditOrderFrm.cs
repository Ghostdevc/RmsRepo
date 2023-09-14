using BLL;
using DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class EditOrderFrm : Form
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
        public EditOrderFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewOrdersFrm viewOrdersFrm = new ViewOrdersFrm();
            viewOrdersFrm.Show();
            this.Hide();
        }

        private void EditOrderFrm_Load(object sender, EventArgs e)
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

        public void totalPriceCounter()
        {
            try
            {
                double totalPrice = 0;
                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {
                    totalPrice += double.Parse(dataGridView4.Rows[i].Cells[5].Value.ToString());
                }

                label7.Text = totalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
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
                if (dataGridView4.SelectedRows[0] == null)
                    return;
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
            try
            {
                txtId.Text = dataGridView3.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dataGridView3.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dataGridView3.CurrentRow.Cells[2].Value.ToString();
                txtAmount.Text = numericUpDown1.Value.ToString();
                txtType.Text = "Meal";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtId.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
                txtAmount.Text = numericUpDown2.Value.ToString();
                txtType.Text = "Packaged";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message) ;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbTableNo.SelectedItem = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_order order = new tbl_order();
                tbl_tables table = new tbl_tables();
                table.table_id = int.Parse(cmbTableNo.SelectedItem.ToString());

                ArrayList orderMealList = new ArrayList();
                ArrayList orderPckgdList = new ArrayList();

                for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
                {

                    if (dataGridView4.Rows[i].Cells[4].Value.ToString() == "Meal")
                    {
                        tbl_order_has_meal meal = new tbl_order_has_meal();
                        meal.fk_meal_id = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        meal.order_has_meal_amount = int.Parse(dataGridView4.Rows[i].Cells[3].Value.ToString());
                        orderMealList.Add(meal);
                    }
                    if (dataGridView4.Rows[i].Cells[4].Value.ToString() == "Packaged")
                    {
                        tbl_order_has_pckgd pckgd = new tbl_order_has_pckgd();
                        pckgd.fk_pckgd_id = int.Parse(dataGridView3.Rows[i].Cells[0].Value.ToString());
                        pckgd.order_has_pckgd_amount = int.Parse(dataGridView4.Rows[i].Cells[3].Value.ToString());
                        orderPckgdList.Add(pckgd);
                    }


                }

                order.order_date = DateTime.UtcNow;
                order.order_status = "Active";

                string tp = label7.Text;
                double tPrice = double.Parse(tp);
                order.order_totalPrice = tPrice;



                if (Table.isBusy(table) != true)
                {
                    table.table_status = "Busy";
                }
                if (Table.isTableHasUnpaidCheck(table) != true)
                {
                    tbl_check check = new tbl_check();
                    check.isPaid = "false";
                    check.fk_table_id = int.Parse(table.table_id.ToString());
                    check.check_date = DateTime.UtcNow;
                    check.check_totalPrice = double.Parse(label7.Text);
                    //Create check method
                    Order.editOrder(order);
                    MessageBox.Show("Order Edited!");
                }
                else
                {
                    int activeCheckId = Table.getTablesHasUnpaidCheck(table);
                    //Update check method
                    Order.editOrder(order); ;
                    MessageBox.Show("Order Edited!");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
    }
}
