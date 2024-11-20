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
            ActorNameQuery = new CheckedListBox();
            ActorName = new TextBox();
            Cancel = new Button();
            Save = new Button();
            CopiesAdd = new TextBox();
            TypeAdd = new TextBox();
            FeeAdd = new TextBox();
            MovieMaintenance = new Label();
            TitleAdd = new TextBox();
            SuspendLayout();
            // 
            // AddActor
            // 
            AddActor.AutoSize = true;
            AddActor.Location = new Point(64, 318);
            AddActor.Name = "AddActor";
            AddActor.Size = new Size(61, 15);
            AddActor.TabIndex = 22;
            AddActor.Text = "Add Actor";
            // 
            // ActorNameQuery
            // 
            ActorNameQuery.FormattingEnabled = true;
            ActorNameQuery.Location = new Point(379, 230);
            ActorNameQuery.Name = "ActorNameQuery";
            ActorNameQuery.Size = new Size(330, 202);
            ActorNameQuery.TabIndex = 21;
            // 
            // ActorName
            // 
            ActorName.Location = new Point(151, 315);
            ActorName.Name = "ActorName";
            ActorName.PlaceholderText = "Name";
            ActorName.Size = new Size(165, 23);
            ActorName.TabIndex = 20;
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
            // EditMovie
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
            Name = "EditMovie";
            Text = "EditMovie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AddActor;
        private CheckedListBox ActorNameQuery;
        private TextBox ActorName;
        private Button Cancel;
        private Button Save;
        private TextBox CopiesAdd;
        private TextBox TypeAdd;
        private TextBox FeeAdd;
        private Label MovieMaintenance;
        private TextBox TitleAdd;
    }
}