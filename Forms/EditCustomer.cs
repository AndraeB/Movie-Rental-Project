using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieRentalProject
{
    public partial class EditCustomer : Form
    {
        // Coonection string for database
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MovieRental"].ConnectionString;
        public EditCustomer()
        {
            InitializeComponent();
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


        }
    }
}
