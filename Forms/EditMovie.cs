using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MovieRentalProject.Forms
{
    public partial class EditMovie : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;
        private string movieID;

        public EditMovie(string movieID)
        {
            InitializeComponent();
            this.movieID = movieID;
            LoadMovieDetails();
            SetupDataGridViews();

           
        }


        private void SetupDataGridViews()
        {
            ActorNameQuery.ColumnCount = 3;
            ActorNameQuery.Columns[0].Name = "ActorID";
            ActorNameQuery.Columns[1].Name = "FirstName";
            ActorNameQuery.Columns[2].Name = "LastName";

            foreach (DataGridViewColumn column in ActorNameQuery.Columns)
            {
                column.ReadOnly = true;
            }

            ActorNameQuery.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Configure SelectedNames DataGridView
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





        private void Save_Click(object sender, EventArgs e)
        {
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

                    // Update the movie details
                    string updateMovieQuery = "UPDATE Movie SET MovieName = @Title, DistributionFee = @Fee, MovieType = @Type, NumOfCopies = @Copies WHERE MovieID = @MovieID";
                    using (SqlCommand command = new SqlCommand(updateMovieQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Title", TitleAdd.Text.Trim());
                        command.Parameters.AddWithValue("@Fee", Convert.ToDecimal(FeeAdd.Text.Trim()));
                        command.Parameters.AddWithValue("@Type", TypeAdd.Text.Trim());
                        command.Parameters.AddWithValue("@Copies", Convert.ToInt32(CopiesAdd.Text.Trim()));
                        command.Parameters.AddWithValue("@MovieID", movieID);
                        command.ExecuteNonQuery();
                    }

                    // Prepare the insert query
                    string insertAppearsInQuery = "INSERT INTO Appears_in (MovieID, ActorID) VALUES (@MovieID, @ActorID)";
                    string checkExistsQuery = "SELECT COUNT(*) FROM Appears_in WHERE MovieID = @MovieID AND ActorID = @ActorID";

                    foreach (DataGridViewRow row in SelectedNames.Rows)
                    {
                        if (row.Cells["ActorID"].Value != null)
                        {
                            // Check if the ActorID is already associated with the MovieID
                            using (SqlCommand checkCommand = new SqlCommand(checkExistsQuery, connection))
                            {
                                checkCommand.Parameters.AddWithValue("@MovieID", movieID);
                                checkCommand.Parameters.AddWithValue("@ActorID", row.Cells["ActorID"].Value.ToString());

                                int count = (int)checkCommand.ExecuteScalar();
                                if (count > 0)
                                {
                                    // Skip if the entry already exists
                                    continue;
                                }
                            }

                            // Insert the ActorID into Appears_in
                            using (SqlCommand insertCommand = new SqlCommand(insertAppearsInQuery, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@MovieID", movieID);
                                insertCommand.Parameters.AddWithValue("@ActorID", row.Cells["ActorID"].Value.ToString());
                                insertCommand.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Movie details updated successfully!");
                    MovieForm movieForm = new MovieForm();
                    movieForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving movie details: {ex.Message}");
            }
        }


        private void add_Click(object sender, EventArgs e)
        {
            if (ActorNameQuery.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow selectedRow in ActorNameQuery.SelectedRows)
                {
                    bool exists = false;

                    // Check if the actor already exists in SelectedNames
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
                        // Add the actor to SelectedNames
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
                // Collect the rows to remove
                List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

                foreach (DataGridViewRow selectedRow in SelectedNames.SelectedRows)
                {
                    rowsToRemove.Add(selectedRow);
                }

                // Remove the rows from the DataGridView
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
