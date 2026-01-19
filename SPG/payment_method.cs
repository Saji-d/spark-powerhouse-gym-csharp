using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPG
{
    public partial class payment_method : Form
    {
        public payment_method()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("Please Make a Payment!");
            bksah bk = new bksah();
            bk.Show();
            this.Hide();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Bank ba = new Bank();
            ba.Show();
        }
    }
}
