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
    public partial class Bank : Form
    {
        public Bank()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string cardHolderName = guna2TextBox1.Text.Trim();
            string cardNumber = guna2TextBox2.Text.Trim();

            // Check if Cardholder Name is empty
            if (string.IsNullOrEmpty(cardHolderName))
            {
                MessageBox.Show("Please enter the Cardholder Name.");
                return;
            }

            // Check if Visa Card Number is empty or not 16 digits long
            if (string.IsNullOrEmpty(cardNumber) || cardNumber.Length != 16 || !long.TryParse(cardNumber, out _))
            {
                MessageBox.Show("Please enter a valid 16-digit Visa Card Number.");
                return;
            }

            MessageBox.Show("Payment processed successfully!");
            this.Hide();
            HomePage ho = new HomePage();
            ho.Show();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    }

