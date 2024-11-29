namespace MovieRentalProject.Forms
{
    partial class EditMovie
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
            AddActor = new Label();
            ActorFirstName = new TextBox();
            Cancel = new Button();
            Save = new Button();
            CopiesAdd = new TextBox();
            TypeAdd = new TextBox();
            FeeAdd = new TextBox();
            MovieMaintenance = new Label();
            TitleAdd = new TextBox();
            ActorLastName = new TextBox();
            GoButton = new Button();
            ActorNameQuery = new DataGridView();
            ActorID = new DataGridViewTextBoxColumn();
            FirstName = new DataGridViewTextBoxColumn();
            LastName = new DataGridViewTextBoxColumn();
            SelectedNames = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            add = new Button();
            remove = new Button();
            ((System.ComponentModel.ISupportInitialize)ActorNameQuery).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SelectedNames).BeginInit();
            SuspendLayout();
            // 
            // AddActor
            // 
            AddActor.AutoSize = true;
            AddActor.Location = new Point(52, 229);
            AddActor.Name = "AddActor";
            AddActor.Size = new Size(61, 15);
            AddActor.TabIndex = 22;
            AddActor.Text = "Add Actor";
            // 
            // ActorFirstName
            // 
            ActorFirstName.Location = new Point(26, 269);
            ActorFirstName.Name = "ActorFirstName";
            ActorFirstName.PlaceholderText = "First Name";
            ActorFirstName.Size = new Size(123, 23);
            ActorFirstName.TabIndex = 20;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(116, 132);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 19;
            Cancel.Text = "CANCEL";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // Save
            // 
            Save.Location = new Point(116, 76);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 18;
            Save.Text = "SAVE";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // CopiesAdd
            // 
            CopiesAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CopiesAdd.Location = new Point(379, 179);
            CopiesAdd.Name = "CopiesAdd";
            CopiesAdd.PlaceholderText = "Change Copies";
            CopiesAdd.Size = new Size(330, 29);
            CopiesAdd.TabIndex = 17;
            // 
            // TypeAdd
            // 
            TypeAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TypeAdd.Location = new Point(379, 126);
            TypeAdd.Name = "TypeAdd";
            TypeAdd.PlaceholderText = "Change Type";
            TypeAdd.Size = new Size(330, 29);
            TypeAdd.TabIndex = 16;
            // 
            // FeeAdd
            // 
            FeeAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FeeAdd.Location = new Point(379, 70);
            FeeAdd.Name = "FeeAdd";
            FeeAdd.PlaceholderText = "Change Fee";
            FeeAdd.Size = new Size(330, 29);
            FeeAdd.TabIndex = 15;
            // 
            // MovieMaintenance
            // 
            MovieMaintenance.AutoSize = true;
            MovieMaintenance.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            MovieMaintenance.Location = new Point(64, 19);
            MovieMaintenance.Name = "MovieMaintenance";
            MovieMaintenance.Size = new Size(184, 28);
            MovieMaintenance.TabIndex = 14;
            MovieMaintenance.Text = "Movie Maintenance";
            // 
            // TitleAdd
            // 
            TitleAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TitleAdd.Location = new Point(379, 22);
            TitleAdd.Name = "TitleAdd";
            TitleAdd.PlaceholderText = "Change Title";
            TitleAdd.Size = new Size(330, 29);
            TitleAdd.TabIndex = 13;
            // 
            // ActorLastName
            // 
            ActorLastName.Location = new Point(155, 269);
            ActorLastName.Name = "ActorLastName";
            ActorLastName.PlaceholderText = "Last Name";
            ActorLastName.Size = new Size(123, 23);
            ActorLastName.TabIndex = 24;
            // 
            // GoButton
            // 
            GoButton.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            GoButton.Location = new Point(284, 269);
            GoButton.Name = "GoButton";
            GoButton.Size = new Size(79, 23);
            GoButton.TabIndex = 25;
            GoButton.Text = "GO";
            GoButton.UseVisualStyleBackColor = true;
            GoButton.Click += GoButton_Click;
            // 
            // ActorNameQuery
            // 
            ActorNameQuery.AllowUserToAddRows = false;
            ActorNameQuery.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ActorNameQuery.Columns.AddRange(new DataGridViewColumn[] { ActorID, FirstName, LastName });
            ActorNameQuery.Location = new Point(39, 298);
            ActorNameQuery.Name = "ActorNameQuery";
            ActorNameQuery.RowTemplate.Height = 25;
            ActorNameQuery.Size = new Size(240, 150);
            ActorNameQuery.TabIndex = 26;
            // 
            // ActorID
            // 
            ActorID.HeaderText = "ActorID";
            ActorID.Name = "ActorID";
            ActorID.Visible = false;
            // 
            // FirstName
            // 
            FirstName.HeaderText = "First Name";
            FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            LastName.HeaderText = "Last Name";
            LastName.Name = "LastName";
            // 
            // SelectedNames
            // 
            SelectedNames.AllowUserToAddRows = false;
            SelectedNames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SelectedNames.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3 });
            SelectedNames.Location = new Point(379, 248);
            SelectedNames.Name = "SelectedNames";
            SelectedNames.ReadOnly = true;
            SelectedNames.RowTemplate.Height = 25;
            SelectedNames.Size = new Size(330, 190);
            SelectedNames.TabIndex = 27;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ActorID";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "First Name";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Last Name";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // add
            // 
            add.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            add.Location = new Point(309, 352);
            add.Name = "add";
            add.Size = new Size(31, 23);
            add.TabIndex = 28;
            add.Text = ">";
            add.UseVisualStyleBackColor = true;
            add.Click += add_Click;
            // 
            // remove
            // 
            remove.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            remove.Location = new Point(309, 381);
            remove.Name = "remove";
            remove.Size = new Size(31, 23);
            remove.TabIndex = 29;
            remove.Text = "<";
            remove.UseVisualStyleBackColor = true;
            remove.Click += remove_Click;
            // 
            // EditMovie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(remove);
            Controls.Add(add);
            Controls.Add(SelectedNames);
            Controls.Add(ActorNameQuery);
            Controls.Add(GoButton);
            Controls.Add(ActorLastName);
            Controls.Add(AddActor);
            Controls.Add(ActorFirstName);
            Controls.Add(Cancel);
            Controls.Add(Save);
            Controls.Add(CopiesAdd);
            Controls.Add(TypeAdd);
            Controls.Add(FeeAdd);
            Controls.Add(MovieMaintenance);
            Controls.Add(TitleAdd);
            Name = "EditMovie";
            Text = "EditMovie";
            ((System.ComponentModel.ISupportInitialize)ActorNameQuery).EndInit();
            ((System.ComponentModel.ISupportInitialize)SelectedNames).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddActor;
        private TextBox ActorFirstName;
        private Button Cancel;
        private Button Save;
        private TextBox CopiesAdd;
        private TextBox TypeAdd;
        private TextBox FeeAdd;
        private Label MovieMaintenance;
        private TextBox TitleAdd;
        private TextBox ActorLastName;
        private Button GoButton;
        private DataGridView ActorNameQuery;
        private DataGridViewTextBoxColumn ActorID;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn LastName;
        private DataGridView SelectedNames;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Button add;
        private Button remove;
    }
}