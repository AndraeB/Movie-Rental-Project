namespace MovieRentalProject
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserBox = new TextBox();
            PassBox = new TextBox();
            LoginButton = new Button();
            LoginTitle = new Label();
            UserLabel = new Label();
            PassLabel = new Label();
            SuspendLayout();
            // 
            // UserBox
            // 
            UserBox.Font = new Font("Segoe UI", 14F);
            UserBox.Location = new Point(303, 129);
            UserBox.Margin = new Padding(3, 2, 3, 2);
            UserBox.Name = "UserBox";
            UserBox.Size = new Size(193, 32);
            UserBox.TabIndex = 4;
            UserBox.TextChanged += UserBox_TextChanged;
            // 
            // PassBox
            // 
            PassBox.Font = new Font("Segoe UI", 14F);
            PassBox.Location = new Point(303, 181);
            PassBox.Margin = new Padding(3, 2, 3, 2);
            PassBox.Name = "PassBox";
            PassBox.Size = new Size(193, 32);
            PassBox.TabIndex = 5;
            PassBox.TextChanged += PassBox_TextChanged;
            // 
            // LoginButton
            // 
            LoginButton.Font = new Font("Segoe UI", 14F);
            LoginButton.Location = new Point(303, 236);
            LoginButton.Margin = new Padding(3, 2, 3, 2);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(193, 39);
            LoginButton.TabIndex = 0;
            LoginButton.Text = "Login";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButton_Click;
            // 
            // LoginTitle
            // 
            LoginTitle.AutoSize = true;
            LoginTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            LoginTitle.ForeColor = Color.Blue;
            LoginTitle.Location = new Point(191, 77);
            LoginTitle.Name = "LoginTitle";
            LoginTitle.Size = new Size(369, 25);
            LoginTitle.TabIndex = 6;
            LoginTitle.Text = "Movie Rental Application For Employees";
            // 
            // UserLabel
            // 
            UserLabel.AutoSize = true;
            UserLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            UserLabel.ForeColor = Color.Blue;
            UserLabel.Location = new Point(185, 129);
            UserLabel.Name = "UserLabel";
            UserLabel.Size = new Size(106, 25);
            UserLabel.TabIndex = 1;
            UserLabel.Text = "ID Number:";
            // 
            // PassLabel
            // 
            PassLabel.AutoSize = true;
            PassLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            PassLabel.ForeColor = Color.Blue;
            PassLabel.Location = new Point(185, 188);
            PassLabel.Name = "PassLabel";
            PassLabel.Size = new Size(102, 25);
            PassLabel.TabIndex = 2;
            PassLabel.Text = "Password:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 364);
            Controls.Add(LoginTitle);
            Controls.Add(UserLabel);
            Controls.Add(LoginButton);
            Controls.Add(UserBox);
            Controls.Add(PassBox);
            Controls.Add(PassLabel);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox UserBox;
        private TextBox PassBox;
        private Button LoginButton;
        private Label LoginTitle;
        private Label UserLabel;
        private Label PassLabel;
    }
}