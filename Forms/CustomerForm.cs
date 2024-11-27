using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace MovieRentalProject
{

    public partial class CustomerForm : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        public CustomerForm()
        {
            InitializeComponent();
            SetupDataGridView();
        }
        private void SetupDataGridView()
        {
            // Configure the DataGridView
            customerDataViewGrid.ColumnCount = 12;
            customerDataViewGrid.Columns[0].Name = "CustomerID";
            customerDataViewGrid.Columns[1].Name = "First Name";
            customerDataViewGrid.Columns[2].Name = "Last Name";
            customerDataViewGrid.Columns[3].Name = "Address";
            customerDataViewGrid.Columns[4].Name = "City";
            customerDataViewGrid.Columns[5].Name = "Province";
            customerDataViewGrid.Columns[6].Name = "PostalCode";
            customerDataViewGrid.Columns[7].Name = "Email";
            customerDataViewGrid.Columns[8].Name = "Account Number";
            customerDataViewGrid.Columns[9].Name = "Account Creation";
            customerDataViewGrid.Columns[10].Name = "Credit Card";
            customerDataViewGrid.Columns[11].Name = "Rating";

            // Optionally, make columns read-only
            foreach (DataGridViewColumn column in customerDataViewGrid.Columns)
            {
                column.ReadOnly = true;
            }

            // Set styles for the header band
            customerDataViewGrid.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
            customerDataViewGrid.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            customerDataViewGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            customerDataViewGrid.EnableHeadersVisualStyles = false;

            // Set other properties
            customerDataViewGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            MenuForm menuForm = new MenuForm();
            menuForm.Show();
            this.Hide();
        }
        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            NewCustomer newCustomer = new NewCustomer();
            MessageBox.Show("NewCustomer clicked.");
            newCustomer.Show();
            this.Hide();
        }

        private void customerSearchButton_Click(object sender, EventArgs e)
        {
            string searchTitle = customerSearchBox.Text.Trim();
            MessageBox.Show($"NewCustomer clicked. {searchTitle}");
            LoadCustomerData(searchTitle);
        }
        private void LoadCustomerData(string searchTitle = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Corrected query with proper spacing and formatting
                    string query = "SELECT CustomerID, FirstName, LastName, Addr, City, Province, PostalCode, EmailAddress, AccountNumber, AccountDateCreation, CreditCardNumber, Rating " +
                                   "FROM Customer " +
                                   "WHERE FirstName LIKE @SearchTitle + '%'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SearchTitle", searchTitle);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Clear existing rows before adding new data
                            customerDataViewGrid.Rows.Clear();

                            while (reader.Read())
                            {


                                customerDataViewGrid.Rows.Add(
                                    reader["CustomerID"].ToString(),
                                    reader["FirstName"].ToString(),
                                    reader["LastName"].ToString(),
                                    reader["Addr"].ToString(),
                                    reader["City"].ToString(),
                                    reader["Province"].ToString(),
                                    reader["PostalCode"].ToString(),
                                    reader["EmailAddress"].ToString(),
                                    reader["AccountNumber"].ToString(),
                                    reader["AccountDateCreation"].ToString(),
                                    reader["CreditCardNumber"].ToString(),
                                    reader["Rating"].ToString()
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

        private void customerEditButton_Click(object sender, EventArgs e)
        {
            EditCustomer edt = new EditCustomer();
            edt.Show();
            this.Hide();
        }
    }
}
