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
    public partial class EditMovie : Form
    {
        // Fetch the connection string from App.config
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;
        private string movieID;

        public EditMovie(string movieID)
        {
            InitializeComponent();
            this.movieID = movieID;
            LoadMovieDetails();
        }

        private void LoadMovieDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT MovieName, DistributionFee, MovieType, NumOfCopies FROM Movie WHERE MovieID = @MovieID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieID", movieID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate text boxes with existing data
                                TitleAdd.Text = reader["MovieName"].ToString();
                                FeeAdd.Text = reader["DistributionFee"].ToString();
                                TypeAdd.Text = reader["MovieType"].ToString();
                                CopiesAdd.Text = reader["NumOfCopies"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading movie details: {ex.Message}");
            }
        }
        private void Save_Click(object sender, EventArgs e)
        {
            // Validate that all fields are filled
            if (string.IsNullOrWhiteSpace(TitleAdd.Text) ||
                string.IsNullOrWhiteSpace(FeeAdd.Text) ||
                string.IsNullOrWhiteSpace(TypeAdd.Text) ||
                string.IsNullOrWhiteSpace(CopiesAdd.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL Update query to update the Movie record
                    string query = "UPDATE Movie SET MovieName = @Title, DistributionFee = @Fee, MovieType = @Type, NumOfCopies = @Copies WHERE MovieID = @MovieID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to avoid SQL injection
                        command.Parameters.AddWithValue("@Title", TitleAdd.Text.Trim());
                        command.Parameters.AddWithValue("@Fee", Convert.ToDecimal(FeeAdd.Text.Trim()));
                        command.Parameters.AddWithValue("@Type", TypeAdd.Text.Trim());
                        command.Parameters.AddWithValue("@Copies", Convert.ToInt32(CopiesAdd.Text.Trim()));
                        command.Parameters.AddWithValue("@MovieID", movieID);

                        // Execute the update command
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Movie details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Navigate to MenuForm
                            MovieForm movieForm = new MovieForm();
                            movieForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Check if the MovieID is correct.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating movie: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            MovieForm movieForm = new MovieForm();
            movieForm.Show();
            this.Hide();
        }
    }
}
