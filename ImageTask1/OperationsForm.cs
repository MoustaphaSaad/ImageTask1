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
    public partial class OperationsForm : Form
    {
        Image After, Before; MDIForm form;
        public OperationsForm( MDIForm f, string operation = "")
        {
            InitializeComponent();
            form =  f;
            
            this.Text = operation;   
            decimal x = Math.Round((Decimal)AfterPictureBox.Width / f.img.Width, 2, MidpointRounding.AwayFromZero);
            decimal y = Math.Round((Decimal)AfterPictureBox.Height / f.img.Height, 2, MidpointRounding.AwayFromZero);
            After = ImageOperation.TransformImage(f.img, 0, 0, 0,(float)x ,(float)y );
            Before = ImageOperation.TransformImage(f.img, 0, 0, 0, (float)x, (float)y);
            this.BeforePictureBox.Image = Before.bitmap;
            this.AfterPictureBox.Image = After.bitmap;

            if (operation == "Contrast")
            { Slider.Maximum = 50; Slider.Minimum = -50; }
        }

        private void Slider_Scroll(object sender, EventArgs e)
        {
            if (this.Text == "Contrast")
                After = ImageOperation.Contrast(Before, Slider.Value);
            else
                After = ImageOperation.Brightness(Before, Slider.Value);
            this.AfterPictureBox.Image = After.bitmap;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (this.Text == "Contrast")
            form.img = ImageOperation.Contrast(form.img, Slider.Value);
            else
            form.img = ImageOperation.Brightness(form.img, Slider.Value);

            PictureBox pic= form.Controls["MDIPicture"] as PictureBox;
            pic.Image = form.img.bitmap;
            this.Close();
        }
    }
}
