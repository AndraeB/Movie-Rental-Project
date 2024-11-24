using System;
using System.Windows.Forms;

namespace MovieRentalProject
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();

        }

        // Event handlers

        private void MovieMaintenance_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Movie Maintenance clicked.");
            MovieForm movieForm = new MovieForm();
            movieForm.Show();
            this.Hide();
        }

        private void CustomerMaintenance_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Customer Maintenance clicked.");
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
            this.Hide();
        }

        private void Rental_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Rental clicked.");
            RentalForm rentalForm = new RentalForm();
            rentalForm.Show();
            this.Hide();
        }

        private void Reports_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Reports clicked.");
            ReportsForm reportsForm = new ReportsForm();
            reportsForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditCustomer edt = new EditCustomer();
            edt.Show();
            this.Hide();
        }
    }
}
