using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalProject
{
    public partial class EditCustomer : Form
    {
        // Coonection string for database
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;
        private string custID;

        // Parameterless constructor
        // i.e. Default instantiation of customer without changing "EditCustomer" everywhere else
        // Please remove later
        public EditCustomer() : this("0001") { }

        // Main constructor
        public EditCustomer(string custID)
        {
            InitializeComponent();
            this.custID = custID;
            LoadCustomerDetails();
        }
        private void LoadCustomerDetails()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT FirstName, LastName, EmailAddress, Addr, City, Province, CreditCardNumber 
                                    FROM Customer 
                                    WHERE CustomerID = @CustomerID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", custID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            {
                                if (reader.Read())
                                {

                                    // Populate text boxes with existing customer data
                                    FirstNmTxtBox.Text = reader["FirstName"].ToString();
                                    LastNmTxtBox.Text = reader["LastName"].ToString();
                                    EmailTxtBox.Text = reader["EmailAddress"].ToString();
                                    AddressTxtBox.Text = reader["Addr"].ToString();
                                    CityTxtBox.Text = reader["City"].ToString();
                                    ProvinceTxtBox.Text = reader["Province"].ToString();
                                    CreditCardTxtBox.Text = reader["CreditCardNumber"].ToString();
                                }
                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error loading customer details: {ex.Message}");
            }
        }
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
            this.Hide();
        }

        private void FinishBtn_Click(object sender, EventArgs e)
        {
            // Get the data from textboxes
            string CustFirstNm = FirstNmTxtBox.Text;
            string CustLastNm = LastNmTxtBox.Text;
            string CustEmail = EmailTxtBox.Text;
            string CustAddress = AddressTxtBox.Text;
            string CustCity = CityTxtBox.Text;
            string CustProvince = ProvinceTxtBox.Text;
            string CustCredCard = CreditCardTxtBox.Text;

            // Check if fields are filled
            if (this.Controls.OfType<TextBox>().Any(tb => string.IsNullOrEmpty(tb.Text)))
            {
                MessageBox.Show("All fields must be filled out.");
                return;
            }

            // If the error handling is passed then apply changes to the database
            ApplyCustomerEdit(CustFirstNm, CustLastNm, CustEmail, CustAddress, CustCity, CustProvince, CustCredCard);
        }
        private void ApplyCustomerEdit(string FirstNm, string LastNm, string E_Mail, string Addr, string City, string Province, string CreditCard)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL Update Statement with proper column separation
                    string query = "UPDATE Customer SET FirstName = @FName, " +
                                   "LastName = @LName, " +
                                   "EmailAddress = @Email, " +
                                   "Addr = @Address, " +
                                   "City = @City, " +
                                   "Province = @Province, " +
                                   "CreditCardNumber = @CredCard";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the command
                        command.Parameters.AddWithValue("@FName", FirstNm);
                        command.Parameters.AddWithValue("@LName", LastNm);
                        command.Parameters.AddWithValue("@Email", E_Mail);
                        command.Parameters.AddWithValue("@Address", Addr);
                        command.Parameters.AddWithValue("@City", City);
                        command.Parameters.AddWithValue("@Province", Province);
                        command.Parameters.AddWithValue("@CredCard", CreditCard);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        // Feedback to the user
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Customer details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No records were updated. Check the data entered.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database Error: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
