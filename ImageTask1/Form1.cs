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
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageTask1
{
    public partial class Form1 : Form
    {
        private Image tmp;
        private Image img;
        private Image img2;
        private MaskMatrix Mask;
        private MaskMatrix Mask2;
        private Image edged;
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
                string path = dialog.FileName;

                img = ImageLoader.LoadImage(path);

                tmp = img;
                if (img != null)
                {
                    pictureBox1.Image = img.bitmap;
                    //Generate Histogram
                    generateHistogram(img, chart1);
                    generateHistogram(tmp,chart2);
                    //img.UpdateHistogram += generateHistogram;
                }
                else
                {
                    throw new IOException("Cannot load the image");
                }
            }
        }

        private void generateHistogram(Image image, Chart chart)
        {
            if (image == null)
                return;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 255;
            chart.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            bool inten_flag, red_flag, green_flag, blue_flag;
            inten_flag = IntensityFlag.Checked;
            red_flag = RedFlag.Checked;
            green_flag = GreenFlag.Checked;
            blue_flag = BlueFlag.Checked;

            uint[] Intensity = new uint[256];
            uint[] Red = new uint[256];
            uint[] Green = new uint[256];
            uint[] Blue = new uint[256];
            for (uint i = 0; i < image.Height; i++)
            {
                for (uint j = 0; j < image.Width; j++)
                {
                    Pixel p = image.getPixel(j, i);
                    Red[p.R]++;
                    Blue[p.B]++;
                    Green[p.G]++;
                    Intensity[(int) ((p.R + p.G + p.B)/3)]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                if(red_flag)
                    chart.Series["Red"].Points.AddXY(i, Red[i]);
                else
                    chart.Series["Red"].Points.Clear();
                
                if(green_flag)
                    chart.Series["Green"].Points.AddXY(i, Green[i]);
                else
                    chart.Series["Green"].Points.Clear();

                if(blue_flag)
                    chart.Series["Blue"].Points.AddXY(i, Blue[i]);
                else
                    chart.Series["Blue"].Points.Clear();

                if(inten_flag)
                    chart.Series["Intensity"].Points.AddXY(i, Intensity[i]);
                else
                    chart.Series["Intensity"].Points.Clear();
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
            tmp = ImageOperation.TransformImage(tmp, (int)rotation.Value, (float)shearX.Value, (float)shearY.Value, (float)scaleX.Value, (float)scaleY.Value);
            pictureBox1.Image = tmp.bitmap;
        }

        private void GrayScale_Click(object sender, EventArgs e)
        {
            tmp = img.Clone();
            tmp = ImageOperation.GrayScale(tmp);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(img, chart1);
            generateHistogram(tmp, chart2);
        }

        private void Brightness_Click(object sender, EventArgs e)
        {
            tmp = img.Clone();
            tmp = ImageOperation.Brightness(tmp , Convert.ToInt32(BrightnessSlider.Value));
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(img, chart1);
            generateHistogram(tmp, chart2);
        }

        private void IntensityFlag_CheckedChanged(object sender, EventArgs e)
        {
            generateHistogram(img, chart1);
            generateHistogram(tmp, chart2);
        }

        private void RedFlag_CheckedChanged(object sender, EventArgs e)
        {
            generateHistogram(img, chart1);
            generateHistogram(tmp, chart2);
        }

        private void GreenFlag_CheckedChanged(object sender, EventArgs e)
        {
            generateHistogram(img, chart1);
            generateHistogram(tmp, chart2);
        }

        private void BlueFlag_CheckedChanged(object sender, EventArgs e)
        {
            generateHistogram(img, chart1);
            generateHistogram(tmp, chart2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tmp = ImageOperation.Invert(img);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp,chart2);
        }

        private void openImage2ToolStripMenuItem_Click(object sender, EventArgs e)
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

                img2 = ImageLoader.LoadImage(path);

                if (img2 != null)
                {
                    pictureBox3.Image = img2.bitmap;
                    //Generate Histogram
                    //img.UpdateHistogram += generateHistogram;
                }
                else
                {
                    throw new IOException("Cannot load the image");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (img == null || img2 == null)
                return;
            tmp = ImageOperation.Add(img, img2,(double)numericUpDown1.Value);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp,chart2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (img == null || img2 == null)
                return;
            tmp = ImageOperation.Subtract(img, img2);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            Image r, g, b;
            ImageOperation.BitSlice(img, (int) numericUpDown2.Value, out r, out g, out b);
            TabRed.Image = r.bitmap;
            TabGreen.Image = g.bitmap;
            TabBlue.Image = b.bitmap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            tmp = ImageOperation.Quantize(tmp, (int) numericUpDown3.Value);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp,chart2);
        }

        private void Gamma_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            tmp = ImageOperation.GammaCorrection(tmp, Convert.ToDouble(GammaValue.Text));
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void LinearFilter_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            double[,] values = Mask.GetMask();
            Point origin = Mask.GetOrigin();
            tmp = ImageOperation.LinearFilter(img, values, origin.X, origin.Y, ImageOperation.PostProcessing.NORMALIZATION);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void Gaussian1_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            double[,] values = ImageOperation.CreateGaussianFilter1((int)MaskSize1.Value ,(double)SegmaValue1.Value);
            tmp = ImageOperation.LinearFilter(tmp, values, (int)MaskSize1.Value / 2, (int)MaskSize1.Value/2, ImageOperation.PostProcessing.NO);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);

        }

        private void Gaussian2_Click(object sender, EventArgs e)
        {

            if (img == null)
                return;
            tmp = img.Clone();
            int size;
            double[,] values = ImageOperation.CreateGaussianFilter2((double)SegmaValue2.Value,out size);
            tmp = ImageOperation.LinearFilter(tmp, values, size / 2, size / 2, ImageOperation.PostProcessing.NO);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MainForm f = new MainForm();
            this.Hide();
            //f.ShowDialog();
            this.Show();
        }

        private void LinearFilter1DButton_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            double[] values = new double[5];
            for (int i = 0; i < 5; ++i)
                values[i] = (double)1 / 5;
                tmp = ImageOperation.LinearFilter1d(tmp, values, ImageOperation.PostProcessing.NO);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void SetMask_Click(object sender, EventArgs e)
        {
            Mask = new MaskMatrix();
            Mask.Show();
        }

        private void SetMask2_Click(object sender, EventArgs e)
        {
            Mask2 = new MaskMatrix();
            Mask2.Show();
        }

        private void Laplacian_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            double[,] values = Mask.GetMask();
            Point origin = Mask.GetOrigin();
            if (Mask.IsOne() == false)
            {
                MessageBox.Show("The Summition of Mask is not equal 1 ","Opps",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            tmp = ImageOperation.LinearFilter(tmp, values, origin.X, origin.Y, ImageOperation.PostProcessing.CUTOFF);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void SobelHorizontal_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            double[,] values = Mask.GetMask();
            Point origin = Mask.GetOrigin();
            if (Mask.IsZero() == false)
            {
                MessageBox.Show("The Summition of Mask is not equal 1 ", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tmp = ImageOperation.LinearFilter(img, values, origin.X, origin.Y, ImageOperation.PostProcessing.CUTOFF);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void SobelVertical_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            double[,] values = Mask.GetMask();
            Point origin = Mask.GetOrigin();
            if (Mask.IsZero() == false)
            {
                MessageBox.Show("The Summition of Mask is not equal 1 ", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tmp = ImageOperation.LinearFilter(img, values, origin.X, origin.Y, ImageOperation.PostProcessing.CUTOFF);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }

        private void SobelMagnitude_Click(object sender, EventArgs e)
        {
            if (img == null)
                return;
            tmp = img.Clone();
            img2 = img.Clone();
            edged = img.Clone();
            double[,] values1 = Mask.GetMask();
            double[,] values2 = Mask2.GetMask();
            Point origin1 = Mask.GetOrigin();
            Point origin2 = Mask2.GetOrigin();
            if (Mask.IsZero() == false)
            {
                MessageBox.Show("The Summition of Mask 1 is not equal 0", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            tmp = ImageOperation.LinearFilter(img, values1, origin1.X, origin1.Y, ImageOperation.PostProcessing.ABSOLUTE);
            if (Mask2.IsZero() == false)
            {
                MessageBox.Show("The Summition of Mask 2 is not equal 0", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            img2 = ImageOperation.LinearFilter(img, values2, origin2.X, origin2.Y, ImageOperation.PostProcessing.ABSOLUTE);
 
            edged = ImageOperation.SobelEdgeMagnitude(tmp, img2,ImageOperation.PostProcessing.CUTOFF);
            pictureBox2.Image = edged.bitmap;
            generateHistogram(edged, chart2);
        }

        private void Contrast_Click(object sender, EventArgs e)
        {
            tmp = img.Clone();
            tmp = ImageOperation.Contrast(img, ContrastSlider.Value);
            pictureBox2.Image = tmp.bitmap;
            generateHistogram(tmp, chart2);
        }
        
    }
}
