using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTask1
{
    public partial class Form1 : Form
    {
        private Image tmp;
        private Image img;
        public Form1()
        {
            InitializeComponent();
            img = null;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Open Image";
            dialog.Multiselect = false;
            dialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF,*.PPM)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF;*.PPM|" +
                            "All files (.)|*.*";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string path = dialog.FileName;

                img = ImageLoader.LoadImage(path);

                tmp = img;
                if (img != null)
                {
                    /*
                    for (uint i = 0; i < img.Height; i++)
                    {
                        for (uint j = 0; j< img.Width; j++)
                        {
                            Pixel p = img.getPixel(j, i);
                            byte val = (byte)((p.R + p.G + p.B)/(3));
                            p.R = val;
                            p.G = val;
                            p.B = val;
                            img.setPixel(j,i,p);
                        }
                    }
                    */
                    
                    pictureBox1.Image = img.bitmap;
                }
                else
                {
                    throw new IOException("Cannot load the image");
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save Image";
            dialog.Filter = "PNG|*.png|BMP|*.bmp|JPG|*.png|P3|*.p3|P6|*.p6|Any File|*.*";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                ImageLoader.SaveImage(dialog.FileName,img);
            }
        }

        private void Apply_Click(object sender, EventArgs e)
        {
            tmp = img.Clone();
            tmp = ImageOperation.RotateImage(tmp, (int)rotation.Value, (float)shearX.Value, (float)shearY.Value, (float)scaleX.Value, (float)scaleY.Value);
            pictureBox1.Image = tmp.bitmap;
        }
    }
}
