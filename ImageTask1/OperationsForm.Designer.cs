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
            ((System.ComponentModel.ISupportInitialize)(this.BeforePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AfterPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Slider)).BeginInit();
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
            this.ApplyButton.Location = new System.Drawing.Point(416, 267);
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
            this.Slider.SmallChange = 5;
            this.Slider.TabIndex = 13;
            this.Slider.Scroll += new System.EventHandler(this.Slider_Scroll);
            // 
            // OperationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 338);
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
    }
}