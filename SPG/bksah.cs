using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
using Twilio;

namespace SPG
{
    public partial class bksah : Form
    {
        public bksah()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string phoneNumber = guna2TextBox1.Text.Trim();

            // Check if the text box is filled
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

            // Validate that the phone number is exactly 11 digits
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return;
            }

            // Generate OTP and simulate sending it to the phone number
            int generatedOtp = GenerateOTP();
            MessageBox.Show($"OTP has been sent to {phoneNumber}. Your OTP is: {generatedOtp} ");

            // Prompt the user to enter the OTP
            string enteredOtp = PromptUserForOTP();

            // Validate the OTP entered by the user
            if (!IsValidOTP(enteredOtp, generatedOtp))
            {
                MessageBox.Show("Invalid OTP. Please try again.");
                return;
            }

            // If OTP validation passes, proceed with payment processing
            MessageBox.Show("Payment successful!");
            this.Hide();
            HomePage ho = new HomePage();
            ho.Show();
        }

        // Generate OTP (random 6-digit number)
        private int GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999); // Generates a random OTP between 100000 and 999999
        }

        // Validate that the phone number is exactly 11 digits
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 11 && long.TryParse(phoneNumber, out _);
        }

        // Validate that the entered OTP matches the generated OTP
        private bool IsValidOTP(string enteredOtp, int generatedOtp)
        {
            return enteredOtp == generatedOtp.ToString();
        }

        // Prompt the user to enter the OTP in a dialog
        private string PromptUserForOTP()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 250;
                prompt.Height = 150;
                prompt.Text = "Enter OTP";

                Label textLabel = new Label() { Left = 20, Top = 20, Text = "Please enter the OTP:" };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 180 };

                Button confirmation = new Button() { Text = "OK", Left = 120, Width = 80, Top = 80, DialogResult = DialogResult.OK };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);

                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : "";
            }
        }
 }   }      
    

