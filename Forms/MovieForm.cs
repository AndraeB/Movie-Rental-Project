using MovieRentalProject.Forms;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalProject
{
    public partial class MovieForm : Form
    {
        // Fetch the connection string from App.config
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        public MovieForm()
        {
            InitializeComponent();
            SetupDataGridView();
            //LoadMovieData();
        }

        private void SetupDataGridView()
        {
            // Configure the DataGridView
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "MovieID";
            dataGridView1.Columns[1].Name = "Title";
            dataGridView1.Columns[2].Name = "Fee";
            dataGridView1.Columns[3].Name = "Type";
            dataGridView1.Columns[4].Name = "Copies";

            // Optionally, make columns read-only
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.ReadOnly = true;
            }

            // Set styles for the header band
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridView1.EnableHeadersVisualStyles = false;

            // Set other properties
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadMovieData(string searchTitle = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Corrected query with proper spacing and formatting
                    string query = "SELECT MovieID, MovieName, DistributionFee, MovieType, NumOfCopies " +
                                   "FROM Movie " +
                                   "WHERE MovieName LIKE @SearchTitle + '%'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTitle", searchTitle);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing rows before adding new data
                            dataGridView1.Rows.Clear();

                            while (reader.Read())
                            {
                                dataGridView1.Rows.Add(
                                    reader["MovieID"].ToString(),
                                    reader["MovieName"].ToString(),
                                    reader["DistributionFee"].ToString(),
                                    reader["MovieType"].ToString(),
                                    reader["NumOfCopies"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }


        private void searchbutton_Click(object sender, EventArgs e)
        {
            string searchTitle = TitleSearch.Text.Trim();
            LoadMovieData(searchTitle);
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the MovieID from the selected row (assuming it's the first column)
                string selectedMovieID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                // Open EditMovie form and pass the selected MovieID
                EditMovie editMovie = new EditMovie(selectedMovieID);
                editMovie.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please select a movie to edit.");
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            // Check if a row is selected
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Get the MovieID from the selected row (assuming it's the first column)
                string selectedMovieID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                // Display a confirmation dialog
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to delete this movie?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // User clicked Yes, proceed with deletion
                    DeleteMovieFromDatabase(selectedMovieID);

                    // Refresh the DataGridView
                    LoadMovieData();
                }
            }
            else
            {
                MessageBox.Show("Please select a movie to delete.");
            }
        }

        private void DeleteMovieFromDatabase(string movieID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Movie WHERE MovieID = @MovieID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MovieID", movieID);
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Movie deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No records were deleted. Please check the MovieID.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting movie: {ex.Message}");
            }
        }

        private void addmovie_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add A Movie clicked.");
            Forms.AddMovie addmovieForm = new Forms.AddMovie();
            addmovieForm.Show();
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
    }
}
