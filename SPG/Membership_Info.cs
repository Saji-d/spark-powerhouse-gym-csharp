using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SPG
{
    public partial class Membership_Info : Form
    {
     
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"E:\\AIUB\\My PROJECTS\\C# PROJECT\\Spark Powerhouse Gym\\Spark Powerhouse Gym\\SPG\\SPG\\SPG.mdf\";Integrated Security=True;Connect Timeout=30"; // For Windows Authentication

        public Membership_Info()
        {
            InitializeComponent();
         
            this.dataGridView1.DataError += new DataGridViewDataErrorEventHandler(dataGridView1_DataError);
            
            this.dataGridView1.CellFormatting += new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        private void Membership_Info_Load(object sender, EventArgs e)
        {
     
            LoadMembershipData();
        }

      
        private void LoadMembershipData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); 

                    string query = "SELECT * FROM Membership";

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
                MessageBox.Show("Please select a row to insert!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dataGridView1.SelectedRows[0];

            string username = selectedRow.Cells[0].Value.ToString().Trim();
            string gender = selectedRow.Cells[1].Value.ToString().Trim();
            string dateOfBirthStr = selectedRow.Cells[2].Value.ToString().Trim();
            string phone = selectedRow.Cells[3].Value.ToString().Trim();
            string email = selectedRow.Cells[4].Value.ToString().Trim();
            string joinDateStr = selectedRow.Cells[5].Value.ToString().Trim();
            string gymTime = selectedRow.Cells[6].Value.ToString().Trim();
            string address = selectedRow.Cells[7].Value.ToString().Trim();
            string package = selectedRow.Cells[8].Value.ToString().Trim();

     
            DateTime dateOfBirth, joinDate;
            if (!DateTime.TryParse(dateOfBirthStr, out dateOfBirth))
            {
                MessageBox.Show("Invalid Date of Birth format. Please enter a valid date.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(joinDateStr, out joinDate))
            {
                MessageBox.Show("Invalid Join Date format. Please enter a valid date.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

       
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(gymTime) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(package))
            {
                MessageBox.Show("All fields must be filled out!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                  
                    string checkQuery = "SELECT COUNT(1) FROM Membership WHERE username = @username";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@username", username);
                        int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("This username already exists. Please use a different username.", "Duplicate Entry", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    string insertQuery = "INSERT INTO Membership (username, gender, dateofbirth, phone, email, joindate, gymtime, address, package) " +
                                         "VALUES (@username, @gender, @dateofbirth, @phone, @email, @joindate, @gymtime, @address, @package)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@username", username);
                        insertCommand.Parameters.AddWithValue("@gender", gender);
                        insertCommand.Parameters.AddWithValue("@dateofbirth", dateOfBirth);
                        insertCommand.Parameters.AddWithValue("@phone", phone);
                        insertCommand.Parameters.AddWithValue("@email", email);
                        insertCommand.Parameters.AddWithValue("@joindate", joinDate);
                        insertCommand.Parameters.AddWithValue("@gymtime", gymTime);
                        insertCommand.Parameters.AddWithValue("@address", address);
                        insertCommand.Parameters.AddWithValue("@package", package);

                        int rowsAffected = insertCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Membership added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMembershipData();
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

   /*     private void guna2Button2_Click(object sender, EventArgs e)
        {
          
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

    
            var selectedRow = dataGridView1.SelectedRows[0];

            string username = selectedRow.Cells["username"].Value.ToString().Trim();
            string gender = selectedRow.Cells["gender"].Value.ToString().Trim();
            string dateOfBirthStr = selectedRow.Cells["dateofbirth"].Value.ToString().Trim();
            string phone = selectedRow.Cells["phone"].Value.ToString().Trim();
            string email = selectedRow.Cells["email"].Value.ToString().Trim();
            string joinDateStr = selectedRow.Cells["joindate"].Value.ToString().Trim();
            string gymTime = selectedRow.Cells["gymtime"].Value.ToString().Trim();
            string address = selectedRow.Cells["address"].Value.ToString().Trim();
            string package = selectedRow.Cells["package"].Value.ToString().Trim();

         
            DateTime dateOfBirth, joinDate;
            if (!DateTime.TryParse(dateOfBirthStr, out dateOfBirth))
            {
                MessageBox.Show("Invalid Date of Birth format. Please enter a valid date.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!DateTime.TryParse(joinDateStr, out joinDate))
            {
                MessageBox.Show("Invalid Join Date format. Please enter a valid date.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

   
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(gender) ||
                string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(gymTime) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(package))
            {
                MessageBox.Show("All fields must be filled out!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateQuery = "UPDATE Membership SET gender = @gender, dateofbirth = @dateofbirth, phone = @phone, " +
                                         "email = @email, joindate = @joindate, gymtime = @gymtime, address = @address, package = @package " +
                                         "WHERE username = @username";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@username", username);
                        updateCommand.Parameters.AddWithValue("@gender", gender);
                        updateCommand.Parameters.AddWithValue("@dateofbirth", dateOfBirth);
                        updateCommand.Parameters.AddWithValue("@phone", phone);
                        updateCommand.Parameters.AddWithValue("@email", email);
                        updateCommand.Parameters.AddWithValue("@joindate", joinDate);
                        updateCommand.Parameters.AddWithValue("@gymtime", gymTime);
                        updateCommand.Parameters.AddWithValue("@address", address);
                        updateCommand.Parameters.AddWithValue("@package", package);

                        
                        int rowsAffected = updateCommand.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Membership updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadMembershipData();  
                        }
                        else
                        {
                            MessageBox.Show("Update failed! No changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        */


        
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Invalid input. Please check the data format.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            e.Cancel = false;  
        }

       
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "dateofbirth" || dataGridView1.Columns[e.ColumnIndex].Name == "joindate")
            {
                if (e.Value != null && e.Value is DateTime dt)
                {
                    e.Value = dt.ToString("yyyy-MM-dd"); 
                    e.FormattingApplied = true;
                }
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
                string username = selectedRow.Cells[0].Value.ToString().Trim(); 

                var confirmResult = MessageBox.Show("Are you sure you want to delete this member?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            
                            string deleteQuery = "DELETE FROM Membership WHERE username = @username";
                            using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                            {
                                deleteCommand.Parameters.AddWithValue("@username", username);
                                int rowsAffected = deleteCommand.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Membership deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadMembershipData(); 
                                }
                                else
                                {
                                    MessageBox.Show("Delete failed. Member not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
              
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please select a row to update!", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

             
                var selectedRow = dataGridView1.SelectedRows[0];

                string username = selectedRow.Cells[0].Value.ToString().Trim();
                string gender = selectedRow.Cells[1].Value.ToString().Trim();
                string dateOfBirthStr = selectedRow.Cells[2].Value.ToString().Trim();
                string phone = selectedRow.Cells[3].Value.ToString().Trim();
                string email = selectedRow.Cells[4].Value.ToString().Trim();
                string joinDateStr = selectedRow.Cells[5].Value.ToString().Trim();
                string gymTime = selectedRow.Cells[6].Value.ToString().Trim();
                string address = selectedRow.Cells[7].Value.ToString().Trim();
                string package = selectedRow.Cells[8].Value.ToString().Trim();

                
                DateTime dateOfBirth, joinDate;
                if (!DateTime.TryParse(dateOfBirthStr, out dateOfBirth))
                {
                    MessageBox.Show("Invalid Date of Birth format. Please enter a valid date.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!DateTime.TryParse(joinDateStr, out joinDate))
                {
                    MessageBox.Show("Invalid Join Date format. Please enter a valid date.", "Format Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                
                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(gender) ||
                    string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(gymTime) || string.IsNullOrWhiteSpace(address) || string.IsNullOrWhiteSpace(package))
                {
                    MessageBox.Show("All fields must be filled out!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        
                        string updateQuery = "UPDATE Membership SET gender = @gender, dateofbirth = @dateofbirth, phone = @phone, " +
                                             "email = @email, joindate = @joindate, gymtime = @gymtime, address = @address, package = @package " +
                                             "WHERE username = @username";
                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@username", username);
                            updateCommand.Parameters.AddWithValue("@gender", gender);
                            updateCommand.Parameters.AddWithValue("@dateofbirth", dateOfBirth);
                            updateCommand.Parameters.AddWithValue("@phone", phone);
                            updateCommand.Parameters.AddWithValue("@email", email);
                            updateCommand.Parameters.AddWithValue("@joindate", joinDate);
                            updateCommand.Parameters.AddWithValue("@gymtime", gymTime);
                            updateCommand.Parameters.AddWithValue("@address", address);
                            updateCommand.Parameters.AddWithValue("@package", package);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Membership updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadMembershipData();  
                            }
                            else
                            {
                                MessageBox.Show("Update failed! No changes were made.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        }
    }
    

