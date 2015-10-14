using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTask1
{
    class Image
    {

        private byte[] m_buffer;
        private uint m_width, m_height;

        private bool m_needFlush;

        private uint m_components;

        private Bitmap m_bitmap;

        public uint Width
        {
            get { return m_width; }
        }

        public uint Height
        {
            get{return m_height;}
        }

        public byte[] Buffer
        {
            get { return m_buffer; }
        }

        public byte this[uint key]
        {
            get { return m_buffer[key]; }
            set { 
                m_buffer[key] = value;
                m_needFlush = true;
            }
        }

        public uint Components
        {
            get { return m_components; }
        }

        public Bitmap bitmap
        {
            get
            {
                if (m_needFlush)
                    flush();
                return m_bitmap;
            }
        }

        public Image(byte[] bytes, uint width, uint height, uint components)
        {
            m_buffer = bytes;
            m_width = width;
            m_height = height;
            //create bitmap
            m_bitmap = new Bitmap((int)m_width, (int)m_height);
            m_needFlush = true;
            m_components = components;
        }

        public Image(uint width, uint height, uint components)
        {
            m_bitmap = new Bitmap((int)width,(int)height,PixelFormat.Format24bppRgb);
            m_width = width;
            m_height = height;
            m_buffer = new byte[width*height*components];
            m_needFlush = true;
            m_components = components;
        }

        public Image(Bitmap bmp)
        {
            //load code
            m_width = (uint)bmp.Width;
            m_height = (uint)bmp.Height;
            m_needFlush = false;
            m_bitmap = bmp;

           if (bmp.PixelFormat == PixelFormat.Format24bppRgb)
           {
            m_components = 3;
           }
           else if (bmp.PixelFormat == PixelFormat.Format32bppArgb ||
              bmp.PixelFormat == PixelFormat.Format32bppRgb ||
              bmp.PixelFormat == PixelFormat.Format32bppPArgb)
           {
              m_components = 4;
           }
            //load bytes
            unsafe
            {
                if (m_width*m_components%4 == 0)
                {
                    BitmapData data = m_bitmap.LockBits(new Rectangle(0, 0, (int) m_width, (int) m_height),
                        ImageLockMode.ReadWrite, bmp.PixelFormat);


                    m_buffer = new byte[m_width*m_height*m_components];

                    Marshal.Copy(data.Scan0, m_buffer, 0, m_buffer.Length);
                    m_bitmap.UnlockBits(data);
                }
                else
                {
                    m_buffer = new byte[m_width*m_height*m_components];
                    for (int i = 0; i < m_bitmap.Height; i++)
                    {
                        for (int j = 0; j < m_bitmap.Width; j++)
                        {
                            Color p = m_bitmap.GetPixel(j, i);
                            Pixel np = new Pixel(p.B, p.G, p.R, p.A);
                            setPixel((uint)j,(uint)i,np);
                        }
                    }
                }
            }
        }

        public Pixel getPixel(uint x, uint y)
        {
            Pixel result = new Pixel();

            uint index = (y*m_width) + x;

            index *= m_components;


            result.R = m_buffer[index];
            result.G = m_buffer[index+1];
            result.B = m_buffer[index+2];

            if(m_components == 4)
                result.A = m_buffer[index+3];
            else
                result.A = 255;

            return result;
        }

        public void setPixel(uint x, uint y,Pixel p)
        {

            uint index = (y * m_width) + x;

            index *= m_components;

            m_buffer[index] = p.R;
            m_buffer[index+1] = p.G;
            m_buffer[index+2] = p.B;

            if (m_components == 4)
                m_buffer[index + 3] = p.A;

            m_needFlush = true;
        }

        public void flush()
        {
            //flush code
            unsafe
            {
                if (m_width*m_components%4 == 0)
                {
                    BitmapData data = m_bitmap.LockBits(new Rectangle(0, 0, (int) m_width, (int) m_height),
                        ImageLockMode.WriteOnly, m_bitmap.PixelFormat);
                    Marshal.Copy(m_buffer, 0, data.Scan0, m_buffer.Length);
                    m_bitmap.UnlockBits(data);
                }
                else
                {
                    Color c = new Color();
                    int r, g, b, a;
                    int index;
                    for (int x = 0; x < m_width; x++)
                    {
                        for (int y = 0; y < m_height; y++)
                        {
                            index = x + (int)(y*m_width);
                            index *= (int)m_components;
                            b = m_buffer[index];
                            g = m_buffer[index+1];
                            r = m_buffer[index + 2];
                            c = Color.FromArgb(r, g, b);

                            m_bitmap.SetPixel(x,y,c);
                        }
                    }
                }
            }
            m_needFlush = false;
        }

        public Image Clone()
        {
            Image res = new Image(Width, Height, Components);
            res.m_buffer = new byte[m_buffer.Length];
            for (uint i = 0; i < m_buffer.Length; i++)
                res.m_buffer[i] = m_buffer[i];
            res.m_bitmap = m_bitmap.Clone(new Rectangle(0,0,(int)Width,(int)Height),m_bitmap.PixelFormat);
            return res;
        }
    }
}

