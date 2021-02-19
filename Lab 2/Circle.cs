using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_2
{
    class Circle : Shape2D
    {
        public const double PI = 3.1415926535897931;
        private Vector2 center;
        private float radius;
        
        public Circle(Vector2 center, float radius)
        {
            this.center = new Vector2(center.X *1.0f, center.Y * 1.0f);
            this.radius = radius;
        }
        public override float Circumference 
        {
            get { return (float)((PI *2)* radius); }
        }
        public override float Area
        {
            get
            {
                return (float)(PI *(radius * 2));
            }
        }
         
        public override Vector3 Center => throw new NotImplementedException();

        public override string ToString()
        {
            Console.WriteLine("circle @({0}, {1}): r = {2}", center.X, center.Y, radius);
            return "";
        }
    }
}
