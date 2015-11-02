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
    public partial class MaskMatrix : Form
    {
        private int width;
        private int height;
        private double[,] grid;
        private TextBox[,] boxes;
        private Point boxLocation;
        private Point Origin;
        public MaskMatrix()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            if (WidthBox.Text == "" || HeightBox.Text == "")
            {
                MessageBox.Show("Please set the width and height !!", "Opps", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                width = Convert.ToInt32(WidthBox.Text);
                height = Convert.ToInt32(HeightBox.Text);
            }
            boxLocation = this.label1.Location;
            boxes = new TextBox[width, height];
            grid = new double[width, height];
            int a = boxLocation.X;
            int b = boxLocation.Y;

            for (int i = 0; i < width; ++i)
            {
                a = boxLocation.X;
                b += 30;
                for (int j = 0; j < height; ++j)
                {
                    boxes[i, j] = new TextBox();
                    string name ="A" + i.ToString() + j.ToString();
                    boxes[i, j].Name = name;
                    boxes[i, j].Width = 25;
                    boxes[i, j].Height = 25;
                    boxes[i, j].Location = new Point(a, b + 5);
                    a += 30;
                    this.Controls.Add(boxes[i, j]);
                }
            }
        }

        private void Fill_Click(object sender, EventArgs e)
        {
            Origin.X = Convert.ToInt32(OriginXBox.Text);
            Origin.Y = Convert.ToInt32(OriginYBox.Text);
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    grid[i, j] = Convert.ToDouble(boxes[i, j].Text);
                }
            }
            this.Hide();
        }
        public double[,] GetMask()
        {
            return grid;
        }
        public Point GetOrigin()
        {
            return Origin;
        }
        public bool IsOne()
        {
            double sum = 0;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    sum += grid[i, j];
                }
            }
            return (sum == 1);
        }
        public bool IsZero()
        {
            double sum = 0;
            for (int i = 0; i < width; ++i)
            {
                for (int j = 0; j < height; ++j)
                {
                    sum += grid[i, j];
                }
            }
            return (sum == 0);
        }
    }
}
