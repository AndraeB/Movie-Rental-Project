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
            filterPanel = new Panel();
            filterLabel1 = new Label();
            filterLabel2 = new Label();
            filterLabel3 = new Label();
            filterComboBox1 = new ComboBox();
            filterComboBox2 = new ComboBox();
            filterComboBox3 = new ComboBox();
            filterToggleButton = new Button();
            ((System.ComponentModel.ISupportInitialize)reportsGrid).BeginInit();
            filterPanel.SuspendLayout();
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
            GenerateButton.Location = new Point(358, 4);
            GenerateButton.Name = "GenerateButton";
            GenerateButton.Size = new Size(120, 50);
            GenerateButton.TabIndex = 12;
            GenerateButton.Text = "Generate Report";
            GenerateButton.UseVisualStyleBackColor = true;
            GenerateButton.Click += GenerateButton_Click;
            // 
            // reportsGrid
            // 
            reportsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportsGrid.Location = new Point(32, 130);
            reportsGrid.Name = "reportsGrid";
            reportsGrid.RowTemplate.Height = 25;
            reportsGrid.Size = new Size(736, 266);
            reportsGrid.TabIndex = 13;
            reportsGrid.CellContentClick += dataGridView1_CellContentClick;
            // 
            // BackButton
            // 
            BackButton.Location = new Point(12, 402);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(120, 45);
            BackButton.TabIndex = 14;
            BackButton.Text = "BACK";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // filterPanel
            // 
            filterPanel.BorderStyle = BorderStyle.FixedSingle;
            filterPanel.Controls.Add(filterLabel1);
            filterPanel.Controls.Add(filterLabel2);
            filterPanel.Controls.Add(filterLabel3);
            filterPanel.Controls.Add(filterComboBox1);
            filterPanel.Controls.Add(filterComboBox2);
            filterPanel.Controls.Add(filterComboBox3);
            filterPanel.Location = new Point(32, 60);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(736, 60);
            filterPanel.TabIndex = 16;
            filterPanel.Visible = false;
            // 
            // filterLabel1
            // 
            filterLabel1.AutoSize = true;
            filterLabel1.Location = new Point(10, 8);
            filterLabel1.Name = "filterLabel1";
            filterLabel1.Size = new Size(38, 15);
            filterLabel1.TabIndex = 17;
            filterLabel1.Text = "Genre";
            // 
            // filterLabel2
            // 
            filterLabel2.AutoSize = true;
            filterLabel2.Location = new Point(220, 8);
            filterLabel2.Name = "filterLabel2";
            filterLabel2.Size = new Size(41, 15);
            filterLabel2.TabIndex = 19;
            filterLabel2.Text = "Rating";
            // 
            // filterLabel3
            // 
            filterLabel3.AutoSize = true;
            filterLabel3.Location = new Point(430, 8);
            filterLabel3.Name = "filterLabel3";
            filterLabel3.Size = new Size(75, 15);
            filterLabel3.TabIndex = 21;
            filterLabel3.Text = "Performance";
            // 
            // filterComboBox1
            // 
            filterComboBox1.Location = new Point(10, 26);
            filterComboBox1.Name = "filterComboBox1";
            filterComboBox1.Size = new Size(200, 23);
            filterComboBox1.TabIndex = 18;
            filterComboBox1.SelectedIndexChanged += FilterComboBox1_SelectedIndexChanged;
            // 
            // filterComboBox2
            // 
            filterComboBox2.Location = new Point(220, 26);
            filterComboBox2.Name = "filterComboBox2";
            filterComboBox2.Size = new Size(200, 23);
            filterComboBox2.TabIndex = 20;
            filterComboBox2.SelectedIndexChanged += FilterComboBox2_SelectedIndexChanged;
            // 
            // filterComboBox3
            // 
            filterComboBox3.Location = new Point(430, 26);
            filterComboBox3.Name = "filterComboBox3";
            filterComboBox3.Size = new Size(200, 23);
            filterComboBox3.TabIndex = 22;
            filterComboBox3.SelectedIndexChanged += FilterComboBox3_SelectedIndexChanged;
            // 
            // filterToggleButton
            // 
            filterToggleButton.Location = new Point(516, 4);
            filterToggleButton.Name = "filterToggleButton";
            filterToggleButton.Size = new Size(120, 50);
            filterToggleButton.TabIndex = 15;
            filterToggleButton.Text = "Filters";
            filterToggleButton.UseVisualStyleBackColor = true;
            filterToggleButton.Visible = false;
            filterToggleButton.Click += FilterToggleButton_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(filterPanel);
            Controls.Add(filterToggleButton);
            Controls.Add(BackButton);
            Controls.Add(reportsGrid);
            Controls.Add(GenerateButton);
            Controls.Add(ReportSelector);
            Name = "ReportsForm";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)reportsGrid).EndInit();
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ComboBox ReportSelector;
        private Button GenerateButton;
        private DataGridView reportsGrid;
        private Button BackButton;
        private Panel filterPanel;
        private ComboBox filterComboBox1;
        private ComboBox filterComboBox2;
        private ComboBox filterComboBox3;
        private Label filterLabel1;
        private Label filterLabel2;
        private Label filterLabel3;
        private Button filterToggleButton;
    }
}