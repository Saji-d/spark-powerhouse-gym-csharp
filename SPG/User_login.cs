using Guna.UI2.WinForms;
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
    public partial class User_login : Form
    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSI\Documents\signup.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public User_login()
        {
            InitializeComponent();
        }

        private void User_login_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
         //   guna2Panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
            
                // Check if the email or password fields are empty
                if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text))
                {
                    MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; // Exit early if fields are empty
                }

                // Ensure the connection is not already open
                if (connect.State != ConnectionState.Open)
                {
                    try
                    {
                        connect.Open();

                        // Use parameterized query to prevent SQL injection
                        string selectData = "SELECT * FROM sign WHERE email = @Email AND password = @Password";
                        using (SqlCommand cmd = new SqlCommand(selectData, connect))
                        {
                            // Add parameters to the SQL query to prevent SQL injection
                            cmd.Parameters.AddWithValue("@Email", guna2TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@Password", guna2TextBox2.Text.Trim());

                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);

                            // Check if the email and password match an entry in the database
                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Logged in successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Show the main form after successful login
                                HomePage ho = new HomePage();
                                ho.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect Email/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Catch any errors and display a meaningful message
                        MessageBox.Show("Error Connecting: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Always close the connection
                        connect.Close();
                    }
                }
            }

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp us = new SignUp();
            us.Show();
        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {
            guna2Panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
