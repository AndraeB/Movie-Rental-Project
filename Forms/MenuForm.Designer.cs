namespace MovieRentalProject
{
    partial class MenuForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MovieMaintenance = new Button();
            CustomerMaintenance = new Button();
            Rental = new Button();
            Reports = new Button();
            EditCustBtn = new Button();
            SuspendLayout();
            // 
            // MovieMaintenance
            // 
            MovieMaintenance.Location = new Point(278, 25);
            MovieMaintenance.Name = "MovieMaintenance";
            MovieMaintenance.Size = new Size(210, 73);
            MovieMaintenance.TabIndex = 0;
            MovieMaintenance.Text = "Movie Maintenance";
            MovieMaintenance.UseVisualStyleBackColor = true;
            MovieMaintenance.Click += MovieMaintenance_Click_1;
            // 
            // CustomerMaintenance
            // 
            CustomerMaintenance.Location = new Point(278, 104);
            CustomerMaintenance.Name = "CustomerMaintenance";
            CustomerMaintenance.Size = new Size(210, 73);
            CustomerMaintenance.TabIndex = 1;
            CustomerMaintenance.Text = "Customer Maintenance";
            CustomerMaintenance.UseVisualStyleBackColor = true;
            CustomerMaintenance.Click += CustomerMaintenance_Click_1;
            // 
            // Rental
            // 
            Rental.Location = new Point(278, 183);
            Rental.Name = "Rental";
            Rental.Size = new Size(210, 73);
            Rental.TabIndex = 2;
            Rental.Text = "Rental";
            Rental.UseVisualStyleBackColor = true;
            Rental.Click += Rental_Click_1;
            // 
            // Reports
            // 
            Reports.Location = new Point(278, 262);
            Reports.Name = "Reports";
            Reports.Size = new Size(210, 73);
            Reports.TabIndex = 3;
            Reports.Text = "Reports";
            Reports.UseVisualStyleBackColor = true;
            Reports.Click += Reports_Click_1;
            // 
            // EditCustBtn
            // 
            EditCustBtn.Location = new Point(278, 341);
            EditCustBtn.Name = "EditCustBtn";
            EditCustBtn.Size = new Size(210, 73);
            EditCustBtn.TabIndex = 4;
            EditCustBtn.Text = "Edit Customer";
            EditCustBtn.UseVisualStyleBackColor = true;
            EditCustBtn.Click += button1_Click;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EditCustBtn);
            Controls.Add(Reports);
            Controls.Add(Rental);
            Controls.Add(CustomerMaintenance);
            Controls.Add(MovieMaintenance);
            Name = "MenuForm";
            Text = "MenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button MovieMaintenance;
        private Button CustomerMaintenance;
        private Button Rental;
        private Button Reports;
        private Button EditCustBtn;
    }
}