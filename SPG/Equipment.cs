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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        /*private void guna2Button2_Click(object sender, EventArgs e)
        {
            string CustomerName = guna2TextBox1.Text.Trim();
            string PhoneNumber = guna2TextBox2.Text.Trim();

            // Validate that a product is selected
            if (guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Get the full product string from the ComboBox
            string productString = guna2ComboBox1.SelectedItem.ToString();

            // Validate the phone number (e.g., 11 digits)
            if (!IsValidPhoneNumber(PhoneNumber))
            {
                MessageBox.Show("Phone number must be 11 digits.");
                return;
            }

            // Insert data into the Buy table
            try
            {
                using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\sigup.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "INSERT INTO dbo.buy (CustomerName, PhoneNumber, ProductPrice) " +
                                   "VALUES (@CustomerName, @PhoneNumber, @Product)";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = CustomerName;
                        command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = PhoneNumber;
                        command.Parameters.Add("@Product", SqlDbType.NVarChar).Value = productString;

                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Purchase successful!");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Validate phone number
        private bool IsValidPhoneNumber(string phone)
        {
            return phone.Length == 11 && long.TryParse(phone, out _);
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }*/
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            string CustomerName = guna2TextBox1.Text.Trim();
            string PhoneNumber = guna2TextBox2.Text.Trim();

            // Validate that a product is selected
            if (guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Get the full product string from the ComboBox
            string productString = guna2ComboBox1.SelectedItem.ToString();

            // Validate the phone number (e.g., 11 digits)
            if (!IsValidPhoneNumber(PhoneNumber))
            {
                MessageBox.Show("Phone number must be 11 digits.");
                return;
            }

            // Insert data into the 'buy' table
            try
            {
                using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\registration.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=False"))
                {
                    // Use schema explicitly (dbo assumed)
                    string query = "INSERT INTO dbo.buy (CustomerName, PhoneNumber, ProductPrice) " +
                                   "VALUES (@CustomerName, @PhoneNumber, @Product)";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        command.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = CustomerName;
                        command.Parameters.Add("@PhoneNumber", SqlDbType.NVarChar).Value = PhoneNumber;
                        command.Parameters.Add("@Product", SqlDbType.NVarChar).Value = productString;

                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                }

                // MessageBox.Show("Purchase successful!");
                MessageBox.Show("Please Make a Payment!");
                payment_method pm = new payment_method();
                pm.Show();
                this.Hide();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        // Validate phone number
        private bool IsValidPhoneNumber(string phone)
        {
            return phone.Length == 11 && long.TryParse(phone, out _);
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            shop1 sh = new shop1();
            sh.Show();
        }
    }
}

