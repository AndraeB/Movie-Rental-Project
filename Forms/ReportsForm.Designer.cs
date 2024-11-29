namespace MovieRentalProject
{
    partial class ReportsForm
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
            ReportSelector = new ComboBox();
            GenerateButton = new Button();
            reportsGrid = new DataGridView();
            BackButton = new Button();
            ((System.ComponentModel.ISupportInitialize)reportsGrid).BeginInit();
            SuspendLayout();
            // 
            // ReportSelector
            // 
            ReportSelector.Items.AddRange(new object[] { "Movie Performance", "Inventory Analysis", "Revenue-Time Analysis", "Pricing Suggestions", "Actor Popularity Analysis" });
            ReportSelector.Location = new Point(32, 31);
            ReportSelector.Name = "ReportSelector";
            ReportSelector.Size = new Size(320, 23);
            ReportSelector.TabIndex = 10;
            ReportSelector.Text = "Select Report Type";
            ReportSelector.SelectedIndexChanged += ReportSelector_SelectedIndexChanged;
            // 
            // GenerateButton
            // 
            GenerateButton.Location = new Point(373, 31);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(104, 23);
            GenerateButton.TabIndex = 12;
            GenerateButton.Text = "Generate Report";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // reportsGrid
            // 
            reportsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportsGrid.Location = new Point(32, 77);
            reportsGrid.Name = "reportsGrid";
            reportsGrid.RowTemplate.Height = 25;
            reportsGrid.Size = new Size(736, 319);
            reportsGrid.TabIndex = 13;
            reportsGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(653, 415);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(115, 23);
            BackButton.TabIndex = 14;
            BackButton.Text = "BACK";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(BackButton);
            Controls.Add(reportsGrid);
            Controls.Add(GenerateButton);
            Controls.Add(ReportSelector);
            Name = "ReportsForm";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)reportsGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox ReportSelector;
        private Button GenerateButton;
        private DataGridView reportsGrid;
        private Button BackButton;
    }
}