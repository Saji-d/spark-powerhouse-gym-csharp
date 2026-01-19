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
    public partial class Bkash : Form
    {
        public Bkash()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

            string phoneNumber = guna2TextBox1.Text.Trim();

           
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter a phone number.");
                return;
            }

       
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.");
                return;
            }

        
            int generatedOtp = GenerateOTP();
            MessageBox.Show($"OTP has been sent to {phoneNumber}. Your OTP is: {generatedOtp} ");

            string enteredOtp = PromptUserForOTP();

           
            if (!IsValidOTP(enteredOtp, generatedOtp))
            {
                MessageBox.Show("Invalid OTP. Please try again.");
                return;
            }

           
            MessageBox.Show("Payment successful!");
            this.Hide();
            HomePage ho = new HomePage();
            ho.Show();
        }

       
        private int GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999); 
        }

 
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 11 && long.TryParse(phoneNumber, out _);
        }

      
        private bool IsValidOTP(string enteredOtp, int generatedOtp)
        {
            return enteredOtp == generatedOtp.ToString();
        }

        
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}      
    
