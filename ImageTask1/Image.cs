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
            m_buffer = new byte[width*height*components];
            m_width = width;
            m_height = height;
            m_bitmap = new Bitmap((int)m_width, (int)m_height, PixelFormat.Format24bppRgb);
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

            //load bytes
            unsafe
            {
                BitmapData data = m_bitmap.LockBits(new Rectangle(0, 0, (int)m_width, (int)m_height), ImageLockMode.ReadWrite, bmp.PixelFormat);

                if (bmp.PixelFormat == PixelFormat.Format24bppRgb)
                {
                    m_components = 3;
                }
                else if (bmp.PixelFormat == PixelFormat.Format32bppArgb || bmp.PixelFormat == PixelFormat.Format32bppRgb || bmp.PixelFormat == PixelFormat.Format32bppPArgb)
                {
                    m_components = 4;
                }

                m_buffer = new byte[m_width*m_height*m_components];

                Marshal.Copy(data.Scan0,m_buffer,0,m_buffer.Length);
                m_bitmap.UnlockBits(data);
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

        private void flush()
        {
            //flush code
            unsafe
            {
                BitmapData data = m_bitmap.LockBits(new Rectangle(0, 0, (int)m_width, (int)m_height), ImageLockMode.ReadWrite, m_bitmap.PixelFormat);
                Marshal.Copy(m_buffer, 0, data.Scan0, m_buffer.Length);
                m_bitmap.UnlockBits(data);
            }
            m_needFlush = false;
        }
    }
}

