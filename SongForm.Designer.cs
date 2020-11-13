namespace HubertFedorowiczPAINLab1
{
    partial class SongForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param title="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SongForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.authorTextBox = new System.Windows.Forms.TextBox();
            this.recordingDayDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.genreTextBox = new System.Windows.Forms.TextBox();
            this.genreButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tytuł";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wykonawca";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data Wydania";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new System.Drawing.Point(88, 12);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(248, 20);
            this.titleTextBox.TabIndex = 3;
            this.titleTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            // 
            // authorTextBox
            // 
            this.authorTextBox.Location = new System.Drawing.Point(88, 38);
            this.authorTextBox.Name = "authorTextBox";
            this.authorTextBox.Size = new System.Drawing.Size(248, 20);
            this.authorTextBox.TabIndex = 4;
            this.authorTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            // 
            // recordingDayDateTimePicker
            // 
            this.recordingDayDateTimePicker.Location = new System.Drawing.Point(88, 64);
            this.recordingDayDateTimePicker.Name = "recordingDayDateTimePicker";
            this.recordingDayDateTimePicker.Size = new System.Drawing.Size(156, 20);
            this.recordingDayDateTimePicker.TabIndex = 5;
            this.recordingDayDateTimePicker.Value = new System.DateTime(1990, 6, 2, 0, 0, 0, 0);
            this.recordingDayDateTimePicker.Validating += new System.ComponentModel.CancelEventHandler(this.Validating);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(88, 126);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "Dodaj";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(169, 126);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Anuluj";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Gere";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // genreTextBox
            // 
            this.genreTextBox.Location = new System.Drawing.Point(88, 90);
            this.genreTextBox.Name = "genreTextBox";
            this.genreTextBox.ReadOnly = true;
            this.genreTextBox.Size = new System.Drawing.Size(156, 20);
            this.genreTextBox.TabIndex = 9;
            this.genreTextBox.Text = "Rock&Roll";
            this.genreTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.GenreTextBox_Validating);
            // 
            // genreButton
            // 
            this.genreButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.genreButton.Image = ((System.Drawing.Image)(resources.GetObject("genreButton.Image")));
            this.genreButton.Location = new System.Drawing.Point(250, 64);
            this.genreButton.Name = "genreButton";
            this.genreButton.Size = new System.Drawing.Size(89, 85);
            this.genreButton.TabIndex = 10;
            this.genreButton.UseVisualStyleBackColor = true;
            this.genreButton.Click += new System.EventHandler(this.ChangeGenre);
            // 
            // SongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 160);
            this.Controls.Add(this.genreButton);
            this.Controls.Add(this.genreTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.recordingDayDateTimePicker);
            this.Controls.Add(this.authorTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SongForm";
            this.Text = "Song";
            this.Load += new System.EventHandler(this.SongForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.TextBox authorTextBox;
        private System.Windows.Forms.DateTimePicker recordingDayDateTimePicker;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox genreTextBox;
        private System.Windows.Forms.Button genreButton;
    }
}