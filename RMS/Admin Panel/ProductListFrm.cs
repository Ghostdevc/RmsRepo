using BLL;
using DAL;
using System;
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
    public partial class ProductListFrm : Form
    {
        public static readonly rmsDbEntities1 db = new rmsDbEntities1();
        public ProductListFrm()
        {
            InitializeComponent();
        }

        private void ProductListFrm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Order.getProducts();
            dataGridView2.DataSource = Order.getPckProducts();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminFrm adminFrm = new AdminFrm();
            adminFrm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                var deletedProduct = Order.getProduct((int)dataGridView1.CurrentRow.Cells[0].Value);
                Order.deleteProduct(deletedProduct);
                MessageBox.Show("Product Deleted!");
                dataGridView1.DataSource = Order.getProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot deleted!");
                Logger.writeLog(ex.Message);
                
            }
 
    }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var deletedPckProduct = Order.getPckProduct((int)dataGridView2.CurrentRow.Cells[0].Value);
                Order.deletePckProduct(deletedPckProduct);
                MessageBox.Show("Drink Deleted!");
                dataGridView1.DataSource = Order.getPckProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot deleted!");
                Logger.writeLog(ex.Message);
              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
                try
                {
                if (comboBox1.SelectedItem.ToString() == "Meal")
                {
                    tbl_meals addMeals = new tbl_meals();
                    addMeals.meal_name = textBox1.Text;
                    string price = textBox2.Text;
                    float mPrice = float.Parse(price.ToString());
                    addMeals.meal_price = mPrice;
                    Order.createProduct(addMeals);
                    MessageBox.Show("Product Added!");
                    dataGridView1.DataSource = Order.getProducts();

                } if(comboBox1.SelectedItem.ToString() == "Packaged")
                {
                
                    tbl_packaged addPckgd = new tbl_packaged();
                    addPckgd.pckgd_name = textBox1.Text;
                    string price = textBox2.Text;
                    float pPrice = float.Parse(price.ToString());
                    addPckgd.pckgd_price = pPrice;
                    Order.createPckProduct(addPckgd);
                    MessageBox.Show("Drink added");
                    dataGridView2.DataSource = Order.getPckProducts();
                }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Please check the inputs!!");
                    Logger.writeLog(ex.Message);
                 
                }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(comboBox1.SelectedItem.ToString() == "Meal")
                {
                    var editProduct = Order.getProduct((int)dataGridView1.CurrentRow.Cells[0].Value);
                    editProduct.meal_name = textBox1.Text;
                    string price = textBox2.Text;
                    float mPrice = float.Parse(price.ToString());
                    editProduct.meal_price = mPrice;
                    Order.updateProduct(editProduct);
                    MessageBox.Show("Meal updated!!");
                    dataGridView1.DataSource = Order.getProducts();

                } if(comboBox1.SelectedItem.ToString() == "Packaged")
                {
                    var editPckProduct = Order.getPckProduct((int)dataGridView2.CurrentRow.Cells[0].Value);
                    editPckProduct.pckgd_name = textBox1.Text;
                    string price = textBox2.Text;
                    float mPrice = float.Parse(price.ToString());
                    editPckProduct.pckgd_price = mPrice;
                    Order.updatePckProduct(editPckProduct);
                    MessageBox.Show("Drink updated!!");
                    dataGridView2.DataSource = Order.getPckProducts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please check the inputs!!");
                Logger.writeLog(ex.Message);
            
            }
        }
    }
}
