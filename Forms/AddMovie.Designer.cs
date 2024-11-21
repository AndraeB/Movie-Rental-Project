namespace MovieRentalProject.Forms
{
    partial class AddMovie
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
            TitleAdd = new TextBox();
            MovieMaintenance = new Label();
            FeeAdd = new TextBox();
            TypeAdd = new TextBox();
            CopiesAdd = new TextBox();
            Save = new Button();
            Cancel = new Button();
            ActorName = new TextBox();
            ActorNameQuery = new CheckedListBox();
            AddActor = new Label();
            SuspendLayout();
            // 
            // TitleAdd
            // 
            TitleAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TitleAdd.Location = new Point(342, 29);
            TitleAdd.Name = "TitleAdd";
            TitleAdd.PlaceholderText = "Title";
            TitleAdd.Size = new Size(330, 29);
            TitleAdd.TabIndex = 0;
            // 
            // MovieMaintenance
            // 
            MovieMaintenance.AutoSize = true;
            MovieMaintenance.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            MovieMaintenance.Location = new Point(27, 26);
            MovieMaintenance.Name = "MovieMaintenance";
            MovieMaintenance.Size = new Size(184, 28);
            MovieMaintenance.TabIndex = 1;
            MovieMaintenance.Text = "Movie Maintenance";
            // 
            // FeeAdd
            // 
            FeeAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FeeAdd.Location = new Point(342, 77);
            FeeAdd.Name = "FeeAdd";
            FeeAdd.PlaceholderText = "Fee";
            FeeAdd.Size = new Size(330, 29);
            FeeAdd.TabIndex = 2;
            // 
            // TypeAdd
            // 
            TypeAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            TypeAdd.Location = new Point(342, 133);
            TypeAdd.Name = "TypeAdd";
            TypeAdd.PlaceholderText = "Type";
            TypeAdd.Size = new Size(330, 29);
            TypeAdd.TabIndex = 3;
            // 
            // CopiesAdd
            // 
            CopiesAdd.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            CopiesAdd.Location = new Point(342, 186);
            CopiesAdd.Name = "CopiesAdd";
            CopiesAdd.PlaceholderText = "Copies";
            CopiesAdd.Size = new Size(330, 29);
            CopiesAdd.TabIndex = 4;
            // 
            // Save
            // 
            Save.Location = new Point(79, 83);
            Save.Name = "Save";
            Save.Size = new Size(75, 23);
            Save.TabIndex = 5;
            Save.Text = "SAVE";
            Save.UseVisualStyleBackColor = true;
            Save.Click += Save_Click;
            // 
            // Cancel
            // 
            Cancel.Location = new Point(79, 139);
            Cancel.Name = "Cancel";
            Cancel.Size = new Size(75, 23);
            Cancel.TabIndex = 6;
            Cancel.Text = "CANCEL";
            Cancel.UseVisualStyleBackColor = true;
            Cancel.Click += Cancel_Click;
            // 
            // ActorName
            // 
            ActorName.Location = new Point(114, 322);
            ActorName.Name = "ActorName";
            ActorName.PlaceholderText = "Name";
            ActorName.Size = new Size(165, 23);
            ActorName.TabIndex = 9;
            // 
            // ActorNameQuery
            // 
            ActorNameQuery.FormattingEnabled = true;
            ActorNameQuery.Location = new Point(342, 237);
            ActorNameQuery.Name = "ActorNameQuery";
            ActorNameQuery.Size = new Size(330, 202);
            ActorNameQuery.TabIndex = 10;
            // 
            // AddActor
            // 
            AddActor.AutoSize = true;
            AddActor.Location = new Point(27, 325);
            AddActor.Name = "AddActor";
            AddActor.Size = new Size(61, 15);
            AddActor.TabIndex = 12;
            AddActor.Text = "Add Actor";
            // 
            // AddMovie
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(AddActor);
            Controls.Add(ActorNameQuery);
            Controls.Add(ActorName);
            Controls.Add(Cancel);
            Controls.Add(Save);
            Controls.Add(CopiesAdd);
            Controls.Add(TypeAdd);
            Controls.Add(FeeAdd);
            Controls.Add(MovieMaintenance);
            Controls.Add(TitleAdd);
            Name = "AddMovie";
            Text = "AddMovie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TitleAdd;
        private Label MovieMaintenance;
        private TextBox FeeAdd;
        private TextBox TypeAdd;
        private TextBox CopiesAdd;
        private Button Save;
        private Button Cancel;
        private TextBox ActorName;
        private CheckedListBox ActorNameQuery;
        private Label AddActor;
    }
}