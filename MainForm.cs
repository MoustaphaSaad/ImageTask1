using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageTask1
{
    public partial class MainForm : Form
    {
        Image img;
        public MainForm()
        {
            InitializeComponent();
            this.MdiChildActivate += MainForm_MdiChildActivate;
        }

        void MainForm_MdiChildActivate(object sender, EventArgs e)
        {   
              IntensityFlag_CheckedChanged(sender, e);
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
                if (img != null)
                {
                    MDIForm f = new MDIForm(ref img, this);
                    
                }
            }
        }

        private void GrayScale_Click(object sender, EventArgs e)
        {
            MDIForm f = ((MDIForm)ActiveMdiChild);
            f.tmp = f.img.Clone();
            f.tmp = ImageOperation.GrayScale(f.tmp);
            f.UpdateTMP();
            generateHistogram(f.img, chart1);
            generateHistogram(f.tmp, chart2);
        }
        private void generateHistogram(Image image, Chart chart)
        {
            if (image == null)
                return;
            foreach (var series in chart.Series)
            {
                series.Points.Clear();
            }
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
                    Intensity[(int)((p.R + p.G + p.B) / 3)]++;
                }
            }

            for (int i = 0; i < 256; i++)
            {
                if (red_flag)
                    chart.Series["Red"].Points.AddXY(i, Red[i]);
                else
                    chart.Series["Red"].Points.Clear();

                if (green_flag)
                    chart.Series["Green"].Points.AddXY(i, Green[i]);
                else
                    chart.Series["Green"].Points.Clear();

                if (blue_flag)
                    chart.Series["Blue"].Points.AddXY(i, Blue[i]);
                else
                    chart.Series["Blue"].Points.Clear();

                if (inten_flag)
                    chart.Series["Intensity"].Points.AddXY(i, Intensity[i]);
                else
                    chart.Series["Intensity"].Points.Clear();
                
            }
            //chart.Update();
        }
        private void Brightness_Click(object sender, EventArgs e)
        {
            OperationsForm f = new OperationsForm((MDIForm)ActiveMdiChild);
            this.IsAccessible = false;
            f.ShowDialog();
            this.IsAccessible = true;
        }

        //IntensityFlag function is used to handle red, green, blue or intensity check box changing
        private void IntensityFlag_CheckedChanged(object sender, EventArgs e)
        {
            if (((MDIForm)ActiveMdiChild) != null)
            {
                generateHistogram(((MDIForm)ActiveMdiChild).img, chart1);
                generateHistogram(((MDIForm)ActiveMdiChild).img, chart2);
            }
        }

        private void contrastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationsForm f = new OperationsForm(((MDIForm)ActiveMdiChild), "Contrast");
            this.IsAccessible = false;
            f.ShowDialog();
            this.IsAccessible = true;
        }


    }
}
