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
            dataGridView1.ColumnCount = 4;
            dataGridView1.Columns[0].Name = "Title";

            dataGridView1.Columns[1].Name = "Fee";
            dataGridView1.Columns[2].Name = "Type";
            dataGridView1.Columns[3].Name = "Copies";

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
                    string query = "SELECT MovieName, DistributionFee, MovieType, NumOfCopies " +
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

        }
    }
}
