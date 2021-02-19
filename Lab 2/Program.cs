using System;
using System.Numerics;

namespace Lab_2
{
    class Program
    {
        private static float circumference;
        private static float area;
        private static float volume;
        private static void Triangle(Triangle i)
        {
            circumference += i.Circumference;
        }
        private static void ShapeIs3D(Shape3D i)
        {
            if (i.GetVolume > volume)
            {
                volume = i.GetVolume;
            }
        }
        static void Main(string[] args)
        {
            
            Shape[] shape = Shape.GenerateShape();


            foreach (var i in shape)
            {
                if (i.GetType() == typeof(Triangle))
                {
                    Triangle((Triangle)i);
                }
                else if (i.GetType() == typeof(Sphere) || (i.GetType() == typeof(Cuboid)))
                {
                    ShapeIs3D((Shape3D)i);
                }
                i.ToString();
                area += i.Area;
            }
            area /= 20.0f;

            Console.WriteLine("\nThis is the average area for all the shapes: {0:0.0}", area);
            Console.WriteLine("This is the curcumference of all the triangles : {0:0.0}", circumference);
            Console.WriteLine("This is the highest volume of all the 3DShapes : {0:0.0}", volume);
            
        }

    }
}
