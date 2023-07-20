namespace _06_EXCEL
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoadExcel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGViewExcel_01 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart_02 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGViewExcel_02 = new System.Windows.Forms.DataGridView();
            this.btnLINQ_01 = new System.Windows.Forms.Button();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGViewExcel_01)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_02)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGViewExcel_02)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Location = new System.Drawing.Point(1339, 40);
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(220, 106);
            this.btnLoadExcel.TabIndex = 0;
            this.btnLoadExcel.Text = "Load Excel";
            this.btnLoadExcel.UseVisualStyleBackColor = true;
            this.btnLoadExcel.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1332, 905);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGViewExcel_01);
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1324, 873);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGViewExcel_01
            // 
            this.dataGViewExcel_01.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGViewExcel_01.Location = new System.Drawing.Point(6, 6);
            this.dataGViewExcel_01.Name = "dataGViewExcel_01";
            this.dataGViewExcel_01.RowHeadersWidth = 62;
            this.dataGViewExcel_01.RowTemplate.Height = 31;
            this.dataGViewExcel_01.Size = new System.Drawing.Size(1312, 867);
            this.dataGViewExcel_01.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart_02);
            this.tabPage2.Controls.Add(this.dataGViewExcel_02);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1324, 873);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart_02
            // 
            chartArea1.Name = "ChartArea1";
            this.chart_02.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_02.Legends.Add(legend1);
            this.chart_02.Location = new System.Drawing.Point(7, 478);
            this.chart_02.Name = "chart_02";
            this.chart_02.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_02.Series.Add(series1);
            this.chart_02.Size = new System.Drawing.Size(1311, 392);
            this.chart_02.TabIndex = 1;
            this.chart_02.Text = "chart1";
            // 
            // dataGViewExcel_02
            // 
            this.dataGViewExcel_02.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGViewExcel_02.Location = new System.Drawing.Point(3, 6);
            this.dataGViewExcel_02.Name = "dataGViewExcel_02";
            this.dataGViewExcel_02.RowHeadersWidth = 62;
            this.dataGViewExcel_02.RowTemplate.Height = 31;
            this.dataGViewExcel_02.Size = new System.Drawing.Size(1322, 466);
            this.dataGViewExcel_02.TabIndex = 0;
            // 
            // btnLINQ_01
            // 
            this.btnLINQ_01.Location = new System.Drawing.Point(1577, 40);
            this.btnLINQ_01.Name = "btnLINQ_01";
            this.btnLINQ_01.Size = new System.Drawing.Size(219, 106);
            this.btnLINQ_01.TabIndex = 2;
            this.btnLINQ_01.Text = "button1";
            this.btnLINQ_01.UseVisualStyleBackColor = true;
            this.btnLINQ_01.Click += new System.EventHandler(this.btnLINQ_01_Click);
            // 
            // listBoxLog
            // 
            this.listBoxLog.BackColor = System.Drawing.Color.Black;
            this.listBoxLog.Font = new System.Drawing.Font("新細明體", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.listBoxLog.ForeColor = System.Drawing.Color.Lime;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.ItemHeight = 28;
            this.listBoxLog.Location = new System.Drawing.Point(1339, 506);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(616, 396);
            this.listBoxLog.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1339, 164);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(220, 112);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1962, 930);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxLog);
            this.Controls.Add(this.btnLINQ_01);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnLoadExcel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGViewExcel_01)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_02)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGViewExcel_02)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLoadExcel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGViewExcel_01;
        private System.Windows.Forms.DataGridView dataGViewExcel_02;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_02;
        private System.Windows.Forms.Button btnLINQ_01;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.Button button1;
    }
}

