namespace Project_2
{
    partial class Form_input
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
            this.dateTimePicker_startDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_endDate = new System.Windows.Forms.DateTimePicker();
            this.start_date = new System.Windows.Forms.Label();
            this.end_date = new System.Windows.Forms.Label();
            this.loadButton = new System.Windows.Forms.Button();
            this.openFileDialog_stockUpload = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dateTimePicker_startDate
            // 
            this.dateTimePicker_startDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.dateTimePicker_startDate.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker_startDate.Location = new System.Drawing.Point(63, 106);
            this.dateTimePicker_startDate.Name = "dateTimePicker_startDate";
            this.dateTimePicker_startDate.Size = new System.Drawing.Size(243, 25);
            this.dateTimePicker_startDate.TabIndex = 0;
            this.dateTimePicker_startDate.Value = new System.DateTime(2022, 1, 1, 0, 0, 0, 0);
            // 
            // dateTimePicker_endDate
            // 
            this.dateTimePicker_endDate.CalendarTitleForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.dateTimePicker_endDate.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.dateTimePicker_endDate.Location = new System.Drawing.Point(63, 201);
            this.dateTimePicker_endDate.Name = "dateTimePicker_endDate";
            this.dateTimePicker_endDate.Size = new System.Drawing.Size(243, 25);
            this.dateTimePicker_endDate.TabIndex = 1;
            // 
            // start_date
            // 
            this.start_date.AutoSize = true;
            this.start_date.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Underline);
            this.start_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.start_date.Location = new System.Drawing.Point(60, 80);
            this.start_date.Name = "start_date";
            this.start_date.Size = new System.Drawing.Size(86, 23);
            this.start_date.TabIndex = 2;
            this.start_date.Text = "Start Date";
            // 
            // end_date
            // 
            this.end_date.AutoSize = true;
            this.end_date.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Underline);
            this.end_date.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.end_date.Location = new System.Drawing.Point(60, 175);
            this.end_date.Name = "end_date";
            this.end_date.Size = new System.Drawing.Size(80, 23);
            this.end_date.TabIndex = 3;
            this.end_date.Text = "End Date";
            // 
            // loadButton
            // 
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadButton.Font = new System.Drawing.Font("Nirmala UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.loadButton.Location = new System.Drawing.Point(62, 250);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(244, 54);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load Stock(s)";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // openFileDialog_stockUpload
            // 
            this.openFileDialog_stockUpload.FileName = "openFileDialog";
            this.openFileDialog_stockUpload.Filter = "All Files|*.*|CSV Files|*.csv|Monthly Files|*-Month.csv|Daily Files|*-Day.csv|Wee" +
    "kly Files|*-Week.csv";
            this.openFileDialog_stockUpload.InitialDirectory = "C:...\\Project_2\\Stock Data";
            this.openFileDialog_stockUpload.Multiselect = true;
            this.openFileDialog_stockUpload.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_stockUpload_FileOk);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stock_Loader_2.Properties.Resources._0_nw1HVdtB47MKZx9Z;
            this.pictureBox1.Location = new System.Drawing.Point(407, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(277, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form_input
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(737, 328);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.end_date);
            this.Controls.Add(this.start_date);
            this.Controls.Add(this.dateTimePicker_endDate);
            this.Controls.Add(this.dateTimePicker_startDate);
            this.Name = "Form_input";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Form To Load Stock";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_startDate;
        private System.Windows.Forms.DateTimePicker dateTimePicker_endDate;
        private System.Windows.Forms.Label start_date;
        private System.Windows.Forms.Label end_date;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog_stockUpload;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

