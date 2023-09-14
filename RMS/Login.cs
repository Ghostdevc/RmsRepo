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
    public partial class Login : Form
    {
        public static readonly rmsDbEntities1 db = new rmsDbEntities1();
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {

            tbl_users user = new tbl_users();
            user.userName = textBox1.Text;
            user.userPassword = textBox2.Text;
            switch (BluserLogic.UserLoginBL(user))
            {
                case 1:
                    MessageBox.Show("Login Successful!");
                    AdminFrm adminFrm = new AdminFrm();
                    adminFrm.Show();
                    this.Hide();
                    break;
                case 2:
                    MessageBox.Show("Login Successful!");
                    KitchenFrm kitchenFrm = new KitchenFrm();
                    kitchenFrm.Show();
                    this.Hide();
                    break;
                case 3:
                    MessageBox.Show("Login Successful!");
                    WaiterFrm waiterFrm = new WaiterFrm();
                    waiterFrm.Show();
                    this.Hide();
                    break;
                case 4:
                    MessageBox.Show("Login Successful!");
                    CashierFrm cashierFrm = new CashierFrm();
                    cashierFrm.Show();
                    this.Hide();
                    break;
                default:
                    MessageBox.Show("Wrong username or password!");
                    break;
            }
        }

    }
}