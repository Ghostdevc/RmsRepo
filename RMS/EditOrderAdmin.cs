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
        public static readonly rmsDbEntities db = new rmsDbEntities();

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

        private void button1_Click(object sender, EventArgs e)
        {
            ViewOrdersFrmAdmin viewOrdersFrmAdmin = new ViewOrdersFrmAdmin();
            viewOrdersFrmAdmin.Show();
            this.Hide();
        }
        private void totalPriceCounter()
        {
            float totalPrice = 0;
            foreach (Object item in listBox2.Items)
            {
                String s = item.ToString().Split('-')[1].Trim().Substring(1);
                float price = float.Parse(s);
                totalPrice += price;
            }

            label7.Text = totalPrice.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            listBox2.Items.Add(listBox1.SelectedItem);

            if (listBox1.SelectedItem == listBox2.Items[0])
            {

            }

            if (listBox3.SelectedItem == null) return;
            listBox2.Items.Add(listBox3.SelectedItem);

            totalPriceCounter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;

            listBox2.Items.Remove(listBox2.SelectedItem);
            listBox2.Items.Remove(listBox2.SelectedItem);
            totalPriceCounter();
        }

        private void EditOrderFrm_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = Order.getProducts();
            listBox3.DataSource = Order.getPckProducts();
            dataGridView1.DataSource = Order.getAllOrders();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var edtOrder = Order.getOrder((int)dataGridView1.CurrentRow.Cells[0].Value);
            edtOrder.table_no = (string)comboBox1.SelectedItem;

            string value = "";

            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                if (value != "")
                {
                    value += ",";
                }
                value += listBox2.Items[i].ToString();
            }
            // Now you have all the values in comma (,) separated string.

            edtOrder.order_details = value;
            string tp = label7.Text;
            float tPrice = float.Parse(tp);
            edtOrder.order_totalPrice = tPrice;
            edtOrder.order_status = "Preparing";
            edtOrder.order_date = DateTime.Now;
            Order.editOrder(edtOrder);
            MessageBox.Show("Order Edited!!");
            dataGridView1.DataSource = Order.getAllOrders();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            comboBox1.SelectedItem = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            label7.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            string value = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            string[] arr = value.Split(',');

            foreach (string s in arr)
            {
                listBox2.Items.Add(s);
            }

        }
    }
}
