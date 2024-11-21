using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalProject
{
    public partial class RentalForm : Form
    {
        // Connection string for database
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;
        public RentalForm()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes
            string movieTitle = movieName.Text.Trim();
            string custID = customerID.Text.Trim();
            string checkoutTime = DateTime.UtcNow.ToString();
            string returnTime = DateTime.UtcNow.AddDays(14).ToString();

            // Validate the fields (basic check for empty fields)
            if (string.IsNullOrEmpty(movieTitle) || string.IsNullOrEmpty(custID))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // Insert the new order into the database
            InsertOrderToDatabase(movieTitle, custID, checkoutTime, returnTime);
        }

        private void InsertOrderToDatabase(string movieTitle, string custID, string checkoutTime, string returnTime)
        {
            try
            {
                // Open connection to database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL Insert statement
                    string query = "INSERT INTO Ordr (CheckoutDateTime, ReturnDateTime, MovieName, CustomerID, EmployeeID) " +
                                   "VALUES (@checkoutTime, @returnTime, @MovieTitle, @custID, @EmployeeID)";

                    // Execute SQL command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@checkoutTime", checkoutTime);
                        command.Parameters.AddWithValue("@returnTime", returnTime);
                        command.Parameters.AddWithValue("@MovieTitle", movieTitle);
                        command.Parameters.AddWithValue("@custID", custID);
                        command.Parameters.AddWithValue("@EmployeeID", Global.GlobalEmpID);

                        // Execute the insert command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order added successfully!");
                            MenuForm menuForm = new MenuForm();
                            menuForm.Show();
                            this.Hide();  // Close the form after adding the order
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while adding the order.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting data: {ex.Message}");
            }
        }
    }
}
