namespace MovieRentalProject
{
    partial class RentalForm
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
            Cancel = new Button();
            Save = new Button();
            customerID = new TextBox();
            rentalTitle = new Label();
            movieName = new TextBox();
            SuspendLayout();
            // 
            // Cancel
            // 
            Cancel.Location = new Point(146, 232);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 19;
            Cancel.Text = "CANCEL";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Save
            // 
            Save.Location = new Point(146, 176);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 18;
            Save.Text = "SAVE";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // customerID
            // 
            customerID.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            customerID.Location = new Point(356, 224);
            customerID.Name = "customerID";
            customerID.PlaceholderText = "Customer ID";
            customerID.Size = new Size(330, 29);
            customerID.TabIndex = 15;
            // 
            // rentalTitle
            // 
            rentalTitle.AutoSize = true;
            rentalTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            rentalTitle.Location = new Point(127, 123);
            rentalTitle.Name = "rentalTitle";
            rentalTitle.Size = new Size(117, 28);
            rentalTitle.TabIndex = 14;
            rentalTitle.Text = "Rental Form";
            // 
            // movieName
            // 
            movieName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            movieName.Location = new Point(356, 176);
            movieName.Name = "movieName";
            movieName.PlaceholderText = "Movie Name";
            movieName.Size = new Size(330, 29);
            movieName.TabIndex = 13;
            // 
            // RentalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Cancel);
            Controls.Add(Save);
            Controls.Add(customerID);
            Controls.Add(rentalTitle);
            Controls.Add(movieName);
            Name = "RentalForm";
            Text = "RentalForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Cancel;
        private Button Save;
        private TextBox customerID;
        private Label rentalTitle;
        private TextBox movieName;
    }
}