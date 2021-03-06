﻿using System;
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
        public enum PostProcessing { NO, NORMALIZATION, CUTOFF, ABSOLUTE };

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
        public static Image GrayScale(Image img)
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
        private static int BrightnessBound(int value)
        {
            if (value > 255)
                return 255;
            else if (value < 0)
                return 0;
            return value;
        }
        public static Image Brightness(Image img, int value)
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

                    //double p1_r, p2_r, p1_g, p2_g, p1_b, p2_b;

                    /* p1_r = p1.R / 255.0f;
                     p1_g = p1.G / 255.0f;
                     p1_b = p1.B / 255.0f;

                     p2_r = p2.R / 255.0f;
                     p2_g = p2.G / 255.0f;
                     p2_b = p2.B / 255.0f;
                     */
                    double rr, rg, rb;

                    rr = (p1.R - p2.R + 255.0) / 510.0;
                    rg = (p1.G - p2.G + 255.0) / 510.0;
                    rb = (p1.B - p2.B + 255.0) / 510.0;

                    Pixel res = new Pixel();
                    res.R = (byte)(rr * 255.0);
                    res.G = (byte)(rg * 255.0);
                    res.B = (byte)(rb * 255.0);

                    result.setPixel(j, i, res);
                }
            }

            return result;
        }

        public static Image GammaCorrection(Image img, double gamma)
        {
            float c = 1;
            for (uint i = 0; i < img.Height; ++i)
            {
                for (uint j = 0; j < img.Width; ++j)
                {
                    Pixel p = img.getPixel(j, i);
                    p.R = (byte)((c * Math.Pow(p.R / 255.0, gamma)) * 255.0);
                    p.G = (byte)((c * Math.Pow(p.G / 255.0, gamma)) * 255.0);
                    p.B = (byte)((c * Math.Pow(p.B / 255.0, gamma)) * 255.0);
                    img.setPixel(j, i, p);
                }
            }
            return img;
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

        public static double Clamp(double min, double max, double val)
        {
            if (val < min)
                return min;
            else if (val > max)
                return max;
            else
                return val;
        }

        public static Image LinearFilter(Image img, double[,] values, int OriginX, int OriginY, PostProcessing op)
        {
            Image nimage = img.Clone();
            int top = values.GetLength(0) - OriginY;
            int down = values.GetLength(0) - top;
            int left = values.GetLength(1) - OriginX;
            int right = values.GetLength(1) - left;
            for (uint i = 0; i < img.Height; ++i)
            {
                for (uint j = 0; j < img.Width; ++j)
                {
                    uint nx = 0;
                    uint ny = 0;
                    double rr = 0;
                    double gg = 0;
                    double bb = 0;
                    for (int x = (int)(i - top); x < (int)(i + down); ++x, nx++)
                    {
                        for (int y = (int)(j - left); y < (int)(j + right); ++y, ny++)
                        {
                            Pixel p;
                            if (x < 0 || x >= img.Height || y < 0 || y >= img.Width)
                                p = new Pixel(0, 0, 0, 0);
                            else
                            {
                                p = img.getPixel((uint)y, (uint)x);
                            }
                            rr += p.R * values[nx, ny];
                            gg += p.G * values[nx, ny];
                            bb += p.B * values[nx, ny];
                        }
                        ny = 0;
                    }
                    Pixel np = new Pixel();
                    if (op == PostProcessing.NO)
                    {
                        np = new Pixel((byte)rr, (byte)gg, (byte)bb, 0);
                    }
                    else if (op == PostProcessing.ABSOLUTE)
                    {

                    }
                    else if (op == PostProcessing.CUTOFF)
                    {
                        rr = Clamp(0, 255, rr);
                        gg = Clamp(0, 255, gg);
                        bb = Clamp(0, 255, bb);
                        np = new Pixel((byte)rr, (byte)gg, (byte)bb, 0);
                    }
                    else if (op == PostProcessing.NORMALIZATION)
                    {
                        rr = rr / (/*values.GetLength(0) * values.GetLength(1) */ 255.0);
                        gg = gg / (/*values.GetLength(0) * values.GetLength(1) */ 255.0);
                        bb = bb / (/*values.GetLength(0) * values.GetLength(1) */ 255.0);
                        np = new Pixel((byte)(rr * 255), (byte)(gg * 255), (byte)(bb * 255), 0);
                    }
                    nimage.setPixel(j, i, np);
                }
            }

            return nimage;
        }
        public static Image LinearFilter1d(Image img, double[] values, PostProcessing op)
        {
            Image rowimg = new Image(img.Width,img.Height,img.Components);
            Image finalimg = new Image(img.Width, img.Height, img.Components);
            int mid = values.GetLength(0) / 2;
            byte accR = 0, accG = 0, accB = 0;
            Pixel p = new Pixel();
            #region 1d mask go over rows
            for (uint j = 0; j < img.Height; ++j)
            {

                for (uint i = 0; i < img.Width; ++i)
                {
                    for (int k = (int)i - mid, maskind = 0; k < (mid + i); ++k, ++maskind)
                    {

                        if (k >= 0&&k<img.Width)
                        {
                            p = img.getPixel((uint)k, j);
                            accR += (byte)(p.R * values[maskind]);
                            accG += (byte)(p.G * values[maskind]);
                            accB += (byte)(p.B * values[maskind]);
                        }
                    }
                    p.R = accR;
                    p.G = accG;
                    p.B = accB;
                    rowimg.setPixel(i, j, p);
                    accR = 0; accG = 0; accB = 0;
                }
            }
            #endregion

            #region 1d mask go over columns
            for (uint i = 0; i < img.Width; ++i)
            {
                for (uint j = 0; j < img.Height; ++j)
                {
                    for (int k = (int)j - mid, maskind = 0; k < (mid + j); ++k, ++maskind)
                    {

                        if (k >= 0 && k < img.Height)
                        {
                            p = rowimg.getPixel(i, (uint)k);
                            accR += (byte)(p.R * values[maskind]);
                            accG += (byte)(p.G * values[maskind]);
                            accB += (byte)(p.B * values[maskind]);
                        }
                    }
                    p.R = accR;
                    p.G = accG;
                    p.B = accB;
                    finalimg.setPixel(i, j, p);
                    accR = 0; accG = 0; accB = 0;
                }
            }
            #endregion

            return finalimg;
        }
        public static double[,] CreateGaussianFilter1(int size, double sigma)
        {
            double[,] filter = new double[size, size];
            double sum = 0;
            int ni = -1 * size / 2;
            int nj = -1 * size / 2;
            for (int i = 0; i < size; ++i, ni++)
            {
                for (int j = 0; j < size; ++j, nj++)
                {
                    filter[i, j] = Math.Pow(Math.E, (-1 * ((ni * ni + nj * nj) / (2.0 * sigma * sigma))));
                    sum += filter[i, j];
                }
                nj = 0;
            }
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    filter[i, j] /= sum;
                }
            }

            return filter;
        }

        public static double[,] CreateGaussianFilter2(double sigma, out int nsize)
        {
            int n = (int)(3.7 * sigma - 0.5);
            int size = 2 * n + 1;
            nsize = size;
            double[,] filter = new double[size, size];
            double sum = 0;
            int ni = -1 * size / 2;
            int nj = -1 * size / 2;
            for (int i = 0; i < size; ++i, ni++)
            {
                for (int j = 0; j < size; ++j, nj++)
                {
                    filter[i, j] = (1.0 / (2 * Math.PI * sigma * sigma)) * Math.Pow(Math.E, (-1 * ((ni * ni + nj * nj) / (2.0 * sigma * sigma))));
                    sum += filter[i, j];
                }
                nj = 0;
            }
            return filter;
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
                    P.R = (byte)BrightnessBound((int)(((double)(P.R - OldMinR) / (OldMaxR - OldMinR)) * (NewMaxR - NewMinR) + NewMinR));
                    P.G = (byte)BrightnessBound((int)(((double)(P.G - OldMinG) / (OldMaxG - OldMinG)) * (NewMaxG - NewMinG) + NewMinG));
                    P.B = (byte)BrightnessBound((int)(((double)(P.B - OldMinB) / (OldMaxB - OldMinB)) * (NewMaxB - NewMinB) + NewMinB));
                    newimg.setPixel(i, j, P);
                }
            }
            return newimg;
        }
    }
}
