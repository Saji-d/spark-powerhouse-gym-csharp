using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPG
{
    public partial class Admin_Dashboard : Form
    {
        public Admin_Dashboard()
        {
            InitializeComponent();
        }

   

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp_Info si = new SignUp_Info();
            si.Show();

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Membership_Info mi = new Membership_Info(); 
            mi.Show();
        }
    }
}
