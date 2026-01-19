using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Text.RegularExpressions;

namespace SPG
{
    public partial class SignUp : Form

    {
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MSI\Documents\signup.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public SignUp()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {
            guna2Panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_login us = new User_login();
            us.Show();
        }

        /*private void guna2Button1_Click(object sender, EventArgs e)
        {
            string message = string.Empty;

            // Check if all necessary fields are filled
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) || string.IsNullOrEmpty(guna2TextBox3.Text)

               || string.IsNullOrEmpty(guna2TextBox4.Text) || string.IsNullOrEmpty(guna2TextBox5.Text)) 
              
            {
                MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit early
            }

            // Ensure the connection is not already open
            if (connect.State != ConnectionState.Open)
            {
                try
                {
                    connect.Open();

                    // Use parameterized query to prevent SQL injection
                    string checkEmail = "SELECT * FROM sign WHERE email = @Email";
                    using (SqlCommand checkUser = new SqlCommand(checkEmail, connect))
                    {
                        checkUser.Parameters.AddWithValue("@Email", guna2TextBox3.Text.Trim());

                        // Using SqlDataAdapter to fill the data table
                        SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Check if the email already exists in the table
                        if (table.Rows.Count >= 1)
                        {
                            //MessageBox.Show(guna2TextBox3.Text + " is already registered. Please use a different email.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (table.Rows[0]["email"].ToString() == guna2TextBox3.Text.Trim())
                            {
                                message += guna2TextBox3.Text + " is already registered. Please use a different email.\n";
                            }
                            if (table.Rows[0]["name"].ToString() == guna2TextBox1.Text.Trim() &&
                                table.Rows[0]["lastname"].ToString() == guna2TextBox2.Text.Trim())
                            {
                                message += "The name " + guna2TextBox1.Text + " " + guna2TextBox2.Text + " is already registered. Please use a different name.";
                            }

                            //MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                        else
                        {
                            // Insert new user data into the sign table
                            string insertData = "INSERT INTO sign (name, lastname, email, phone, password) " +
                                                "VALUES(@firstName, @lastName, @Email, @phone, @password)";

                            using (SqlCommand cmd = new SqlCommand(insertData, connect))
                            {
                                // Add parameters to prevent SQL injection
                                 cmd.Parameters.AddWithValue("@firstName", guna2TextBox1.Text.Trim());
                                 cmd.Parameters.AddWithValue("@lastName", guna2TextBox2.Text.Trim());
                                 cmd.Parameters.AddWithValue("@Email", guna2TextBox3.Text.Trim());
                                 cmd.Parameters.AddWithValue("@phone", guna2TextBox4.Text.Trim());
                                 cmd.Parameters.AddWithValue("@password", guna2TextBox4.Text.Trim());
                         

                                // Execute the insert command
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Switch the form (assuming Form1 is your login form)
                                User_login lForm = new User_login();
                                lForm.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Catch any errors and display a meaningful message
                    MessageBox.Show("Error connecting to Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the connection
                    connect.Close();
                }
            }
        }  

           /* private void signup_showPass_CheckedChanged(object sender, EventArgs e)
            {
                // Show/Hide password based on the checkbox
                if (signup_showPass.Checked)
                {
                    signup_password.PasswordChar = '\0';  // Show password
                }
                else
                {
                    signup_password.PasswordChar = '*';  // Hide password
                }
            }*/


        /*private void guna2Button1_Click(object sender, EventArgs e)
        {
            // Initialize a message variable to store error messages
            string message = string.Empty;

            // Check if all necessary fields are filled
            if (string.IsNullOrEmpty(guna2TextBox1.Text) || // First Name
                string.IsNullOrEmpty(guna2TextBox2.Text) || // Last Name
                string.IsNullOrEmpty(guna2TextBox3.Text) || // Email
                string.IsNullOrEmpty(guna2TextBox4.Text) || // Phone
                string.IsNullOrEmpty(guna2TextBox5.Text))   // Password
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
                    string checkUser = "SELECT * FROM sign WHERE email = @Email OR (name = @FirstName AND lastname = @LastName)";
                    using (SqlCommand cmd = new SqlCommand(checkUser, connect))
                    {
                        // Adding parameters to the SQL query
                        cmd.Parameters.AddWithValue("@Email", guna2TextBox3.Text.Trim());
                        cmd.Parameters.AddWithValue("@FirstName", guna2TextBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("@LastName", guna2TextBox2.Text.Trim());

                        // Using SqlDataAdapter to fill the data table
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable table = new DataTable();
                        adapter.Fill(table);

                        // Check if the email or name already exists in the table
                        if (table.Rows.Count >= 1)
                        {
                            // Build error message for existing email or name
                            if (table.Rows[0]["email"].ToString() == guna2TextBox3.Text.Trim())
                            {
                                message += guna2TextBox3.Text + " is already registered. Please use a different email.\n";
                            }
                            if (table.Rows[0]["name"].ToString() == guna2TextBox1.Text.Trim() &&
                                table.Rows[0]["lastname"].ToString() == guna2TextBox2.Text.Trim())
                            {
                                message += "The name " + guna2TextBox1.Text + " " + guna2TextBox2.Text + " is already registered. Please use a different name.";
                            }

                            // Show the accumulated error messages
                            if (!string.IsNullOrEmpty(message))
                            {
                                MessageBox.Show(message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Insert new user data into the sign table
                            string insertData = "INSERT INTO sign (name, lastname, email, phone, password) VALUES (@firstName, @lastName, @Email, @phone, @password)";

                            using (SqlCommand insertCmd = new SqlCommand(insertData, connect))
                            {
                                // Add parameters to prevent SQL injection
                                insertCmd.Parameters.AddWithValue("@firstName", guna2TextBox1.Text.Trim());
                                insertCmd.Parameters.AddWithValue("@lastName", guna2TextBox2.Text.Trim());
                                insertCmd.Parameters.AddWithValue("@Email", guna2TextBox3.Text.Trim());
                                insertCmd.Parameters.AddWithValue("@phone", guna2TextBox4.Text.Trim());
                                insertCmd.Parameters.AddWithValue("@password", guna2TextBox5.Text.Trim()); // Assuming this is the password field

                                // Execute the insert command
                                insertCmd.ExecuteNonQuery();

                                MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Switch the form (assuming User_login is your login form)
                                User_login lForm = new User_login();
                                lForm.Show();
                                this.Hide();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Catch any errors and display a meaningful message
                    MessageBox.Show("Error connecting to Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Close the connection
                    connect.Close();
                }
            }
        }*/
 

private void guna2Button1_Click(object sender, EventArgs e)
    {
        string message = string.Empty;

        // Check if all necessary fields are filled
        if (string.IsNullOrEmpty(guna2TextBox1.Text) || string.IsNullOrEmpty(guna2TextBox2.Text) ||
        string.IsNullOrEmpty(guna2TextBox3.Text) || string.IsNullOrEmpty(guna2TextBox4.Text) ||
            string.IsNullOrEmpty(guna2TextBox5.Text))
        {
            MessageBox.Show("Please fill all blank fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; // Exit early
        }

        // Validate Email
        string email = guna2TextBox3.Text.Trim();
        if (!IsValidEmail(email))
        {
            MessageBox.Show("Please provide a valid Gmail address", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; // Exit early if email is invalid
        }

        // Validate Mobile Number (must be 11 digits)
        string phone = guna2TextBox4.Text.Trim();
        if (!IsValidPhoneNumber(phone))
        {
            MessageBox.Show("Mobile number must be exactly 11 digits", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return; // Exit early if phone number is invalid
        }
           
            string password = guna2TextBox5.Text.Trim();
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters long", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Exit early if password is too short
            }

            // Ensure the connection is not already open
            if (connect.State != ConnectionState.Open)
        {
            try
            {
                connect.Open();

                // Check if the email already exists in the database
                string checkEmail = "SELECT * FROM sign WHERE email = @Email";
                using (SqlCommand checkUser = new SqlCommand(checkEmail, connect))
                {
                    checkUser.Parameters.AddWithValue("@Email", email);

                    SqlDataAdapter adapter = new SqlDataAdapter(checkUser);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    if (table.Rows.Count >= 1)
                    {
                        MessageBox.Show("Email is already registered. Please use a different email.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // Insert new user data into the 'sign' table
                        string insertData = "INSERT INTO sign (name, lastname, email, phone, password) " +
                                            "VALUES(@firstName, @lastName, @Email, @phone, @password)";

                        using (SqlCommand cmd = new SqlCommand(insertData, connect))
                        {
                            cmd.Parameters.AddWithValue("@firstName", guna2TextBox1.Text.Trim());
                            cmd.Parameters.AddWithValue("@lastName", guna2TextBox2.Text.Trim());
                            cmd.Parameters.AddWithValue("@Email", email);
                            cmd.Parameters.AddWithValue("@phone", phone);
                            cmd.Parameters.AddWithValue("@password", guna2TextBox5.Text.Trim());

                            // Execute the insert command
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Registered successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Redirect to the login form after successful registration
                            User_login lForm = new User_login();
                            lForm.Show();
                            this.Hide();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to Database: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }
    }

    // Function to validate the email format (Must be a Gmail address)
    private bool IsValidEmail(string email)
    {
        string emailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
        return Regex.IsMatch(email, emailPattern);
    }

    // Function to validate that the phone number is exactly 11 digits
    private bool IsValidPhoneNumber(string phoneNumber)
    {
        // Check if phone number is 11 digits and numeric
        return phoneNumber.Length == 11 && long.TryParse(phoneNumber, out _);
    }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}   

