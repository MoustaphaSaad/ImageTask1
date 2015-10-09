using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTask1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                string fileName = dialog.FileName;

                Image img = ImageLoader.LoadImage(fileName);

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
    }
}
