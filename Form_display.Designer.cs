namespace Project_2
{
    partial class Form_display
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.diffPrice = new System.Windows.Forms.Label();
            this.comboBox_modelChange = new System.Windows.Forms.ComboBox();
            this.refreshButton = new System.Windows.Forms.Button();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.period = new System.Windows.Forms.Label();
            this.stockName = new System.Windows.Forms.Label();
            this.candleStick_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.p6 = new System.Windows.Forms.Label();
            this.p0 = new System.Windows.Forms.Label();
            this.p5 = new System.Windows.Forms.Label();
            this.p4 = new System.Windows.Forms.Label();
            this.p3 = new System.Windows.Forms.Label();
            this.p2 = new System.Windows.Forms.Label();
            this.p1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.beautyscore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.candleStick_chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // diffPrice
            // 
            this.diffPrice.AutoSize = true;
            this.diffPrice.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.diffPrice.Location = new System.Drawing.Point(766, 168);
            this.diffPrice.Name = "diffPrice";
            this.diffPrice.Size = new System.Drawing.Size(138, 17);
            this.diffPrice.TabIndex = 28;
            this.diffPrice.Text = "Different Price Change";
            // 
            // comboBox_modelChange
            // 
            this.comboBox_modelChange.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.comboBox_modelChange.FormattingEnabled = true;
            this.comboBox_modelChange.Location = new System.Drawing.Point(1358, 62);
            this.comboBox_modelChange.Name = "comboBox_modelChange";
            this.comboBox_modelChange.Size = new System.Drawing.Size(254, 25);
            this.comboBox_modelChange.TabIndex = 27;
            this.comboBox_modelChange.SelectedIndexChanged += new System.EventHandler(this.comboBox_modelChange_SelectedIndexChanged);
            // 
            // refreshButton
            // 
            this.refreshButton.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.refreshButton.Location = new System.Drawing.Point(1358, 118);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(135, 53);
            this.refreshButton.TabIndex = 26;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // endDate
            // 
            this.endDate.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.endDate.Location = new System.Drawing.Point(84, 168);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(254, 25);
            this.endDate.TabIndex = 23;
            // 
            // startDate
            // 
            this.startDate.Font = new System.Drawing.Font("Nirmala UI", 7.8F);
            this.startDate.Location = new System.Drawing.Point(84, 78);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(254, 25);
            this.startDate.TabIndex = 22;
            this.startDate.Value = new System.DateTime(2022, 11, 9, 0, 0, 0, 0);
            // 
            // period
            // 
            this.period.AutoSize = true;
            this.period.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.period.Location = new System.Drawing.Point(820, 14);
            this.period.Name = "period";
            this.period.Size = new System.Drawing.Size(59, 22);
            this.period.TabIndex = 21;
            this.period.Text = "Period";
            // 
            // stockName
            // 
            this.stockName.AutoSize = true;
            this.stockName.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockName.Location = new System.Drawing.Point(907, 14);
            this.stockName.Name = "stockName";
            this.stockName.Size = new System.Drawing.Size(101, 22);
            this.stockName.TabIndex = 20;
            this.stockName.Text = "Stock Name";
            // 
            // candleStick_chart
            // 
            this.candleStick_chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(69)))), ((int)(((byte)(90)))));
            this.candleStick_chart.BorderlineWidth = 0;
            chartArea1.Name = "AreaOHLC";
            chartArea2.AlignWithChartArea = "AreaOHLC";
            chartArea2.Name = "AreaVolume";
            chartArea3.Name = "beauty";
            this.candleStick_chart.ChartAreas.Add(chartArea1);
            this.candleStick_chart.ChartAreas.Add(chartArea2);
            this.candleStick_chart.ChartAreas.Add(chartArea3);
            this.candleStick_chart.Location = new System.Drawing.Point(31, 56);
            this.candleStick_chart.Margin = new System.Windows.Forms.Padding(0);
            this.candleStick_chart.Name = "candleStick_chart";
            series1.ChartArea = "AreaOHLC";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.CustomProperties = "PriceDownColor=Red, PriceUpColor=Lime";
            series1.MarkerBorderColor = System.Drawing.Color.White;
            series1.Name = "Series_ohlc";
            series1.XValueMember = "date";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series1.YValueMembers = "high, low, open, close";
            series1.YValuesPerPoint = 4;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            series2.ChartArea = "AreaVolume";
            series2.Name = "Series_volume";
            series2.XValueMember = "date";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Date;
            series2.YValueMembers = "volume";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int64;
            this.candleStick_chart.Series.Add(series1);
            this.candleStick_chart.Series.Add(series2);
            this.candleStick_chart.Size = new System.Drawing.Size(1718, 623);
            this.candleStick_chart.TabIndex = 30;
            this.candleStick_chart.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Stock_Loader_2.Properties.Resources.wp9900347;
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1810, 976);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Underline);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(80, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "Start Date: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Underline);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label2.Location = new System.Drawing.Point(80, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "End Date: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Underline);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label3.Location = new System.Drawing.Point(823, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(197, 23);
            this.label3.TabIndex = 34;
            this.label3.Text = "Price Change Difference:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(87)))), ((int)(((byte)(107)))));
            this.panel1.Controls.Add(this.p6);
            this.panel1.Controls.Add(this.p0);
            this.panel1.Controls.Add(this.p5);
            this.panel1.Controls.Add(this.p4);
            this.panel1.Controls.Add(this.p3);
            this.panel1.Controls.Add(this.p2);
            this.panel1.Controls.Add(this.p1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.candleStick_chart);
            this.panel1.Controls.Add(this.period);
            this.panel1.Controls.Add(this.stockName);
            this.panel1.Location = new System.Drawing.Point(12, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1779, 696);
            this.panel1.TabIndex = 35;
            // 
            // p6
            // 
            this.p6.AutoSize = true;
            this.p6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p6.Location = new System.Drawing.Point(1654, 199);
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(40, 16);
            this.p6.TabIndex = 46;
            this.p6.Text = "100%";
            // 
            // p0
            // 
            this.p0.AutoSize = true;
            this.p0.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p0.Location = new System.Drawing.Point(1654, 103);
            this.p0.Name = "p0";
            this.p0.Size = new System.Drawing.Size(26, 16);
            this.p0.TabIndex = 45;
            this.p0.Text = "0%";
            // 
            // p5
            // 
            this.p5.AutoSize = true;
            this.p5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p5.Location = new System.Drawing.Point(1654, 183);
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(31, 16);
            this.p5.TabIndex = 44;
            this.p5.Text = "76.4";
            // 
            // p4
            // 
            this.p4.AutoSize = true;
            this.p4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p4.Location = new System.Drawing.Point(1654, 167);
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(43, 16);
            this.p4.TabIndex = 43;
            this.p4.Text = "62.8%";
            // 
            // p3
            // 
            this.p3.AutoSize = true;
            this.p3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p3.Location = new System.Drawing.Point(1654, 151);
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(33, 16);
            this.p3.TabIndex = 42;
            this.p3.Text = "50%";
            // 
            // p2
            // 
            this.p2.AutoSize = true;
            this.p2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2.Location = new System.Drawing.Point(1654, 135);
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(43, 16);
            this.p2.TabIndex = 41;
            this.p2.Text = "38.2%";
            // 
            // p1
            // 
            this.p1.AutoSize = true;
            this.p1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p1.Location = new System.Drawing.Point(1654, 119);
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(43, 16);
            this.p1.TabIndex = 40;
            this.p1.Text = "23.6%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(885, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 22);
            this.label4.TabIndex = 31;
            this.label4.Text = "-";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Underline);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label5.Location = new System.Drawing.Point(1354, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(139, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "Create Annotations:";
            // 
            // beautyscore
            // 
            this.beautyscore.AutoSize = true;
            this.beautyscore.Location = new System.Drawing.Point(515, 181);
            this.beautyscore.Name = "beautyscore";
            this.beautyscore.Size = new System.Drawing.Size(85, 16);
            this.beautyscore.TabIndex = 37;
            this.beautyscore.Text = "BeautyScore";
            // 
            // Form_display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1803, 967);
            this.Controls.Add(this.beautyscore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.diffPrice);
            this.Controls.Add(this.comboBox_modelChange);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form_display";
            this.Text = "Chart Form";
            ((System.ComponentModel.ISupportInitialize)(this.candleStick_chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label diffPrice;
        private System.Windows.Forms.ComboBox comboBox_modelChange;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.Label period;
        private System.Windows.Forms.Label stockName;
        private System.Windows.Forms.DataVisualization.Charting.Chart candleStick_chart;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label beautyscore;
        private System.Windows.Forms.Label p1;
        private System.Windows.Forms.Label p0;
        private System.Windows.Forms.Label p5;
        private System.Windows.Forms.Label p4;
        private System.Windows.Forms.Label p3;
        private System.Windows.Forms.Label p2;
        private System.Windows.Forms.Label p6;
    }
}