using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_2
{
    class Rectangle : Shape2D
    {
        private Vector2 center;
        private Vector2 size; //X == Wide, Y = Height
        private Boolean IsSquare;
        public Rectangle(Vector2 center, Vector2 size)
        {
            this.center = new Vector2(center.X, center.Y);
            this.size = new Vector2(center.X -(size.X / 2), center.Y - (size.Y / 2));
            
            checkSize();
        }
        public Rectangle(Vector2 center, float size)
        {
            this.center = new Vector2(center.X, center.Y);
            this.size = new Vector2(size, size);
            checkSize();
        }
        /// <summary>
        /// Will check if the shape is a Square or an Rectangle.
        /// </summary>
        public void checkSize()
        {
            IsSquare = (size.X == size.Y);
        }

        public override float Circumference => (size.X * 2 + size.Y * 2);

        public override Vector3 Center => new Vector3(center.X, center.Y, 0.0f);

        public override float Area => (size.X * size.Y);
        public override string ToString()
        {
            if (IsSquare)
            {
                Console.WriteLine("Square @({0}, {1}): w = {2}, h = {3}",center.X,center.Y,size.X,size.Y);
            }
            else Console.WriteLine("rectangle @({0}, {1}): w = {2}, h = {3}", center.X, center.Y, size.X, size.Y);
            
            return "";
        }
    }
}