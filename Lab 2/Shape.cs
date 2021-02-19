using System;
using System.Numerics;

namespace Lab_2
{
    public abstract class Shape
    {

        public static Shape[] GenerateShape()
        {
            Shape[] _shape = new Shape[20];

            Random rand = new Random();
            for (int i = 0; i < _shape.Length; i++)
            {
                int almostValue = rand.Next(0,7);
                switch (almostValue) {

                    case 0: 
                        _shape[i] = new Circle(new Vector2(rand.Next(0, 100), rand.Next(0,100)),rand.Next(1, 50));
                        break;
                    case 1:
                        Vector2 midPosition = new Vector2(rand.Next(50, 75), rand.Next(0, 75));
                        Vector2 p1 = new Vector2(rand.Next(50, 100), rand.Next(0, 100));
                        Vector2 p2 = new Vector2(rand.Next(50, 100), rand.Next(0, 100));
                        while (p1 == p2)
                        {
                            p2 = new Vector2(rand.Next(50, 100), rand.Next(50, 100));
                        }
                        Vector2 p3 = new Vector2(3.0f * midPosition.X - p1.X - p2.X, 3.0f * midPosition.Y - p1.Y - p2.Y);
                        _shape[i] = new Triangle(p1,p2,p3);
                        break;
                    case 2:
                        _shape[i] = new Rectangle(new Vector2(rand.Next(1, 30), rand.Next(1, 30)), new Vector2(rand.Next(1, 30), rand.Next(1, 30)));
                        break;
                    case 3:
                        _shape[i] = new Rectangle(new Vector2(rand.Next(1, 30)), rand.Next(1, 30));
                        break;
                    case 4:
                        _shape[i] = new Cuboid(new Vector3(rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)), rand.Next(1, 50));
                        break;
                    case 5:
                        _shape[i] = new Cuboid(new Vector3(rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)),new Vector3(rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)));
                        break;
                    case 6:
                        _shape[i] = new Sphere(new Vector3(rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)), rand.Next(1, 50));
                        break;
                    default:
                        rand.Next(0, 7);
                        break;
                }
             }
            return _shape;
        }
        public static Shape[] GenerateShape(Vector3 midPosition)
        {
            Shape[] _shape = new Shape[20];
            int j;
            for (int i = 0; i < _shape.Length; i++)
            {
                Random rand = new Random();
                int almostValue = rand.Next(0, 7);
                switch (i)
                {

                    case 0:
                        _shape[i] = new Circle(new Vector2(midPosition.X, midPosition.Y), rand.Next(1, 50));
                        break;
                    case 1:
                        Vector2 p1 = new Vector2(rand.Next(1, 100), rand.Next(1, 100));
                        Vector2 p2 = new Vector2(rand.Next(1, 100), rand.Next(1, 100));
                        Vector2 p3 = new Vector2(3.0f * midPosition.X - p1.X - p2.X, 3.0f * midPosition.Y - p1.Y - p2.Y);
                        _shape[i] = new Triangle(p1, p2, p3);
                        break;
                    case 2:
                        _shape[i] = new Rectangle(new Vector2(midPosition.X, midPosition.Y), new Vector2(rand.Next(1, 30), rand.Next(1, 30)));
                        break;
                    case 3:
                        _shape[i] = new Rectangle(new Vector2(midPosition.X, midPosition.Y), rand.Next(1, 30));
                        break;
                    case 4:
                        _shape[i] = new Cuboid(midPosition, rand.Next(1, 50));
                        break;
                    case 5:
                        _shape[i] = new Cuboid(midPosition, new Vector3(rand.Next(1, 100), rand.Next(1, 100), rand.Next(1, 100)));
                        break;
                    case 6:
                        _shape[i] = new Sphere(midPosition, rand.Next(1, 50));
                        break;
                }
            }
            return _shape;
        }
        public abstract Vector3 Center { get;}
        public abstract float Area { get; }


        /*
         * 
         */

    }
}