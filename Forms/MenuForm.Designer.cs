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
            label1 = new Label();
            SuspendLayout();
            // 
            // MovieMaintenance
            // 
            MovieMaintenance.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            MovieMaintenance.Location = new Point(275, 73);
            MovieMaintenance.Name = "MovieMaintenance";
            MovieMaintenance.Size = new Size(210, 73);
            MovieMaintenance.TabIndex = 0;
            MovieMaintenance.Text = "MOVIE MAINTENANCE";
            MovieMaintenance.UseVisualStyleBackColor = true;
            MovieMaintenance.Click += MovieMaintenance_Click_1;
            // 
            // CustomerMaintenance
            // 
            CustomerMaintenance.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            CustomerMaintenance.Location = new Point(275, 152);
            CustomerMaintenance.Name = "CustomerMaintenance";
            CustomerMaintenance.Size = new Size(210, 73);
            CustomerMaintenance.TabIndex = 1;
            CustomerMaintenance.Text = "CUSTOMER MAINTENANCE";
            CustomerMaintenance.UseVisualStyleBackColor = true;
            CustomerMaintenance.Click += CustomerMaintenance_Click_1;
            // 
            // Rental
            // 
            Rental.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Rental.Location = new Point(275, 231);
            Rental.Name = "Rental";
            Rental.Size = new Size(210, 73);
            Rental.TabIndex = 2;
            Rental.Text = "MOVIE RENTAL";
            Rental.UseVisualStyleBackColor = true;
            Rental.Click += Rental_Click_1;
            // 
            // Reports
            // 
            Reports.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point);
            Reports.Location = new Point(275, 310);
            Reports.Name = "Reports";
            Reports.Size = new Size(210, 73);
            Reports.TabIndex = 3;
            Reports.Text = "BUSINESS REPORTS";
            Reports.UseVisualStyleBackColor = true;
            Reports.Click += Reports_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(297, 9);
            label1.Name = "label1";
            label1.Size = new Size(169, 37);
            label1.TabIndex = 4;
            label1.Text = "MAIN MENU";
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(Reports);
            Controls.Add(Rental);
            Controls.Add(CustomerMaintenance);
            Controls.Add(MovieMaintenance);
            Name = "MenuForm";
            Text = "MenuForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button MovieMaintenance;
        private Button CustomerMaintenance;
        private Button Rental;
        private Button Reports;
        private Label label1;
    }
}