using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTask1
{
    //Add operations here
    public enum Operations
    {
        Brighthness ,
        MeanFilter ,
        SobalFilter,
        Contrast,
        Gamma,
    }
    public partial class OperationsForm : Form
    {
        Image After, Before; MDIForm form;
        Operations Op;
        public OperationsForm( MDIForm f, Operations op)
        {
            InitializeComponent();
            Op = op;
            form =  f;                     
            decimal x = Math.Round((Decimal)AfterPictureBox.Width / f.img.Width, 2, MidpointRounding.AwayFromZero);
            decimal y = Math.Round((Decimal)AfterPictureBox.Height / f.img.Height, 2, MidpointRounding.AwayFromZero);
            After = ImageOperation.TransformImage(f.img, 0, 0, 0,(float)x ,(float)y );
            Before = ImageOperation.TransformImage(f.img, 0, 0, 0, (float)x, (float)y);
            this.BeforePictureBox.Image = Before.bitmap;
            this.AfterPictureBox.Image = After.bitmap;
            
            if (Op == Operations.Contrast)
            { 
                Slider.Maximum = 50; Slider.Minimum = -50;
                this.Text = "Contrast"; 
                this.MaskGroupBox.Visible = false;
                ApplyButton.Visible = false;
                RadioButton1D.Visible = false;
                RadioButton2D.Visible = false;
            }
            else if(Op==Operations.Brighthness)
            {
                this.Text = "Brighthness";
                MaskGroupBox.Visible = false;
                RadioButton1D.Visible = false;
                RadioButton2D.Visible = false;
                ApplyButton.Visible = false;
                RadioButton1D.Visible = false;
                RadioButton2D.Visible = false;
            }
            else if(Op==Operations.MeanFilter)
            {
                this.Text = "Mean Filter";
                Slider.Visible = false;
            }
        }

        private void Slider_Scroll(object sender, EventArgs e)
        {
            if (Op == Operations.Contrast)
                After = ImageOperation.Contrast(Before, Slider.Value);
            else
                After = ImageOperation.Brightness(Before, Slider.Value);
            this.AfterPictureBox.Image = After.bitmap;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if(Op==Operations.MeanFilter)
            {
                int width = int.Parse(MaskWidthTextBox.Text);
                int height = int.Parse(MaskHeightTextBox.Text);
                int originx = int.Parse(OriginXTextbox.Text);
                int originy = int.Parse(OriginYTextBox.Text);
                if (RadioButton1D.Checked == true)
                {
                    double[] values = new double[width];
                    for (int i = 0; i < width; ++i)
                        values[i] = (double)1 / width;
                    After = ImageOperation.LinearFilter1d(Before, values, originx, originy, ImageOperation.PostProcessing.NO);
                }
                else if (RadioButton2D.Checked == true)
                {
                    //add 2d filer here
                }

            }
            this.AfterPictureBox.Image = After.bitmap;
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            if (Op == Operations.Contrast)
                form.img = ImageOperation.Contrast(form.img, Slider.Value);
            else if (Op == Operations.Brighthness)
                form.img = ImageOperation.Brightness(form.img, Slider.Value);
            else if (Op == Operations.MeanFilter)
            {
                int width = int.Parse(MaskWidthTextBox.Text);
                int height = int.Parse(MaskHeightTextBox.Text);
                int originx = int.Parse(OriginXTextbox.Text);
                int originy = int.Parse(OriginYTextBox.Text);

                if (RadioButton1D.Checked == true)
                {
                    double[] values = new double[width];
                    for (int i = 0; i < width; ++i)
                        values[i] = (double)1 / width;
                    form.img = ImageOperation.LinearFilter1d(form.img, values, originx, originy, ImageOperation.PostProcessing.NO);
                }
                else if (RadioButton2D.Checked == true)
                {
                    //add 2d filter here
                }
            }
            PictureBox pic = form.Controls["MDIPicture"] as PictureBox;
            pic.Image = form.img.bitmap;
            this.Close();
        }
    }
}
