using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalProject.Forms
{
    public partial class AddMovie : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        public AddMovie()
        {
            InitializeComponent();
            SetupDataGridViews();
        }

        private void SetupDataGridViews()
        {
            // Setup ActorNameQuery DataGridView
            ActorNameQuery.ColumnCount = 3;
            ActorNameQuery.Columns[0].Name = "ActorID";
            ActorNameQuery.Columns[1].Name = "FirstName";
            ActorNameQuery.Columns[2].Name = "LastName";
            foreach (DataGridViewColumn column in ActorNameQuery.Columns)
            {
                column.ReadOnly = true;
            }
            ActorNameQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Setup SelectedNames DataGridView
            SelectedNames.ColumnCount = 3;
            SelectedNames.Columns[0].Name = "ActorID";
            SelectedNames.Columns[1].Name = "FirstName";
            SelectedNames.Columns[2].Name = "LastName";
            SelectedNames.Columns[0].HeaderText = "Actor ID";
            SelectedNames.Columns[1].HeaderText = "First Name";
            SelectedNames.Columns[2].HeaderText = "Last Name";
            SelectedNames.ReadOnly = true;
            SelectedNames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SelectedNames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes
            string movieTitle = TitleAdd.Text.Trim();
            string movieFee = FeeAdd.Text.Trim();
            string movieType = TypeAdd.Text.Trim();
            string movieCopies = CopiesAdd.Text.Trim();

            // List of valid movie types
            List<string> validMovieTypes = new List<string> { "Action", "Comedy", "Drama", "Foreign" };

            // Validate the fields
            if (string.IsNullOrEmpty(movieTitle) || string.IsNullOrEmpty(movieFee) || string.IsNullOrEmpty(movieType) || string.IsNullOrEmpty(movieCopies))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the movie type is valid
            if (!validMovieTypes.Contains(movieType))
            {
                MessageBox.Show("Invalid movie type. Valid types are: Action, Comedy, Drama, Foreign.",
                                "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed to insert the movie into the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert the movie and retrieve the generated MovieID
                    string insertMovieQuery = @"
                INSERT INTO Movie (MovieName, DistributionFee, MovieType, NumOfCopies, MovieAvailability)
                VALUES (@MovieName, @DistributionFee, @MovieType, @NumOfCopies, @MovieAvailability);
                SELECT SCOPE_IDENTITY();";

                    int newMovieID;
                    using (SqlCommand command = new SqlCommand(insertMovieQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MovieName", movieTitle);
                        command.Parameters.AddWithValue("@DistributionFee", movieFee);
                        command.Parameters.AddWithValue("@MovieType", movieType);
                        command.Parameters.AddWithValue("@NumOfCopies", movieCopies);
                        command.Parameters.AddWithValue("@MovieAvailability", movieCopies); // Set MovieAvailability to the same value as NumOfCopies
                        newMovieID = Convert.ToInt32(command.ExecuteScalar());
                    }

                    // Insert actors into Appears_in table
                    string insertAppearsInQuery = "INSERT INTO Appears_in (MovieID, ActorID) VALUES (@MovieID, @ActorID)";
                    foreach (DataGridViewRow row in SelectedNames.Rows)
                    {
                        if (row.Cells["ActorID"].Value != null)
                        {
                            using (SqlCommand insertCommand = new SqlCommand(insertAppearsInQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@MovieID", newMovieID);
                                insertCommand.Parameters.AddWithValue("@ActorID", row.Cells["ActorID"].Value.ToString());
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Movie and associated actors added successfully!");
                    MovieForm movieForm = new MovieForm();
                    movieForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting movie and actors: {ex.Message}");
            }
        }



        private void GoButton_Click(object sender, EventArgs e)
        {
            SearchActors();
        }

        private void SearchActors()
        {
            string firstName = ActorFirstName.Text.Trim();
            string lastName = ActorLastName.Text.Trim();

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
            {
                MessageBox.Show("Please enter both the first name and last name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT ActorID, FirstName, LastName FROM Actor WHERE FirstName = @FirstName AND LastName = @LastName";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            ActorNameQuery.Rows.Clear();
                            while (reader.Read())
                            {
                                ActorNameQuery.Rows.Add(
                                    reader["ActorID"].ToString(),
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString()
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error searching for actors: {ex.Message}");
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            if (ActorNameQuery.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in ActorNameQuery.SelectedRows)
                {
                    bool exists = false;
                    foreach (DataGridViewRow row in SelectedNames.Rows)
                    {
                        if (row.Cells["ActorID"].Value.ToString() == selectedRow.Cells["ActorID"].Value.ToString())
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (!exists)
                    {
                        SelectedNames.Rows.Add(
                            selectedRow.Cells["ActorID"].Value.ToString(),
                            selectedRow.Cells["FirstName"].Value.ToString(),
                            selectedRow.Cells["LastName"].Value.ToString()
                        );
                    }
                    else
                    {
                        MessageBox.Show($"Actor {selectedRow.Cells["FirstName"].Value} {selectedRow.Cells["LastName"].Value} is already in the selected list.",
                            "Duplicate Actor",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an actor from the list to add.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void remove_Click(object sender, EventArgs e)
        {
            if (SelectedNames.SelectedRows.Count > 0)
            {
                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();
                foreach (DataGridViewRow selectedRow in SelectedNames.SelectedRows)
                {
                    rowsToRemove.Add(selectedRow);
                }

                foreach (DataGridViewRow row in rowsToRemove)
                {
                    SelectedNames.Rows.Remove(row);
                }
            }
            else
            {
                MessageBox.Show("Please select a row from the selected list to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
