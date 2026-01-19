using System;
using System.Data;
using System.Data.SqlClient; 
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SPG
{
    public partial class SignUp_Info : Form
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\AIUB\\My PROJECTS\\C# PROJECT\\Spark Powerhouse Gym\\Spark Powerhouse Gym\\SPG\\SPG\\SPG.mdf\";Integrated Security=True;Connect Timeout=30"; // For Windows Authentication

        public SignUp_Info()
        {
            InitializeComponent();
        }

        private void SignUp_Info_Load(object sender, EventArgs e)
        {
            LoadSignUpData();
        }

        private void LoadSignUpData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();  

                    
                    string query = "SELECT * FROM SignUp";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);  

                        dataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void guna2Button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row from the DataGridView to insert!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            var selectedRow = dataGridView1.SelectedRows[0];

            string firstName = selectedRow.Cells[0].Value.ToString().Trim();
            string lastName = selectedRow.Cells[1].Value.ToString().Trim();
            string email = selectedRow.Cells[2].Value.ToString().Trim();
            string phone = selectedRow.Cells[3].Value.ToString().Trim();
            string password = selectedRow.Cells[4].Value.ToString().Trim();

         
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("All fields must be filled out!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Invalid email format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (!Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (password.Length != 8)
            {
                MessageBox.Show("Password must be exactly 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                   
                    string fetchEmailsQuery = "SELECT Email FROM SignUp";
                    using (SqlCommand fetchCommand = new SqlCommand(fetchEmailsQuery, connection))
                    {
                        SqlDataReader reader = fetchCommand.ExecuteReader();
                        string existingEmails = "Existing Emails:\n";
                        while (reader.Read())
                        {
                            existingEmails += reader["Email"].ToString() + "\n";
                        }
                        MessageBox.Show(existingEmails, "Debugging Existing Emails", MessageBoxButtons.OK);
                        reader.Close();
                    }

                  
                    string checkQuery = "SELECT COUNT(1) FROM SignUp WHERE LOWER(Email) = LOWER(@Email)";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@Email", email);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    
                        MessageBox.Show($"Checking for email: '{email}' - Count: {count}");

                        if (count > 0)
                        {
                            MessageBox.Show("This email already exists. Please use a different email.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                
                    string insertQuery = "INSERT INTO SignUp (FirstName, LastName, Email, PhoneNumber, Password) VALUES (@FirstName, @LastName, @Email, @PhoneNumber, @Password)";
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@PhoneNumber", phone);
                        command.Parameters.AddWithValue("@Password", password);

                      
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadSignUpData();
                        }
                        else
                        {
                            MessageBox.Show("Insert failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
        
            
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                var selectedRow = dataGridView1.SelectedRows[0];

                string firstName = selectedRow.Cells[0].Value.ToString().Trim();
                string lastName = selectedRow.Cells[1].Value.ToString().Trim();
                string email = selectedRow.Cells[2].Value.ToString().Trim();  
                string phone = selectedRow.Cells[3].Value.ToString().Trim();
                string password = selectedRow.Cells[4].Value.ToString().Trim();

               
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("All fields must be filled out!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@gmail\.com$"))
            {
                MessageBox.Show("Invalid email format!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

   
            if (!Regex.IsMatch(phone, @"^\d{11}$"))
            {
                MessageBox.Show("Phone number must be exactly 11 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (password.Length != 8)
            {
                MessageBox.Show("Password must be exactly 8 characters long.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string checkQuery = "SELECT COUNT(1) FROM SignUp WHERE LOWER(Email) = LOWER(@Email)";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Email", email);
                            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (count == 0)
                            {
                                MessageBox.Show("No member found with the given email. Please check again.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                     
                        string updateQuery = "UPDATE SignUp SET FirstName = @FirstName, LastName = @LastName, PhoneNumber = @PhoneNumber, Password = @Password WHERE LOWER(Email) = LOWER(@Email)";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                         
                            updateCommand.Parameters.AddWithValue("@FirstName", firstName);
                            updateCommand.Parameters.AddWithValue("@LastName", lastName);
                            updateCommand.Parameters.AddWithValue("@Email", email);
                            updateCommand.Parameters.AddWithValue("@PhoneNumber", phone);
                            updateCommand.Parameters.AddWithValue("@Password", password);

                      
                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Member updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadSignUpData();  
                            }
                            else
                            {
                                MessageBox.Show("Update failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
              
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to delete!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            
                var selectedRow = dataGridView1.SelectedRows[0];
                string email = selectedRow.Cells[2].Value.ToString();  

                DialogResult dialogResult = MessageBox.Show($"Are you sure you want to delete the member with email: {email}?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult != DialogResult.Yes)
                {
                    return;  
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                     
                        string checkQuery = "SELECT COUNT(1) FROM SignUp WHERE LOWER(Email) = LOWER(@Email)";
                        using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                        {
                            checkCommand.Parameters.AddWithValue("@Email", email);
                            int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                            if (count == 0)
                            {
                                MessageBox.Show("No member found with the given email. Please check again.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                
                        string deleteQuery = "DELETE FROM SignUp WHERE LOWER(Email) = LOWER(@Email)";
                        using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                        {
                          
                            deleteCommand.Parameters.AddWithValue("@Email", email);

                       
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Member deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadSignUpData(); 
                            }
                            else
                            {
                                MessageBox.Show("Delete failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show($"SQL Error: {sqlEx.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Dashboard ad = new Admin_Dashboard();
            ad.Show();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
    

