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

namespace SPG
{
    public partial class Membership_Form : Form
    {
        public Membership_Form()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2CustomRadioButton2_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            /* string username = guna2TextBox1.Text.Trim();
             string gender = guna2CustomRadioButton2.Checked ? "Male" : (guna2CustomRadioButton1.Checked ? "Female" : "");
             DateTime dateOfBirth = guna2DateTimePicker1.Value;
             string phone = guna2TextBox2.Text.Trim();
             string email = guna2TextBox3.Text.Trim();
             DateTime joinDate = guna2DateTimePicker2.Value;
             string address = richTextBox1.Text.Trim();

             // Check for empty fields
             if (string.IsNullOrEmpty(username))
             {
                 MessageBox.Show("Please enter a username.");
                 return;
             }

             if (string.IsNullOrEmpty(phone))
             {
                 MessageBox.Show("Please enter a phone number.");
                 return;
             }

             if (string.IsNullOrEmpty(email))
             {
                 MessageBox.Show("Please enter an email address.");
                 return;
             }

             if (string.IsNullOrEmpty(address))
             {
                 MessageBox.Show("Please enter an address.");
                 return;
             }

             if (string.IsNullOrEmpty(gender))
             {
                 MessageBox.Show("Please select a gender.");
                 return;
             }

             //Check if gym time is selected
             if (guna2ComboBox1.SelectedItem == null)
             {
                 MessageBox.Show("Please select a valid gym time.");
                 return;
             }

             // Extract the gym time from the ComboBox and parse it
             string gymTimeString = guna2ComboBox1.SelectedItem.ToString();
             TimeSpan gymTime;

             // Parse the string to TimeSpan (if it's in HH:mm format)
             if (!TimeSpan.TryParse(gymTimeString, out gymTime))
             {
                 MessageBox.Show("Please select a valid gym time.");
                 return;
             }

             // Validate Phone Number
             if (!IsValidPhoneNumber(phone))
             {
                 MessageBox.Show("Phone number must be exactly 11 digits.");
                 return;
             }

             // Validate Email
             if (!IsValidEmail(email))
             {
                 MessageBox.Show("Email format is invalid.");
                 return;
             }

             // Proceed with database insert
             try
             {
                 using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\sigup.mdf;Integrated Security=True;Connect Timeout=30"))
                 {
                     string query = "INSERT INTO mem (Username, Gender, DateOfBirth, Phone, Email, JoinDate, GymTime, Address) " +
                                    "VALUES (@Username, @Gender, @DateOfBirth, @Phone, @Email, @JoinDate, @GymTime, @Address)";

                     using (SqlCommand command = new SqlCommand(query, connect))
                     {
                         // Ensure all parameters are added correctly
                         command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                         command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
                         command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth;
                         command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
                         command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                         command.Parameters.Add("@JoinDate", SqlDbType.Date).Value = joinDate;

                         // Make sure gymTime is properly added
                         command.Parameters.Add("@GymTime", SqlDbType.Time).Value = gymTime;

                         command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;

                         connect.Open();
                         command.ExecuteNonQuery();
                     }
                 }

                 MessageBox.Show("Member added successfully!");
             }
             catch (SqlException ex)
             {
                 MessageBox.Show("An error occurred while adding the member: " + ex.Message);
             }
         }

         // Method to validate phone number (must be 11 digits and numeric)
         private bool IsValidPhoneNumber(string phone)
         {
             return phone.Length == 11 && long.TryParse(phone, out _);
         }

         // Method to validate email format
         private bool IsValidEmail(string email)
         {
             var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
             return Regex.IsMatch(email, emailPattern);
         }*/



            string username = guna2TextBox1.Text.Trim();
            string gender = guna2CustomRadioButton2.Checked ? "Male" : (guna2CustomRadioButton1.Checked ? "Female" : "");
            DateTime dateOfBirth = guna2DateTimePicker1.Value;
            string phone = guna2TextBox2.Text.Trim();
            string email = guna2TextBox3.Text.Trim();
            DateTime joinDate = guna2DateTimePicker2.Value;
            string address = richTextBox1.Text.Trim();

            // Check for empty fields
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter a username.");
                return;
            }

            if (string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter an email address.");
                return;
            }

            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Please enter an address.");
                return;
            }

            if (string.IsNullOrEmpty(gender))
            {
                MessageBox.Show("Please select a gender.");
                return;
            }

            // Check if gym time is selected
            if (guna2ComboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a valid gym time.");
                return;
            }

            // Extract the gym time from the ComboBox
            string gymTimeString = guna2ComboBox1.SelectedItem.ToString();
            string fullGymTimeString = gymTimeString;
            // Split the gym time string to get the start time and end time
            /* string[] timeRange = gymTimeString.Split('-');
                 if (timeRange.Length != 2)
                 {
                     MessageBox.Show("Please select a valid gym time format.");
                     return;
                 }

                 // Parse the start time
                 TimeSpan gymStartTime;
                 if (!TryParseAMPMTime(timeRange[0].Trim(), out gymStartTime))
                 {
                     MessageBox.Show("Invalid start time.");
                     return;
                 }
             TimeSpan gymEndTime;
             if (!TryParseAMPMTime(timeRange[1].Trim(), out gymEndTime))
             {
                 MessageBox.Show("Invalid end time.");
                 return;
             }

             // Optional: Parse the end time if needed
             // TimeSpan gymEndTime;
             // if (!TryParseAMPMTime(timeRange[1].Trim(), out gymEndTime))
             // {
             //     MessageBox.Show("Invalid end time.");
             //     return;
             // }*/
            if (guna2ComboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a membership package.");
                return;
            }
            string membershipPackage = guna2ComboBox2.SelectedItem.ToString();


            // Validate Phone Number
            if (!IsValidPhoneNumber(phone))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return;
            }

            // Validate Email
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Email format is invalid.");
                return;
            }

            // Proceed with database insert
            try
            {
                using (SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\HP\Documents\registration.mdf;Integrated Security=True;Connect Timeout=30"))
                {
                    string query = "INSERT INTO mem (Username, Gender, DateOfBirth, Phone, Email, JoinDate, GymTime, Address, package) " +
                                   "VALUES (@Username, @Gender, @DateOfBirth, @Phone, @Email, @JoinDate, @GymTime, @Address ,@MembershipPackage )";

                    using (SqlCommand command = new SqlCommand(query, connect))
                    {
                        // Ensure all parameters are added correctly
                        command.Parameters.Add("@Username", SqlDbType.NVarChar).Value = username;
                        command.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = gender;
                        command.Parameters.Add("@DateOfBirth", SqlDbType.Date).Value = dateOfBirth;
                        command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = phone;
                        command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
                        command.Parameters.Add("@JoinDate", SqlDbType.Date).Value = joinDate;

                        // Make sure gym time is properly added (storing only the start time for now)
                        // command.Parameters.Add("@GymTime", SqlDbType.NVarChar).Value = gymStartTime;
                        // command.Parameters.Add("@GymTime", SqlDbType.Time).Value = gymStartTime; // Store start time
                        // command.Parameters.Add("@GymEndTime", SqlDbType.NVarChar).Value = gymEndTime; // Store end time
                        command.Parameters.Add("@GymTime", SqlDbType.NVarChar).Value = fullGymTimeString;
                        command.Parameters.Add("@Address", SqlDbType.NVarChar).Value = address;
                        // Change this line in the InsertMember method
                        // command.Parameters.Add("@GymTime", SqlDbType.NVarChar).Value = gymTimeString; // Store the entire gym time string
                        command.Parameters.Add("@MembershipPackage", SqlDbType.NVarChar).Value = membershipPackage;



                        connect.Open();
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Please Make a Payment!");
                payment_method pm = new payment_method();
                pm.Show();
                this.Hide();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while adding the member: " + ex.Message);
            }
        }

        // Method to validate phone number (must be 11 digits and numeric)
        private bool IsValidPhoneNumber(string phone)
        {
            return phone.Length == 11 && long.TryParse(phone, out _);
        }

        // Method to validate email format
        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Method to try parsing AM/PM time format to TimeSpan
        private bool TryParseAMPMTime(string time, out TimeSpan result)
        {
            // Try to parse the time string using DateTime
            DateTime dt;
            if (DateTime.TryParse(time, out dt))
            {
                result = dt.TimeOfDay; // Get TimeSpan from DateTime
                return true;
            }
            result = TimeSpan.Zero;
            return false; // Parsing failed

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Payment pa = new Payment();
            pa.Show();
        }
    }
}
