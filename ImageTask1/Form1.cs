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
            tmp = ImageOperation.GreyScale(tmp);
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

        private void newFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm f = new MainForm();
            this.Hide();           //Hide the main form before showing the secondary
            f.ShowDialog();     //Show secondary form, code execution stop until frm2 is closed
            this.Show();
        }

    }
}
