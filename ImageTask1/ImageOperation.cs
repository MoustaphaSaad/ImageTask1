using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ImageTask1
{
    class ImageOperation
    {


        public static Image TransformImage(Image img, float theta,float shearx, float sheary, float scalex, float scaley)
        {
            var rd_theta =(float)( theta * Math.PI / 180.0);
            float cos_theta = (float)Math.Cos(rd_theta);
            float sin_theta = (float)Math.Sin(rd_theta);

            Matrix sizeMat = new Matrix();
            sizeMat.Scale(scalex, scaley);
            sizeMat.Rotate(theta);
            sizeMat.Shear(shearx, sheary);

            Point[] cornerPoints = new Point[4]
            {
                new Point(0,0), 
                new Point((int)img.Width,0), 
                new Point(0,(int)img.Height), 
                new Point((int)img.Width,(int)img.Height)
            };

            sizeMat.TransformPoints(cornerPoints);

            var minX = Math.Min(cornerPoints[0].X,
                Math.Min(cornerPoints[1].X, Math.Min(cornerPoints[2].X, cornerPoints[3].X)));
            var maxX = Math.Max(cornerPoints[0].X,
                Math.Max(cornerPoints[1].X, Math.Max(cornerPoints[2].X, cornerPoints[3].X)));
            var minY = Math.Min(cornerPoints[0].Y,
                Math.Min(cornerPoints[1].Y, Math.Min(cornerPoints[2].Y, cornerPoints[3].Y)));
            var maxY = Math.Max(cornerPoints[0].Y,
                Math.Max(cornerPoints[1].Y, Math.Max(cornerPoints[2].Y, cornerPoints[3].Y)));

            //float fnew_width = Math.Abs(sin_theta) * img.Height + Math.Abs(cos_theta) * img.Width;
            //float fnew_height = Math.Abs(sin_theta) * img.Width + Math.Abs(cos_theta) * img.Height;

            float fnew_width = maxX-minX;
            float fnew_height = maxY-minY;

            Matrix mat = new Matrix();
            mat.Translate(fnew_width/2,fnew_height/2);
            mat.Scale(scalex, scaley);
            
            mat.Rotate(theta);
            mat.Shear(shearx, sheary);

            Image result = new Image((uint)fnew_width, (uint)fnew_height, img.Components);


            mat.Translate(-img.Width/2,-img.Height/2);
            float ih = img.Height;

            mat.Invert();
            
            
            PointF[] op_point = new PointF[1];

            for (uint y = 0; y < result.Height; y++)
            {
                for (uint x = 0; x < result.Width; x++)
                {
                    op_point[0] = new PointF((int)x,(int)y);
                    mat.TransformPoints(op_point);
                    float p_x = op_point[0].X;
                    float p_y = op_point[0].Y;
                    int absX = (int) op_point[0].X;
                    int absY = (int) op_point[0].Y;
                    if (p_x < img.Width-1 && p_y < img.Height-1 && p_x >= 0 && p_y >= 0)
                    {
                        int X1 = absX;
                        int X2 = X1 + 1;
                        int Y1 = absY;
                        int Y2 = Y1 + 1;

                        Pixel P1 = img.getPixel((uint)X1, (uint)Y1);
                        Pixel P2 = img.getPixel((uint)X2, (uint)Y1);
                        Pixel P3 = img.getPixel((uint)X1, (uint)Y2);
                        Pixel P4 = img.getPixel((uint)X2, (uint)Y2);

                        float x_frac = p_x - (float)X1;
                        float y_frac = p_y - (float)Y1;

                        float Z1R = (float) (P1.R) * (1f - x_frac) + P2.R * x_frac;
                        float Z1G = (float) (P1.G) * (1f - x_frac) + P2.G * x_frac;
                        float Z1B = (float) (P1.B) * (1f - x_frac) + P2.B * x_frac;

                        float Z2R = (float)(P3.R) * (1f - x_frac) + P4.R * x_frac;
                        float Z2G = (float)(P3.G) * (1f - x_frac) + P4.G * x_frac;
                        float Z2B = (float)(P3.B) * (1f - x_frac) + P4.B * x_frac;

                        
                        int R = (int)(Z1R*(1f - y_frac) + Z2R*y_frac);
                        int G = (int)(Z1G * (1f - y_frac) + Z2G * y_frac);
                        int B = (int)(Z1B * (1f - y_frac) + Z2B * y_frac);

                        Color c = Color.FromArgb(R, G, B);
                        result.setPixel(x, y, new Pixel(c.R,c.G,c.B,255));
                    }
                }
            }
            
            return result;
        }
        public static Image GreyScale(Image img)
        {
            Image result = new Image(img.Width , img.Height,img.Components);
            for (uint i = 0; i < img.Height; ++i)
            {
                for (uint j = 0; j < img.Width; ++j)
                {
                    Pixel p = img.getPixel(j, i);
                    byte grayscale =(byte) ((p.R + p.G + p.B) / 3);
                    p.R = grayscale;
                    p.G = grayscale;
                    p.B = grayscale;
                    result.setPixel(j, i, p);
                }
            }
                return result;
        }
        private static int BrightnessBound(int value)
        {
            if (value > 255)
                return 255;
            else if (value < 0)
                return 0;
            return value;
        }
        public static Image Brightness(Image img , int value)
        {
            Image result = new Image(img.Width, img.Height, img.Components);
            for (uint i = 0; i < img.Height; ++i)
            {
                for (uint j = 0; j < img.Width; ++j)
                {
                    Pixel p = img.getPixel(j, i);   
                    p.R = (byte)BrightnessBound((int)p.R + value);
                    p.G = (byte)BrightnessBound((int)p.G + value);
                    p.B = (byte)BrightnessBound((int)p.B + value);
                    result.setPixel(j, i, p);
                }
            }
            return result;
        }
    }
}
