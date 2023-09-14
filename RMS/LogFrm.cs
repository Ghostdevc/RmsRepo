using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class LogFrm : Form
    {
        string textFile = @"C:\Temp\log.txt";
        public LogFrm()
        {
            InitializeComponent();
        }

        private void LogFrm_Load(object sender, EventArgs e)
        {
            if (File.Exists(textFile))
            {
                string textContent = File.ReadAllText(textFile);
                richTextBox1.Text = textContent;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminFrm adminFrm = new AdminFrm();
            adminFrm.Show();
            this.Hide();
        }
    }
}
