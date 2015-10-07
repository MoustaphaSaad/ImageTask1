using System;
using System.Collections.Generic;
using System.Drawing;
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

        private static Image loadPPM(string file)
        {
            Image result = null;
            uint width=0, height=0;
            FileStream fs = new FileStream(file,FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();

            if (line != "P3")
            {
                throw new IOException("corrupted PPM file");
            }

            bool d_flag = false;
            bool l_flag = false;
            uint ix = 0;
            while (sr.Peek() != -1)
            {
                line = sr.ReadLine();

                if (line[0] == '#')
                    continue;

                if (d_flag != true)
                {
                    var array = line.Split(' ');
                    width = uint.Parse(array[0]);
                    height = uint.Parse(array[1]);
                    d_flag = true;
                    result = new Image(width, height, 3);
                    continue;
                }

                if (l_flag != true)
                {
                    l_flag = true;
                    continue;
                }

                var arr = line.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length != 0)
                        result[ix++] = byte.Parse(arr[i]);
                }
            }
            sr.Close();
            fs.Close();

            return result;
        }

        public static Image LoadImage(string filePath)
        {
            string ext = deduceEXT(filePath);

            if (ext == "ppm")
            {
                //custom loader
                return loadPPM(filePath);
            }
            else
            {
                Bitmap bitmap = new Bitmap(filePath);
                return new Image(bitmap);
            }
        }
    }
}
