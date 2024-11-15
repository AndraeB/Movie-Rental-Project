using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalProject.Forms
{
    public partial class AddMovie : Form
    {
        // Connection string for database
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;
        public AddMovie()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes
            string movieTitle = TitleAdd.Text.Trim();
            string movieFee = FeeAdd.Text.Trim();
            string movieType = TypeAdd.Text.Trim();
            string movieCopies = CopiesAdd.Text.Trim();

            
        

            // Validate the fields (basic check for empty fields)
            if (string.IsNullOrEmpty(movieTitle) || string.IsNullOrEmpty(movieFee) || string.IsNullOrEmpty(movieType) || string.IsNullOrEmpty(movieCopies))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // Insert the new movie into the database
            InsertMovieToDatabase(movieTitle, movieFee, movieType, movieCopies);
        }

        private void InsertMovieToDatabase(string movieTitle, string movieFee, string movieType, string movieCopies)
        {
            try
            {
                // Open connection to database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL Insert statement
                    string query = "INSERT INTO Movie (MovieName, DistributionFee, MovieType, NumOfCopies) " +
                                   "VALUES (@MovieName, @DistributionFee, @MovieType, @NumOfCopies)";

                    // Execute SQL command with parameters
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        
                        command.Parameters.AddWithValue("@MovieName", movieTitle);
                        command.Parameters.AddWithValue("@DistributionFee", movieFee);
                        command.Parameters.AddWithValue("@MovieType", movieType);
                        command.Parameters.AddWithValue("@NumOfCopies", movieCopies);
                      

                        // Execute the insert command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Movie added successfully!");
                            MovieForm movieForm = new MovieForm();
                            movieForm.Show();
                            this.Hide();  // Close the form after adding the movie
                        }
                        else
                        {
                            MessageBox.Show("An error occurred while adding the movie.");
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
    

