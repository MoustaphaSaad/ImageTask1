namespace ImageTask1
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BlueFlag = new System.Windows.Forms.CheckBox();
            this.GreenFlag = new System.Windows.Forms.CheckBox();
            this.RedFlag = new System.Windows.Forms.CheckBox();
            this.IntensityFlag = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pixelOperationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pixelOperationsToolStripMenuItem
            // 
            this.pixelOperationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.grayScaleToolStripMenuItem,
            this.brightnessToolStripMenuItem,
            this.contrastToolStripMenuItem,
            this.filtersToolStripMenuItem});
            this.pixelOperationsToolStripMenuItem.Name = "pixelOperationsToolStripMenuItem";
            this.pixelOperationsToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.pixelOperationsToolStripMenuItem.Text = "Pixel Operations";
            // 
            // grayScaleToolStripMenuItem
            // 
            this.grayScaleToolStripMenuItem.Name = "grayScaleToolStripMenuItem";
            this.grayScaleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.grayScaleToolStripMenuItem.Text = "Gray Scale";
            this.grayScaleToolStripMenuItem.Click += new System.EventHandler(this.GrayScale_Click);
            // 
            // brightnessToolStripMenuItem
            // 
            this.brightnessToolStripMenuItem.Name = "brightnessToolStripMenuItem";
            this.brightnessToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.brightnessToolStripMenuItem.Text = "Brightness";
            this.brightnessToolStripMenuItem.Click += new System.EventHandler(this.Brightness_Click);
            // 
            // contrastToolStripMenuItem
            // 
            this.contrastToolStripMenuItem.Name = "contrastToolStripMenuItem";
            this.contrastToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contrastToolStripMenuItem.Text = "Contrast";
            this.contrastToolStripMenuItem.Click += new System.EventHandler(this.contrastToolStripMenuItem_Click);
            // 
            // chart2
            // 
            chartArea1.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea1);
            this.chart2.Location = new System.Drawing.Point(874, 214);
            this.chart2.Name = "chart2";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Gray;
            series1.MarkerColor = System.Drawing.Color.Black;
            series1.Name = "Intensity";
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.Red;
            series2.Name = "Red";
            series3.ChartArea = "ChartArea1";
            series3.Color = System.Drawing.Color.Lime;
            series3.Name = "Green";
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Blue;
            series4.Name = "Blue";
            this.chart2.Series.Add(series1);
            this.chart2.Series.Add(series2);
            this.chart2.Series.Add(series3);
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(193, 161);
            this.chart2.TabIndex = 15;
            this.chart2.Text = "chart2";
            // 
            // BlueFlag
            // 
            this.BlueFlag.AutoSize = true;
            this.BlueFlag.Location = new System.Drawing.Point(980, 405);
            this.BlueFlag.Name = "BlueFlag";
            this.BlueFlag.Size = new System.Drawing.Size(47, 17);
            this.BlueFlag.TabIndex = 14;
            this.BlueFlag.Text = "Blue";
            this.BlueFlag.UseVisualStyleBackColor = true;
            this.BlueFlag.CheckedChanged += new System.EventHandler(this.IntensityFlag_CheckedChanged);
            // 
            // GreenFlag
            // 
            this.GreenFlag.AutoSize = true;
            this.GreenFlag.Location = new System.Drawing.Point(890, 405);
            this.GreenFlag.Name = "GreenFlag";
            this.GreenFlag.Size = new System.Drawing.Size(55, 17);
            this.GreenFlag.TabIndex = 13;
            this.GreenFlag.Text = "Green";
            this.GreenFlag.UseVisualStyleBackColor = true;
            this.GreenFlag.CheckedChanged += new System.EventHandler(this.IntensityFlag_CheckedChanged);
            // 
            // RedFlag
            // 
            this.RedFlag.AutoSize = true;
            this.RedFlag.Location = new System.Drawing.Point(980, 382);
            this.RedFlag.Name = "RedFlag";
            this.RedFlag.Size = new System.Drawing.Size(46, 17);
            this.RedFlag.TabIndex = 12;
            this.RedFlag.Text = "Red";
            this.RedFlag.UseVisualStyleBackColor = true;
            this.RedFlag.CheckedChanged += new System.EventHandler(this.IntensityFlag_CheckedChanged);
            // 
            // IntensityFlag
            // 
            this.IntensityFlag.AutoSize = true;
            this.IntensityFlag.Checked = true;
            this.IntensityFlag.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IntensityFlag.Location = new System.Drawing.Point(890, 382);
            this.IntensityFlag.Name = "IntensityFlag";
            this.IntensityFlag.Size = new System.Drawing.Size(65, 17);
            this.IntensityFlag.TabIndex = 11;
            this.IntensityFlag.Text = "Intensity";
            this.IntensityFlag.UseVisualStyleBackColor = true;
            this.IntensityFlag.CheckedChanged += new System.EventHandler(this.IntensityFlag_CheckedChanged);
            // 
            // chart1
            // 
            this.chart1.BorderlineWidth = 0;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(874, 30);
            this.chart1.Name = "chart1";
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.Gray;
            series5.MarkerColor = System.Drawing.Color.Black;
            series5.Name = "Intensity";
            series6.ChartArea = "ChartArea1";
            series6.Color = System.Drawing.Color.Red;
            series6.Name = "Red";
            series7.ChartArea = "ChartArea1";
            series7.Color = System.Drawing.Color.Lime;
            series7.Name = "Green";
            series8.ChartArea = "ChartArea1";
            series8.Color = System.Drawing.Color.Blue;
            series8.Name = "Blue";
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Series.Add(series7);
            this.chart1.Series.Add(series8);
            this.chart1.Size = new System.Drawing.Size(193, 161);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobalToolStripMenuItem,
            this.meanToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // meanToolStripMenuItem
            // 
            this.meanToolStripMenuItem.Name = "meanToolStripMenuItem";
            this.meanToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.meanToolStripMenuItem.Text = "Mean";
            this.meanToolStripMenuItem.Click += new System.EventHandler(this.meanToolStripMenuItem_Click);
            // 
            // sobalToolStripMenuItem
            // 
            this.sobalToolStripMenuItem.Name = "sobalToolStripMenuItem";
            this.sobalToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sobalToolStripMenuItem.Text = "Sobal";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 476);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.BlueFlag);
            this.Controls.Add(this.GreenFlag);
            this.Controls.Add(this.RedFlag);
            this.Controls.Add(this.IntensityFlag);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pixelOperationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightnessToolStripMenuItem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.CheckBox BlueFlag;
        private System.Windows.Forms.CheckBox GreenFlag;
        private System.Windows.Forms.CheckBox RedFlag;
        private System.Windows.Forms.CheckBox IntensityFlag;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripMenuItem contrastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meanToolStripMenuItem;

    }
}