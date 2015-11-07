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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pixelOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightnessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.BlueFlag = new System.Windows.Forms.CheckBox();
            this.GreenFlag = new System.Windows.Forms.CheckBox();
            this.RedFlag = new System.Windows.Forms.CheckBox();
            this.IntensityFlag = new System.Windows.Forms.CheckBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.pixelOperationsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1071, 24);
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
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
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filtersToolStripMenuItem.Text = "Filters";
            this.filtersToolStripMenuItem.Click += new System.EventHandler(this.filtersToolStripMenuItem_Click);
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            this.chart2.Location = new System.Drawing.Point(39, 193);
            this.chart2.Name = "chart2";
            series9.ChartArea = "ChartArea1";
            series9.Color = System.Drawing.Color.Gray;
            series9.MarkerColor = System.Drawing.Color.Black;
            series9.Name = "Intensity";
            series10.ChartArea = "ChartArea1";
            series10.Color = System.Drawing.Color.Red;
            series10.Name = "Red";
            series11.ChartArea = "ChartArea1";
            series11.Color = System.Drawing.Color.Lime;
            series11.Name = "Green";
            series12.ChartArea = "ChartArea1";
            series12.Color = System.Drawing.Color.Blue;
            series12.Name = "Blue";
            this.chart2.Series.Add(series9);
            this.chart2.Series.Add(series10);
            this.chart2.Series.Add(series11);
            this.chart2.Series.Add(series12);
            this.chart2.Size = new System.Drawing.Size(193, 161);
            this.chart2.TabIndex = 15;
            this.chart2.Text = "chart2";
            // 
            // BlueFlag
            // 
            this.BlueFlag.AutoSize = true;
            this.BlueFlag.Location = new System.Drawing.Point(160, 393);
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
            this.GreenFlag.Location = new System.Drawing.Point(75, 393);
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
            this.RedFlag.Location = new System.Drawing.Point(160, 370);
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
            this.IntensityFlag.Location = new System.Drawing.Point(75, 370);
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
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.Location = new System.Drawing.Point(39, 19);
            this.chart1.Name = "chart1";
            series13.ChartArea = "ChartArea1";
            series13.Color = System.Drawing.Color.Gray;
            series13.MarkerColor = System.Drawing.Color.Black;
            series13.Name = "Intensity";
            series14.ChartArea = "ChartArea1";
            series14.Color = System.Drawing.Color.Red;
            series14.Name = "Red";
            series15.ChartArea = "ChartArea1";
            series15.Color = System.Drawing.Color.Lime;
            series15.Name = "Green";
            series16.ChartArea = "ChartArea1";
            series16.Color = System.Drawing.Color.Blue;
            series16.Name = "Blue";
            this.chart1.Series.Add(series13);
            this.chart1.Series.Add(series14);
            this.chart1.Series.Add(series15);
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(193, 161);
            this.chart1.TabIndex = 10;
            this.chart1.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chart1);
            this.groupBox1.Controls.Add(this.BlueFlag);
            this.groupBox1.Controls.Add(this.chart2);
            this.groupBox1.Controls.Add(this.RedFlag);
            this.groupBox1.Controls.Add(this.GreenFlag);
            this.groupBox1.Controls.Add(this.IntensityFlag);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(797, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 460);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 484);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox1;

    }
}