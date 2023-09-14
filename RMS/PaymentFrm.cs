using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class PaymentFrm : Form
    {
        

        public static rmsDbEntities1 db = new rmsDbEntities1();
      

        public PaymentFrm()
        {   
            InitializeComponent();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CashierFrm cashierFrm = new CashierFrm();
            cashierFrm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tbl_check check = new tbl_check();
                tbl_tables table = new tbl_tables();
                check.check_id = int.Parse(label5.Text);
                check.check_date = DateTime.Parse(label4.Text);
                check.check_totalPrice = double.Parse(label3.Text);
                check.fk_table_id = int.Parse(cmbTableNo.SelectedItem.ToString());
                check.isPaid = "true";
                table.table_status = "Available";
                table.table_id = int.Parse(cmbTableNo.SelectedItem.ToString());
                db.tbl_check.AddOrUpdate(check);
                db.tbl_tables.AddOrUpdate(table);
                MessageBox.Show("Check Paid!");
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }  
        }

        private void cmbTableNo_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                tbl_tables table = new tbl_tables();
                table.table_id = int.Parse(cmbTableNo.SelectedItem.ToString());


                int checkId = BLL.Table.getTablesHasUnpaidCheck(table);
                if (db.tbl_check.Find(checkId).check_totalPrice.ToString() != null && db.tbl_check.Find(checkId).check_date.ToString() != null)
                {
                    label3.Text = db.tbl_check.Where(x => x.check_id == checkId).First().check_totalPrice.ToString();// + " ₺    " + db.tbl_check.Find(checkId).tbl_order.Count.ToString() + " Orders";
                    label4.Text = db.tbl_check.Find(checkId).check_date.ToString();
                    label5.Text = checkId.ToString();
                }
                else return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
        
                
            }
            
          
           
    }

  
    }
}
