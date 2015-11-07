namespace ImageTask1
{
    partial class OperationsForm
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
            this.BeforePictureBox = new System.Windows.Forms.PictureBox();
            this.AfterPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.Slider = new System.Windows.Forms.TrackBar();
            this.RadioButton1D = new System.Windows.Forms.RadioButton();
            this.RadioButton2D = new System.Windows.Forms.RadioButton();
            this.MaskGroupBox = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OriginYTextBox = new System.Windows.Forms.TextBox();
            this.OriginXTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.MaskHeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.MaskWidthTextBox = new System.Windows.Forms.TextBox();
            this.PreviewButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BeforePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
            this.MaskGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // BeforePictureBox
            // 
            this.BeforePictureBox.Location = new System.Drawing.Point(32, 33);
            this.BeforePictureBox.Name = "BeforePictureBox";
            this.BeforePictureBox.Size = new System.Drawing.Size(208, 178);
            this.BeforePictureBox.TabIndex = 0;
            this.BeforePictureBox.TabStop = false;
            // 
            // AfterPictureBox
            // 
            this.AfterPictureBox.Location = new System.Drawing.Point(297, 33);
            this.AfterPictureBox.Name = "AfterPictureBox";
            this.AfterPictureBox.Size = new System.Drawing.Size(208, 178);
            this.AfterPictureBox.TabIndex = 1;
            this.AfterPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Before";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "After";
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(435, 234);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(89, 41);
            this.ApplyButton.TabIndex = 4;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // Slider
            // 
            this.Slider.LargeChange = 15;
            this.Slider.Location = new System.Drawing.Point(50, 267);
            this.Slider.Maximum = 255;
            this.Slider.Minimum = -255;
            this.Slider.Name = "Slider";
            this.Slider.Size = new System.Drawing.Size(190, 45);
            this.Slider.SmallChange = 2;
            this.Slider.TabIndex = 13;
            this.Slider.Scroll += new System.EventHandler(this.Slider_Scroll);
            // 
            // RadioButton1D
            // 
            this.RadioButton1D.AutoSize = true;
            this.RadioButton1D.Location = new System.Drawing.Point(32, 234);
            this.RadioButton1D.Name = "RadioButton1D";
            this.RadioButton1D.Size = new System.Drawing.Size(68, 17);
            this.RadioButton1D.TabIndex = 14;
            this.RadioButton1D.TabStop = true;
            this.RadioButton1D.Text = "1D Mask";
            this.RadioButton1D.UseVisualStyleBackColor = true;
            // 
            // RadioButton2D
            // 
            this.RadioButton2D.AutoSize = true;
            this.RadioButton2D.Location = new System.Drawing.Point(32, 257);
            this.RadioButton2D.Name = "RadioButton2D";
            this.RadioButton2D.Size = new System.Drawing.Size(68, 17);
            this.RadioButton2D.TabIndex = 15;
            this.RadioButton2D.TabStop = true;
            this.RadioButton2D.Text = "2D Mask";
            this.RadioButton2D.UseVisualStyleBackColor = true;
            // 
            // MaskGroupBox
            // 
            this.MaskGroupBox.Controls.Add(this.label6);
            this.MaskGroupBox.Controls.Add(this.label5);
            this.MaskGroupBox.Controls.Add(this.OriginYTextBox);
            this.MaskGroupBox.Controls.Add(this.OriginXTextbox);
            this.MaskGroupBox.Controls.Add(this.label4);
            this.MaskGroupBox.Controls.Add(this.MaskHeightTextBox);
            this.MaskGroupBox.Controls.Add(this.label3);
            this.MaskGroupBox.Controls.Add(this.MaskWidthTextBox);
            this.MaskGroupBox.Location = new System.Drawing.Point(165, 217);
            this.MaskGroupBox.Name = "MaskGroupBox";
            this.MaskGroupBox.Size = new System.Drawing.Size(245, 122);
            this.MaskGroupBox.TabIndex = 16;
            this.MaskGroupBox.TabStop = false;
            this.MaskGroupBox.Text = "Mask input";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Origin Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Origin X";
            // 
            // OriginYTextBox
            // 
            this.OriginYTextBox.Location = new System.Drawing.Point(106, 97);
            this.OriginYTextBox.Name = "OriginYTextBox";
            this.OriginYTextBox.Size = new System.Drawing.Size(100, 20);
            this.OriginYTextBox.TabIndex = 5;
            this.OriginYTextBox.Tag = "";
            // 
            // OriginXTextbox
            // 
            this.OriginXTextbox.Location = new System.Drawing.Point(106, 71);
            this.OriginXTextbox.Name = "OriginXTextbox";
            this.OriginXTextbox.Size = new System.Drawing.Size(100, 20);
            this.OriginXTextbox.TabIndex = 4;
            this.OriginXTextbox.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Height";
            // 
            // MaskHeightTextBox
            // 
            this.MaskHeightTextBox.Location = new System.Drawing.Point(106, 45);
            this.MaskHeightTextBox.Name = "MaskHeightTextBox";
            this.MaskHeightTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaskHeightTextBox.TabIndex = 2;
            this.MaskHeightTextBox.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Width";
            // 
            // MaskWidthTextBox
            // 
            this.MaskWidthTextBox.Location = new System.Drawing.Point(106, 19);
            this.MaskWidthTextBox.Name = "MaskWidthTextBox";
            this.MaskWidthTextBox.Size = new System.Drawing.Size(100, 20);
            this.MaskWidthTextBox.TabIndex = 0;
            this.MaskWidthTextBox.Tag = "";
            // 
            // PreviewButton
            // 
            this.PreviewButton.Location = new System.Drawing.Point(435, 289);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(89, 37);
            this.PreviewButton.TabIndex = 17;
            this.PreviewButton.Text = "Preview";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // OperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 338);
            this.Controls.Add(this.PreviewButton);
            this.Controls.Add(this.MaskGroupBox);
            this.Controls.Add(this.RadioButton2D);
            this.Controls.Add(this.RadioButton1D);
            this.Controls.Add(this.Slider);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AfterPictureBox);
            this.Controls.Add(this.BeforePictureBox);
            this.Name = "OperationsForm";
            this.Text = "OperationsForm";
            ((System.ComponentModel.ISupportInitialize)(this.BeforePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).EndInit();
            this.MaskGroupBox.ResumeLayout(false);
            this.MaskGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox BeforePictureBox;
        private System.Windows.Forms.PictureBox AfterPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.TrackBar Slider;
        private System.Windows.Forms.RadioButton RadioButton1D;
        private System.Windows.Forms.RadioButton RadioButton2D;
        private System.Windows.Forms.GroupBox MaskGroupBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OriginYTextBox;
        private System.Windows.Forms.TextBox OriginXTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox MaskHeightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MaskWidthTextBox;
        private System.Windows.Forms.Button PreviewButton;
    }
}