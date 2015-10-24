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
        public static Image TransformImage(Image img, float theta, float shearx, float sheary, float scalex, float scaley)
        {
            var rd_theta = (float)(theta * Math.PI / 180.0);
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

            float fnew_width = maxX - minX;
            float fnew_height = maxY - minY;

            Matrix mat = new Matrix();
            mat.Translate(fnew_width / 2, fnew_height / 2);
            mat.Scale(scalex, scaley);

            mat.Rotate(theta);
            mat.Shear(shearx, sheary);

            Image result = new Image((uint)fnew_width, (uint)fnew_height, img.Components);


            mat.Translate(-img.Width / 2, -img.Height / 2);
            float ih = img.Height;

            mat.Invert();


            PointF[] op_point = new PointF[1];

            for (uint y = 0; y < result.Height; y++)
            {
                for (uint x = 0; x < result.Width; x++)
                {
                    op_point[0] = new PointF((int)x, (int)y);
                    mat.TransformPoints(op_point);
                    float p_x = op_point[0].X;
                    float p_y = op_point[0].Y;
                    int absX = (int)op_point[0].X;
                    int absY = (int)op_point[0].Y;
                    if (p_x < img.Width - 1 && p_y < img.Height - 1 && p_x >= 0 && p_y >= 0)
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

                        float Z1R = (float)(P1.R) * (1f - x_frac) + P2.R * x_frac;
                        float Z1G = (float)(P1.G) * (1f - x_frac) + P2.G * x_frac;
                        float Z1B = (float)(P1.B) * (1f - x_frac) + P2.B * x_frac;

                        float Z2R = (float)(P3.R) * (1f - x_frac) + P4.R * x_frac;
                        float Z2G = (float)(P3.G) * (1f - x_frac) + P4.G * x_frac;
                        float Z2B = (float)(P3.B) * (1f - x_frac) + P4.B * x_frac;


                        int R = (int)(Z1R * (1f - y_frac) + Z2R * y_frac);
                        int G = (int)(Z1G * (1f - y_frac) + Z2G * y_frac);
                        int B = (int)(Z1B * (1f - y_frac) + Z2B * y_frac);

                        Color c = Color.FromArgb(R, G, B);
                        result.setPixel(x, y, new Pixel(c.R, c.G, c.B, 255));
                    }
                }
            }

            return result;
        }
        public static Image GreyScale(Image img)
        {
            Image result = new Image(img.Width, img.Height, img.Components);
            for (uint i = 0; i < img.Height; ++i)
            {
                for (uint j = 0; j < img.Width; ++j)
                {
                    Pixel p = img.getPixel(j, i);
                    byte grayscale = (byte)((p.R + p.G + p.B) / 3);
                    p.R = grayscale;
                    p.G = grayscale;
                    p.B = grayscale;
                    result.setPixel(j, i, p);
                }
            }
            return result;
        }
        private static byte CheckBoundaries(int value)
        {
            if (value > 255)
                return 255;
            else if (value < 0)
                return 0;
            return (byte)value;
        }
        public static Image Brightness(Image img, int value)
        {
            Image result = new Image(img.Width, img.Height, img.Components);
            for (uint i = 0; i < img.Height; ++i)
            {
                for (uint j = 0; j < img.Width; ++j)
                {
                    Pixel p = img.getPixel(j, i);
                    p.R = CheckBoundaries((int)p.R + value);
                    p.G = CheckBoundaries((int)p.G + value);
                    p.B = CheckBoundaries((int)p.B + value);
                    result.setPixel(j, i, p);
                }
            }
            return result;
        }

        public static Image Invert(Image img)
        {
            for (uint i = 0; i < img.Height; i++)
            {
                for (uint j = 0; j < img.Width; j++)
                {
                    Pixel p = img.getPixel(j, i);
                    p.R = (byte)(255 - p.R);
                    p.G = (byte)(255 - p.G);
                    p.B = (byte)(255 - p.B);
                    img.setPixel(j, i, p);
                }
            }
            return img;
        }

        public static Image Add(Image img1, Image img2, double fraction)
        {
            uint s1 = img1.Height * img1.Width;
            uint s2 = img2.Height * img2.Width;

            if (s1 > s2)
            {
                //resize
                img2 = TransformImage(img2, 0, 0, 0, (float)img1.Width / (float)img2.Width,
                    (float)img1.Height / (float)img2.Height);
            }
            else if (s1 < s2)
            {
                //resize
                img1 = TransformImage(img1, 0, 0, 0, (float)img2.Width / (float)img1.Width,
                    (float)img2.Height / (float)img1.Height);
            }

            Image result = img1.Clone();

            for (uint i = 0; i < img1.Height; i++)
            {
                for (uint j = 0; j < img1.Width; j++)
                {
                    Pixel p1 = img1.getPixel(j, i);
                    Pixel p2 = img2.getPixel(j, i);

                    Pixel res = new Pixel();
                    res.R = (byte)(p1.R * fraction + p2.R * (1 - fraction));
                    res.G = (byte)(p1.G * fraction + p2.G * (1 - fraction));
                    res.B = (byte)(p1.B * fraction + p2.B * (1 - fraction));

                    result.setPixel(j, i, res);
                }
            }

            return result;
        }

        public static Image Subtract(Image img1, Image img2)
        {
            uint s1 = img1.Height * img1.Width;
            uint s2 = img2.Height * img2.Width;

            if (s1 > s2)
            {
                //resize
                img2 = TransformImage(img2, 0, 0, 0, (float)img1.Width / (float)img2.Width,
                    (float)img1.Height / (float)img2.Height);
            }
            else if (s1 < s2)
            {
                //resize
                img1 = TransformImage(img1, 0, 0, 0, (float)img2.Width / (float)img1.Width,
                    (float)img2.Height / (float)img1.Height);
            }

            Image result = img1.Clone();

            for (uint i = 0; i < img1.Height; i++)
            {
                for (uint j = 0; j < img1.Width; j++)
                {
                    Pixel p1 = img1.getPixel(j, i);
                    Pixel p2 = img2.getPixel(j, i);

                    double p1_r, p2_r, p1_g, p2_g, p1_b, p2_b;

                    p1_r = p1.R / 255.0f;
                    p1_g = p1.G / 255.0f;
                    p1_b = p1.B / 255.0f;

                    p2_r = p2.R / 255.0f;
                    p2_g = p2.G / 255.0f;
                    p2_b = p2.B / 255.0f;

                    double rr, rg, rb;

                    rr = p1_r - p2_r;
                    rg = p1_g - p2_g;
                    rb = p1_b - p2_b;

                    Pixel res = new Pixel();
                    res.R = (byte)(Math.Min(0, rr * 255));
                    res.G = (byte)(Math.Min(0, rg * 255));
                    res.B = (byte)(Math.Min(0, rb * 255));

                    result.setPixel(j, i, res);
                }
            }

            return result;
        }

        public static void BitSlice(Image img, int bit, out Image r, out Image g, out Image b)
        {
            r = new Image(img.Width, img.Height, img.Components);
            g = new Image(img.Width, img.Height, img.Components);
            b = new Image(img.Width, img.Height, img.Components);

            int mask = 1;
            mask <<= bit;

            for (uint i = 0; i < img.Height; i++)
            {
                for (uint j = 0; j < img.Width; j++)
                {
                    Pixel p = img.getPixel(j, i);

                    int resR = p.R & mask;
                    int resG = p.G & mask;
                    int resB = p.B & mask;

                    if (resR > 0)
                    {
                        r.setPixel(j, i, new Pixel(255, 255, 255, 255));
                    }
                    else
                    {
                        r.setPixel(j, i, new Pixel(0, 0, 0, 0));
                    }

                    if (resG > 0)
                    {
                        g.setPixel(j, i, new Pixel(255, 255, 255, 255));
                    }
                    else
                    {
                        g.setPixel(j, i, new Pixel(0, 0, 0, 0));
                    }

                    if (resB > 0)
                    {
                        b.setPixel(j, i, new Pixel(255, 255, 255, 255));
                    }
                    else
                    {
                        b.setPixel(j, i, new Pixel(0, 0, 0, 0));
                    }
                }
            }
        }

        public static Image Quantize(Image img, int bit)
        {
            bit = 8 - bit;
            int mask = int.MaxValue;
            for (int i = 0; i < bit; i++)
            {
                mask -= 1;
                mask <<= 1;
            }

            for (uint i = 0; i < img.Height; i++)
            {
                for (uint j = 0; j < img.Width; j++)
                {
                    Pixel p = img.getPixel(j, i);

                    int resR = p.R & mask;
                    int resG = p.G & mask;
                    int resB = p.B & mask;

                    Pixel res = new Pixel();
                    res.R = (byte)resR;
                    res.B = (byte)resB;
                    res.G = (byte)resG;

                    img.setPixel(j, i, res);
                }
            }
            return img;
        }

        public static Image Contrast(Image img, int val)
        {
            byte OldMaxR = 0, OldMaxB = 0, OldMaxG = 0, OldMinR = 255, OldMinG = 255, OldMinB = 255;
            byte NewMaxR, NewMaxB, NewMaxG, NewMinR, NewMinG, NewMinB;
            Image newimg = new Image(img.Width, img.Height, img.Components);
            Pixel P;
            #region GetMIN/MAX values of RGB
            for (uint i = 0; i < img.Width; ++i)
            {
                for (uint j = 0; j < img.Height; ++j)
                {
                    P = img.getPixel(i, j);
                    if (P.R > OldMaxR)
                        OldMaxR = P.R;
                    if (P.G > OldMaxG)
                        OldMaxG = P.G;
                    if (P.B > OldMaxB)
                        OldMaxB = P.B;

                    if (P.R < OldMinR)
                        OldMinR = P.R;
                    if (P.G < OldMinG)
                        OldMinG = P.G;
                    if (P.B < OldMinB)
                        OldMinB = P.B;
                }
            }
            byte x = 255;
            NewMaxR = OldMaxR + val > x ? x : (byte)(OldMaxR + val);
            NewMaxG = OldMaxG + val > x ? x : (byte)(OldMaxG + val);
            NewMaxB = OldMaxB + val > x ? x : (byte)(OldMaxB + val);
            NewMinR = OldMinR - val < 0 ? (byte)0 : (byte)(OldMinR - val);
            NewMinG = OldMinG - val < 0 ? (byte)0 : (byte)(OldMinG - val);
            NewMinB = OldMinB - val < 0 ? (byte)0 : (byte)(OldMinB - val);
            #endregion

            for (uint i = 0; i < img.Width; ++i)
            {
                for (uint j = 0; j < img.Height; ++j)
                {
                    P = img.getPixel(i, j);
                    double e = ((double)(P.R - OldMinR) / (OldMaxR - OldMinR));
                    P.R = CheckBoundaries((int)(((double)(P.R - OldMinR) / (OldMaxR - OldMinR)) * (NewMaxR - NewMinR) + NewMinR));
                    P.G = CheckBoundaries((int)(((double)(P.G - OldMinG) / (OldMaxG - OldMinG)) * (NewMaxG - NewMinG) + NewMinG));
                    P.B = CheckBoundaries((int)(((double)(P.B - OldMinB) / (OldMaxB - OldMinB)) * (NewMaxB - NewMinB) + NewMinB));
                    newimg.setPixel(i, j, P);
                }
            }

            return newimg;
        }

    }
}
