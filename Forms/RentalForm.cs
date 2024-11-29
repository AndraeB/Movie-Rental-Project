using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalProject
{
    public partial class RentalForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        public RentalForm()
        {
            InitializeComponent();
            SetupDataGridViews();  // Call to setup DataGridView columns
            GoButton.Click += GoButton_Click;  // Hook up GoButton click event
            Customer.SelectionChanged += Customer_SelectionChanged;  // Handle selection change in Customer DataGridView
        }

        private void SetupDataGridViews()
        {
            // Configure Customer DataGridView
            Customer.ColumnCount = 4;  // You have 4 columns now (Account, Name, Phone Number, Customer ID)

            Customer.Columns[0].Name = "Account #";
            Customer.Columns[1].Name = "Name";
            Customer.Columns[2].Name = "Phone Number";
            Customer.Columns[3].Name = "CustomerID";  // Add CustomerID as a column

            // Optionally set headers
            Customer.Columns[0].HeaderText = "Account #";
            Customer.Columns[1].HeaderText = "Full Name";
            Customer.Columns[2].HeaderText = "Phone Number";

            // Make columns read-only
            foreach (DataGridViewColumn column in Customer.Columns)
            {
                column.ReadOnly = true;
            }

            // Set the DataGridView to automatically adjust columns to fill the space
            Customer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Optional: Set the selection mode and other properties if needed
            Customer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Configure Queue DataGridView
            Queue.ColumnCount = 3;
            Queue.Columns[0].Name = "Movie Name";
            Queue.Columns[1].Name = "Distribution Fee";
            Queue.Columns[2].Name = "Availability";

            foreach (DataGridViewColumn column in Queue.Columns)
            {
                column.ReadOnly = true;
            }

            Queue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            // Retrieve input from text boxes
            string firstName = CustName.Text.Trim();
            string lastName = Last.Text.Trim();
            string phoneNumber = Phone.Text.Trim();

            // Validate input
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("All fields (First Name, Last Name, and Phone Number) must be filled out.",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Query the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Modified query to fetch AccountNumber, FirstName, LastName, PhoneNumber, and CustomerID
                    string customerQuery = @"
                SELECT c.AccountNumber, c.FirstName, c.LastName, cp.PhoneNumber, c.CustomerID
                FROM Customer c
                INNER JOIN Cust_Phone cp ON c.CustomerID = cp.CustomerID
                WHERE c.FirstName = @FirstName AND c.LastName = @LastName AND cp.PhoneNumber = @PhoneNumber";

                    using (SqlCommand command = new SqlCommand(customerQuery, connection))
                    {
                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);

                        // Execute query and fetch results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing rows in DataGridView
                            Customer.Rows.Clear();

                            // Populate the DataGridView with results
                            while (reader.Read())
                            {
                                Customer.Rows.Add(
                                    reader["AccountNumber"].ToString(),  // Display AccountNumber
                                    $"{reader["FirstName"]} {reader["LastName"]}",  // Full Name
                                    reader["PhoneNumber"].ToString(),  // PhoneNumber
                                    reader["CustomerID"].ToString()   // CustomerID
                                );
                            }

                            // Show a message if no results were found
                            if (Customer.Rows.Count == 0)
                            {
                                MessageBox.Show("No matching customer found.", "Search Results",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while querying the database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Customer_SelectionChanged(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (Customer.SelectedRows.Count > 0)
            {
                // Get the selected CustomerID
                string selectedCustomerID = Customer.SelectedRows[0].Cells["CustomerID"].Value.ToString();

                // Call method to query Queue_Up and Movie tables
                PopulateQueue(selectedCustomerID);
            }
        }

        private void PopulateQueue(string customerID)
        {
            // Clear existing rows in Queue DataGridView
            Queue.Rows.Clear();

            // Query the Queue_Up table to get all MovieIDs for the selected CustomerID
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query the Queue_Up table to get all MovieIDs associated with the selected CustomerID
                    string queueUpQuery = @"
                        SELECT MovieID 
                        FROM Queue_Up 
                        WHERE CustomerID = @CustomerID";

                    using (SqlCommand command = new SqlCommand(queueUpQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", customerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Loop through each MovieID in the Queue_Up table
                            while (reader.Read())
                            {
                                string movieID = reader["MovieID"].ToString();

                                // Query the Movie table for each MovieID to get the MovieName, DistributionFee, and MovieAvailability
                                PopulateMovieDetails(movieID);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while querying the database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateMovieDetails(string movieID)
        {
            // Open a new connection for the Movie query
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query the Movie table to get the MovieName, DistributionFee, and MovieAvailability for the MovieID
                    string movieQuery = @"
                        SELECT MovieName, DistributionFee, MovieAvailability 
                        FROM Movie 
                        WHERE MovieID = @MovieID";

                    using (SqlCommand command = new SqlCommand(movieQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MovieID", movieID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Add the movie details to the Queue DataGridView
                                Queue.Rows.Add(
                                    reader["MovieName"].ToString(),
                                    reader["DistributionFee"].ToString(),
                                    reader["MovieAvailability"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while querying the database: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}
