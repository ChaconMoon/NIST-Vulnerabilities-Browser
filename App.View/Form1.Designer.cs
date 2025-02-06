namespace App.View
{
    partial class Form1
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
            button1 = new Button();
            resultTable = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Published = new DataGridViewTextBoxColumn();
            LastModified = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            CVSS_Score = new DataGridViewTextBoxColumn();
            textBox = new RichTextBox();
            TextBoxSoftwareName = new TextBox();
            connecting_textLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)resultTable).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(149, 415);
            button1.Name = "button1";
            button1.Size = new Size(175, 23);
            button1.TabIndex = 0;
            button1.Text = "Obtener Vulnerabilidades";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // resultTable
            // 
            resultTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultTable.Columns.AddRange(new DataGridViewColumn[] { ID, Published, LastModified, Description, CVSS_Score });
            resultTable.Location = new Point(12, 12);
            resultTable.Name = "resultTable";
            resultTable.Size = new Size(776, 397);
            resultTable.TabIndex = 1;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            ID.ReadOnly = true;
            // 
            // Published
            // 
            Published.HeaderText = "Fecha de Publicación";
            Published.Name = "Published";
            Published.ReadOnly = true;
            // 
            // LastModified
            // 
            LastModified.HeaderText = "Ultima Modificación";
            LastModified.Name = "LastModified";
            LastModified.ReadOnly = true;
            // 
            // Description
            // 
            Description.HeaderText = "Descripción";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 350;
            // 
            // CVSS_Score
            // 
            CVSS_Score.HeaderText = "Puntuación CVSS";
            CVSS_Score.Name = "CVSS_Score";
            CVSS_Score.ReadOnly = true;
            // 
            // textBox
            // 
            textBox.Location = new Point(812, 12);
            textBox.Name = "textBox";
            textBox.Size = new Size(411, 397);
            textBox.TabIndex = 3;
            textBox.Text = "";
            // 
            // TextBoxSoftwareName
            // 
            TextBoxSoftwareName.Location = new Point(457, 415);
            TextBoxSoftwareName.Name = "TextBoxSoftwareName";
            TextBoxSoftwareName.Size = new Size(169, 23);
            TextBoxSoftwareName.TabIndex = 4;
            // 
            // connecting_textLabel
            // 
            connecting_textLabel.AutoSize = true;
            connecting_textLabel.Location = new Point(330, 419);
            connecting_textLabel.Name = "connecting_textLabel";
            connecting_textLabel.Size = new Size(0, 15);
            connecting_textLabel.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 450);
            Controls.Add(connecting_textLabel);
            Controls.Add(TextBoxSoftwareName);
            Controls.Add(textBox);
            Controls.Add(resultTable);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)resultTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private DataGridView resultTable;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Published;
        private DataGridViewTextBoxColumn LastModified;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn CVSS_Score;
        private RichTextBox textBox;
        private TextBox TextBoxSoftwareName;
        private Label connecting_textLabel;
    }
}
