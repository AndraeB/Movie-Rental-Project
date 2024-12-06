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

namespace MovieRentalProject
{
    public partial class NewCustomer : Form
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;

        public NewCustomer()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
            this.Hide();
        }

        private void createCustomerButton_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes
            string customerFirstName = customerFirstNameBox.Text.Trim();
            string customerLastName = customerLastNameBox.Text.Trim();
            string customerEmail = customerEmailBox.Text.Trim();
            string customerAddress = customerAddressBox.Text.Trim();
            string customerCity = customerCityBox.Text.Trim();
            string customerProvince = customerProvinceBox.Text.Trim();
            string customerPostalCode = customerPostalCodeBox.Text.Trim();
            string customerCard = customerCardBox.Text.Trim();
            string customerRating = customerRatingBox.Text.Trim();

            // Validate the fields
            if (string.IsNullOrEmpty(customerFirstName) || string.IsNullOrEmpty(customerLastName) || string.IsNullOrEmpty(customerAddress) || string.IsNullOrEmpty(customerCity) || string.IsNullOrEmpty(customerPostalCode) || string.IsNullOrEmpty(customerCard) || string.IsNullOrEmpty(customerRating) || string.IsNullOrEmpty(customerProvince))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Proceed to insert the movie into the database
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert the movie and retrieve the generated MovieID
                    string insertCustomerQuery = @"
                INSERT INTO Customer (LastName, FirstName, Addr, City, Province, PostalCode, EmailAddress, AccountNumber, CreditCardNumber, Rating)
                VALUES (@LastName, @FirstName, @Addr, @City, @Province, @PostalCode, @EmailAddress, @AccountNumber, @CreditCardNumber, @Rating);
                SELECT SCOPE_IDENTITY();";

                    int newCustomerAccountNum;
                    Random rnd = new Random();
                    int accountNum = rnd.Next(1, 100000);
                    using (SqlCommand command = new SqlCommand(insertCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@LastName", customerLastName);
                        command.Parameters.AddWithValue("@FirstName", customerFirstName);
                        command.Parameters.AddWithValue("@Addr", customerAddress);
                        command.Parameters.AddWithValue("@City", customerCity);
                        command.Parameters.AddWithValue("@Province", customerProvince); 
                        command.Parameters.AddWithValue("@PostalCode", customerPostalCode);
                        command.Parameters.AddWithValue("@EmailAddress", customerEmail);
                        command.Parameters.AddWithValue("@AccountNumber", accountNum);
                        command.Parameters.AddWithValue("@CreditCardNumber", customerCard);
                        command.Parameters.AddWithValue("@Rating", customerRating);
                        command.Parameters.AddWithValue("@AccountDateCreation", DateTime.Now);
                        newCustomerAccountNum = Convert.ToInt32(command.ExecuteScalar());

                    }

                    

                    MessageBox.Show("Customer added successfully!");
                    CustomerForm customerForm = new CustomerForm();
                    customerForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inserting movie and actors: {ex.Message}");
            }
        }
    }
}
