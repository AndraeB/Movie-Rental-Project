using System.Windows.Forms;

namespace MovieRentalProject
{
    partial class CustomerForm
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
            backButton = new Button();
            label1 = new Label();
            customerDataViewGrid = new DataGridView();
            addCustomerButton = new Button();
            customerSearchBox = new TextBox();
            customerSearchButton = new Button();
            customerEditButton = new Button();
            ((System.ComponentModel.ISupportInitialize)customerDataViewGrid).BeginInit();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.Location = new Point(12, 388);
            backButton.Name = "backButton";
            backButton.Size = new Size(120, 50);
            backButton.TabIndex = 9;
            backButton.Text = "BACK";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(254, 28);
            label1.TabIndex = 10;
            label1.Text = "CUSTOMER MAINTENANCE";
            // 
            // customerDataViewGrid
            // 
            customerDataViewGrid.AllowUserToAddRows = false;
            customerDataViewGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            customerDataViewGrid.Location = new Point(160, 40);
            customerDataViewGrid.Name = "customerDataViewGrid";
            customerDataViewGrid.RowTemplate.Height = 25;
            customerDataViewGrid.Size = new Size(628, 398);
            customerDataViewGrid.TabIndex = 11;
            // 
            // addCustomerButton
            // 
            addCustomerButton.Location = new Point(12, 142);
            addCustomerButton.Name = "addCustomerButton";
            addCustomerButton.Size = new Size(120, 50);
            addCustomerButton.TabIndex = 12;
            addCustomerButton.Text = "ADD";
            addCustomerButton.UseVisualStyleBackColor = true;
            addCustomerButton.Click += AddCustomerButton_Click;
            // 
            // customerSearchBox
            // 
            customerSearchBox.Location = new Point(12, 57);
            customerSearchBox.Name = "customerSearchBox";
            customerSearchBox.PlaceholderText = "First Name";
            customerSearchBox.Size = new Size(140, 23);
            customerSearchBox.TabIndex = 13;
            // 
            // customerSearchButton
            // 
            customerSearchButton.Location = new Point(12, 86);
            customerSearchButton.Name = "customerSearchButton";
            customerSearchButton.Size = new Size(120, 50);
            customerSearchButton.TabIndex = 14;
            customerSearchButton.Text = "SEARCH";
            customerSearchButton.UseVisualStyleBackColor = true;
            customerSearchButton.Click += customerSearchButton_Click;
            // 
            // customerEditButton
            // 
            customerEditButton.Location = new Point(12, 198);
            customerEditButton.Name = "customerEditButton";
            customerEditButton.Size = new Size(120, 50);
            customerEditButton.TabIndex = 15;
            customerEditButton.Text = "EDIT";
            customerEditButton.UseVisualStyleBackColor = true;
            customerEditButton.Click += customerEditButton_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(customerEditButton);
            Controls.Add(customerSearchButton);
            Controls.Add(customerSearchBox);
            Controls.Add(addCustomerButton);
            Controls.Add(customerDataViewGrid);
            Controls.Add(label1);
            Controls.Add(backButton);
            Name = "CustomerForm";
            Text = "CustomerForm";
            ((System.ComponentModel.ISupportInitialize)customerDataViewGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private Button backButton;
        private Label label1;
        private DataGridView customerDataViewGrid;
        private Button addCustomerButton;
        private TextBox customerSearchBox;
        private Button customerSearchButton;
        private Button customerEditButton;
    }
}