using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageTask1
{
    class ImageLoader
    {

        private static string deduceEXT(string file)
        {
            var array = file.Split('.');
            if (array.Length > 1)
                return array[array.Length - 1];
            else
                return null;
        }

        public static Image load_PPM(string file)
        {
            Image result = null;
            BinaryReader rd = new BinaryReader(new FileStream(file,FileMode.Open));
            int count = 0;
            int width = 0, height = 0;
            string type = "";
            try
            {
                while (count < 4)
                {
                    char c = (char) rd.PeekChar();
                    if (c == '#')
                    {
                        while (rd.ReadChar() != '\n') ;
                    }
                    else if (Char.IsWhiteSpace(c))
                    {
                        rd.ReadChar();
                    }
                    else
                    {
                        if (count == 0)
                        {
                            type += rd.ReadChar().ToString() + rd.ReadChar().ToString();
                            count++;
                        }
                        else if (count == 1)
                        {
                            width = ReadInt(rd);
                            count++;
                        }
                        else if (count == 2)
                        {
                            height = ReadInt(rd);
                            count++;
                        }
                        else if (count == 3)
                        {
                            //this is always 255
                            ReadInt(rd);
                            count++;
                        }
                        else
                        {
                            throw new Exception("can't parse file");
                        }
                    }
                }

                PixelFormat p;
                int components;
                if (type == "P3")
                {
                    p = PixelFormat.Format24bppRgb;
                    components = 3;
                }
                else if (type == "P6")
                {
                    p = PixelFormat.Format24bppRgb;
                    components = 3;
                }
                else
                {
                    throw new Exception("Can't identify type");
                }

                result = new Image((uint) width, (uint) height, (uint) components);

                if (type == "P3")
                {
                    int chars = (int) (rd.BaseStream.Length - rd.BaseStream.Position);
                    char[] data = rd.ReadChars(chars);

                    string val = "";
                    uint index = 0;
                    for (int i = 0; i < data.Length; i++)
                    {
                        if (Char.IsWhiteSpace(data[i]))
                        {
                            if (val != "")
                            {
                                result[index] = (byte) int.Parse(val);
                                val = "";
                                index++;
                            }
                        }
                        else
                        {
                            val += data[i];
                        }
                    }
                }
                else
                {
                    int bytes = (int)(rd.BaseStream.Length - rd.BaseStream.Position);
                    byte[] data = rd.ReadBytes(bytes);
                    for (int i = 0; i < bytes; i++)
                        result[(uint)i] = data[i];
                }

                //it's Beeeeeeep BGR NOT RGB DAMN IT
                for (uint i = 0; i < result.Buffer.Length; i += 3)
                {
                    byte tmp = result[i];
                    result[i] = result[i + 2];
                    result[i + 2] = tmp;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                rd.Close();
            }

            result.flush();
            return result;
        }

        private static int ReadInt(BinaryReader rd)
        {
            string val = "";
            while (!Char.IsWhiteSpace((char)rd.PeekChar()))
            {
                val += rd.ReadChar().ToString();
            }
            rd.ReadByte();
            return int.Parse(val);
        }

        public static Image LoadImage(string filePath)
        {
            string ext = deduceEXT(filePath);

            if (ext.ToLower() == "ppm")
            {
                //custom loader
                //return loadPPM(filePath);
                return load_PPM(filePath);
            }
            else
            {
                Bitmap bitmap = new Bitmap(filePath);
                return new Image(bitmap);
            }
        }
    }
}
