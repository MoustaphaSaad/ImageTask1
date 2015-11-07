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
    public partial class MDIForm : Form
    {
        public Image img { get; set; }
        public MDIForm()
        { 
            InitializeComponent(); 
        }
        public MDIForm(ref Image Img,MainForm Parent)
        {
            InitializeComponent();
            img = Img.Clone();         
            //this.Dock = DockStyle.Fill;
            this.WindowState = FormWindowState.Maximized;
            MDIPicture.Width = (int)img.Width;
            MDIPicture.Height = (int)img.Height;
            Parent.IsMdiContainer = true;
            this.MdiParent = Parent;
            MDIPicture.Image = img.bitmap;
            this.Show();
        }
        public void UpdateIMG()
        {
            this.MDIPicture.Image = img.bitmap;
        }

    }
}
