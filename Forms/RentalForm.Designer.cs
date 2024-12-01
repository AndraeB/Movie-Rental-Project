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
            Process = new Button();
            rentalTitle = new Label();
            CustName = new TextBox();
            GoButton = new Button();
            Phone = new TextBox();
            Customer = new DataGridView();
            Account = new DataGridViewTextBoxColumn();
            Name = new DataGridViewTextBoxColumn();
            PhoneNum = new DataGridViewTextBoxColumn();
            CustomerID = new DataGridViewTextBoxColumn();
            Last = new TextBox();
            Queue = new DataGridView();
            Title = new DataGridViewTextBoxColumn();
            Fee = new DataGridViewTextBoxColumn();
            Available = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)Customer).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Queue).BeginInit();
            SuspendLayout();
            // 
            // Cancel
            // 
            Cancel.Location = new Point(42, 224);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 19;
            Cancel.Text = "CANCEL";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Process
            // 
            Process.Location = new Point(42, 144);
            Process.Name = "Process";
            Process.Size = new Size(75, 23);
            Process.TabIndex = 18;
            Process.Text = "PROCESS";
            Process.UseVisualStyleBackColor = true;
            Process.Click += Process_Click;
            // 
            // rentalTitle
            // 
            rentalTitle.AutoSize = true;
            rentalTitle.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            rentalTitle.Location = new Point(26, 34);
            rentalTitle.Name = "rentalTitle";
            rentalTitle.Size = new Size(117, 28);
            rentalTitle.TabIndex = 14;
            rentalTitle.Text = "Rental Form";
            // 
            // CustName
            // 
            CustName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CustName.Location = new Point(221, 33);
            CustName.Name = "CustName";
            CustName.PlaceholderText = "First Name";
            CustName.Size = new Size(143, 29);
            CustName.TabIndex = 13;
            // 
            // GoButton
            // 
            GoButton.Location = new Point(370, 72);
            GoButton.Name = "GoButton";
            GoButton.Size = new Size(40, 23);
            GoButton.TabIndex = 20;
            GoButton.Text = "GO";
            GoButton.UseVisualStyleBackColor = true;
            GoButton.Click += GoButton_Click;
            // 
            // Phone
            // 
            Phone.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Phone.Location = new Point(221, 99);
            Phone.Name = "Phone";
            Phone.PlaceholderText = "Phone Number";
            Phone.Size = new Size(143, 29);
            Phone.TabIndex = 21;
            // 
            // Customer
            // 
            Customer.AllowUserToAddRows = false;
            Customer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Customer.Columns.AddRange(new DataGridViewColumn[] { Account, Name, PhoneNum, CustomerID });
            Customer.Location = new Point(430, 17);
            Customer.Name = "Customer";
            Customer.RowTemplate.Height = 25;
            Customer.Size = new Size(358, 124);
            Customer.TabIndex = 22;
            // 
            // Account
            // 
            Account.HeaderText = "Account #";
            Account.Name = "Account";
            // 
            // Name
            // 
            Name.HeaderText = "Name";
            Name.Name = "Name";
            // 
            // PhoneNum
            // 
            PhoneNum.HeaderText = "Phone Number";
            PhoneNum.Name = "PhoneNum";
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "CustomerID";
            CustomerID.Name = "CustomerID";
            CustomerID.Visible = false;
            // 
            // Last
            // 
            Last.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Last.Location = new Point(221, 68);
            Last.Name = "Last";
            Last.PlaceholderText = "Last Name";
            Last.Size = new Size(143, 29);
            Last.TabIndex = 23;
            // 
            // Queue
            // 
            Queue.AllowUserToAddRows = false;
            Queue.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Queue.Columns.AddRange(new DataGridViewColumn[] { Title, Fee, Available });
            Queue.Location = new Point(328, 183);
            Queue.Name = "Queue";
            Queue.RowTemplate.Height = 25;
            Queue.Size = new Size(460, 238);
            Queue.TabIndex = 24;
            // 
            // Title
            // 
            Title.HeaderText = "Title";
            Title.Name = "Title";
            // 
            // Fee
            // 
            Fee.HeaderText = "Fee";
            Fee.Name = "Fee";
            // 
            // Available
            // 
            Available.HeaderText = "Availability";
            Available.Name = "Available";
            // 
            // RentalForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Queue);
            Controls.Add(Last);
            Controls.Add(Customer);
            Controls.Add(Phone);
            Controls.Add(GoButton);
            Controls.Add(Cancel);
            Controls.Add(Process);
            Controls.Add(rentalTitle);
            Controls.Add(CustName);
           
            Text = "RentalForm";
            ((System.ComponentModel.ISupportInitialize)Customer).EndInit();
            ((System.ComponentModel.ISupportInitialize)Queue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Cancel;
        private Button Process;
        private Label rentalTitle;
        private TextBox CustName;
        private Button GoButton;
        private TextBox Phone;
        private DataGridView Customer;
        private DataGridViewTextBoxColumn Account;
        private DataGridViewTextBoxColumn Name;
        private DataGridViewTextBoxColumn PhoneNum;
        private TextBox Last;
        private DataGridView Queue;
        private DataGridViewTextBoxColumn Title;
        private DataGridViewTextBoxColumn Fee;
        private DataGridViewTextBoxColumn Available;
        private DataGridViewTextBoxColumn CustomerID;
    }
}