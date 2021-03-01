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
            //Chcking if the user has any arguments
            if (args.Length != 0)
            {
                imagePath =  @"image\"+args[0];
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine("File did not exist: \"{0}\"", Directory.GetCurrentDirectory()+"\\" + imagePath); //D:\Skola\Laboration\Lab 3\Test_400x200.bmp
                    return;
                }
                Console.WriteLine("File found");
            }
            //if not, asking the user to enter the image file
            else
            {
                Console.WriteLine("Name of image: ");
                imagePath = @"image\" + Console.ReadLine();
                if (!File.Exists(imagePath))
                {
                    Console.WriteLine("File did not exist: \"{0}\"", imagePath);
                    return;
                }
                Console.WriteLine("File found");
            }
            
            
            FileStream fs = new FileStream(imagePath, FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            byte[] _byte;
            using (fs)
            {
                _byte = new byte[fs.Length];
                fs.Read(_byte, 0, (int)fs.Length);

            }
            //checking if it's a BMP, and if true make all the calculations. Ends with a Console.Writeline
            if (bmpSign.SequenceEqual(_byte.Take(bmpSign.Length)))
            {
                var Width = resolutionBMP(_byte, 21, 18);
                var Hight = resolutionBMP(_byte, 25, 22);
                int WidthValue = Convert.ToInt32(Width, 16);
                int HightValue = Convert.ToInt32(Hight, 16);
                Console.WriteLine("It's a BMP with the Resolution: {0}x{1}",
                   WidthValue , HightValue);
            }

            //checking if it's a PNG, and if true make all the calculations. Ends with a Console.Writeline
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
        }

        /*
         * Resolutionbmp takes in the bytes to read for the size, but in decimal numeral.
         * Changing it to hexadecimal and calculate it to decimal. And returning it as a string.
         */
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

        /*
         * ResolutionPNG takes in the bytes to read for the size, but in decimal numeral.
         * Changing it to hexadecimal and calculate it to decimal. And returning it as a string.
         */
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
