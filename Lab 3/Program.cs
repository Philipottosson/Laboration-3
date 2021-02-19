using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace Lab_3
{
    class Program
    {
        public static string imagePath;
        private static byte[] pngSign = { 137, 80, 78, 71};
        private static byte[] bmpSign = { 66, 77 };
        //private static byte[] hm = { 0, 0, 14, 197 };
      
        static void Main(string[] args)
        {
            if (args.Length != 0)
            {
                imagePath = args[0];
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine("File did not exist: \"{0}\"", Directory.GetCurrentDirectory()+"\\" + imagePath); //D:\Skola\Laboration\Lab 3\Test_400x200.bmp
                    return;
                }
                Console.WriteLine("File found");
            }
            else
            {
                Console.WriteLine("Enter your image with the the path");
                imagePath = Console.ReadLine();
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine("File did not exist: \"{0}\"", imagePath);
                    return;
                }
                Console.WriteLine("File found");
            }
            //4byte -> 5raden börjar 400x200

            FileStream fs = new FileStream(imagePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] _byte;
            using (fs)
            {
                _byte = new byte[fs.Length];
                fs.Read(_byte, 0, (int)fs.Length);

            }
            if (bmpSign.SequenceEqual(_byte.Take(bmpSign.Length)))
            {
                var Width = resolutionBMP(_byte, 21, 18);
                var Hight = resolutionBMP(_byte, 25, 22);
                int WidthValue = Convert.ToInt32(Width, 16);
                int HightValue = Convert.ToInt32(Hight, 16);
                Console.WriteLine("It's a BMP with the Resolution: {0}x{1}",
                   WidthValue , HightValue);
            }
            else if (pngSign.SequenceEqual(_byte.Take(pngSign.Length)))
            {
                var Width = resolutionPNG(_byte, 19, 16);
                var Hight = resolutionPNG(_byte, 23, 20);

                int WidthValue = Convert.ToInt32(Width, 16);
                int HightValue = Convert.ToInt32(Hight, 16);

                Console.WriteLine("It's a png with the Resolution: {0}x{1}", 
                    WidthValue, HightValue);
            }
            else
            {
                Console.WriteLine("The File is not PNG or BMP");
            }



            //pictureBox.Image = Image.FromFile(imagePath);;
        }
        public static string resolutionBMP(byte[] bytes, int end, int start)
        {
            string result = "";
            int counter = 0;
            string[] list = new string[(end + 1) - start];
            for (int i = start; i <= end; i++)
            {
                list[counter] = bytes[i].ToString("X");
                counter++;
            }
            for (int i = list.Length - 1; i >= 0; i--)
            {
                if (list[i].Length == 1)
                {
                    result += "0" + list[i];

                }
                else
                {
                    result += list[i];
                }
            }
            return result;
        }
        public static string resolutionPNG(byte[] bytes, int end, int start)
        {
            string result = "";
            int counter = 3;
            string[] list = new string[(end + 1) - start];
            for (int i = start; i <= end; i++)
            {
                list[counter] = bytes[i].ToString("X");
                counter--;
            }
            for (int i = 0; i <= list.Length-1; i++)
            {
                if (list[i].Length == 1)
                {
                    result ="0" + list[i] + result;

                }
                else
                {
                    result += list[i];
                }
            }
            return result;
        }
    }
}
