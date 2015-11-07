namespace ImageTask1
{
    partial class MaskMatrix
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
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Fill = new System.Windows.Forms.Button();
            this.OriginXBox = new System.Windows.Forms.TextBox();
            this.OriginYBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.RadioButton2D = new System.Windows.Forms.RadioButton();
            this.RadioButton1D = new System.Windows.Forms.RadioButton();
            this.AfterPictureBox = new System.Windows.Forms.PictureBox();
            this.BeforePictureBox = new System.Windows.Forms.PictureBox();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AfterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(81, 19);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(100, 20);
            this.WidthBox.TabIndex = 0;
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(81, 62);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(100, 20);
            this.HeightBox.TabIndex = 1;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(113, 220);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(75, 23);
            this.Create.TabIndex = 2;
            this.Create.Text = "Create";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Generate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Width";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Height";
            // 
            // Fill
            // 
            this.Fill.Location = new System.Drawing.Point(16, 220);
            this.Fill.Name = "Fill";
            this.Fill.Size = new System.Drawing.Size(75, 23);
            this.Fill.TabIndex = 6;
            this.Fill.Text = "Submit";
            this.Fill.UseVisualStyleBackColor = true;
            this.Fill.Click += new System.EventHandler(this.Fill_Click);
            // 
            // OriginXBox
            // 
            this.OriginXBox.Location = new System.Drawing.Point(140, 106);
            this.OriginXBox.Name = "OriginXBox";
            this.OriginXBox.Size = new System.Drawing.Size(21, 20);
            this.OriginXBox.TabIndex = 7;
            // 
            // OriginYBox
            // 
            this.OriginYBox.Location = new System.Drawing.Point(140, 130);
            this.OriginYBox.Name = "OriginYBox";
            this.OriginYBox.Size = new System.Drawing.Size(21, 20);
            this.OriginYBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Origin X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Origin Y";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel1.Controls.Add(this.RadioButton2D);
            this.splitContainer1.Panel1.Controls.Add(this.WidthBox);
            this.splitContainer1.Panel1.Controls.Add(this.RadioButton1D);
            this.splitContainer1.Panel1.Controls.Add(this.Fill);
            this.splitContainer1.Panel1.Controls.Add(this.Create);
            this.splitContainer1.Panel1.Controls.Add(this.OriginYBox);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.HeightBox);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.OriginXBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.PreviewButton);
            this.splitContainer1.Panel2.Controls.Add(this.ApplyButton);
            this.splitContainer1.Panel2.Controls.Add(this.AfterPictureBox);
            this.splitContainer1.Panel2.Controls.Add(this.BeforePictureBox);
            this.splitContainer1.Size = new System.Drawing.Size(848, 373);
            this.splitContainer1.SplitterDistance = 282;
            this.splitContainer1.TabIndex = 12;
            // 
            // RadioButton2D
            // 
            this.RadioButton2D.AutoSize = true;
            this.RadioButton2D.Checked = true;
            this.RadioButton2D.Location = new System.Drawing.Point(113, 162);
            this.RadioButton2D.Name = "RadioButton2D";
            this.RadioButton2D.Size = new System.Drawing.Size(68, 17);
            this.RadioButton2D.TabIndex = 19;
            this.RadioButton2D.TabStop = true;
            this.RadioButton2D.Text = "2D Mask";
            this.RadioButton2D.UseVisualStyleBackColor = true;
            // 
            // RadioButton1D
            // 
            this.RadioButton1D.AutoSize = true;
            this.RadioButton1D.Location = new System.Drawing.Point(16, 162);
            this.RadioButton1D.Name = "RadioButton1D";
            this.RadioButton1D.Size = new System.Drawing.Size(68, 17);
            this.RadioButton1D.TabIndex = 18;
            this.RadioButton1D.TabStop = true;
            this.RadioButton1D.Text = "1D Mask";
            this.RadioButton1D.UseVisualStyleBackColor = true;
            // 
            // AfterPictureBox
            // 
            this.AfterPictureBox.Location = new System.Drawing.Point(297, 26);
            this.AfterPictureBox.Name = "AfterPictureBox";
            this.AfterPictureBox.Size = new System.Drawing.Size(208, 178);
            this.AfterPictureBox.TabIndex = 17;
            this.AfterPictureBox.TabStop = false;
            // 
            // BeforePictureBox
            // 
            this.BeforePictureBox.Location = new System.Drawing.Point(32, 26);
            this.BeforePictureBox.Name = "BeforePictureBox";
            this.BeforePictureBox.Size = new System.Drawing.Size(208, 178);
            this.BeforePictureBox.TabIndex = 16;
            this.BeforePictureBox.TabStop = false;
            // 
            // PreviewButton
            // 
            this.PreviewButton.Location = new System.Drawing.Point(416, 299);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(89, 37);
            this.PreviewButton.TabIndex = 19;
            this.PreviewButton.Text = "Preview";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(416, 244);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(89, 41);
            this.ApplyButton.TabIndex = 18;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Mean Filter",
            "Sobel Filter",
            "Laplacian Filter"});
            this.comboBox1.Location = new System.Drawing.Point(31, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(130, 21);
            this.comboBox1.TabIndex = 20;
            // 
            // MaskMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 373);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Name = "MaskMatrix";
            this.Text = "MaskMatrix";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AfterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BeforePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Fill;
        private System.Windows.Forms.TextBox OriginXBox;
        private System.Windows.Forms.TextBox OriginYBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton RadioButton2D;
        private System.Windows.Forms.RadioButton RadioButton1D;
        private System.Windows.Forms.PictureBox AfterPictureBox;
        private System.Windows.Forms.PictureBox BeforePictureBox;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}