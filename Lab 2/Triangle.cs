using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab_2
{
    class Triangle : Shape2D
    {
        private Vector2 point1;
        private Vector2 point2;
        private Vector2 point3;

        private Vector2 center;
        private float area;
        private float pointAToB;
        private float pointAToC;
        private float pointBToC;

        public Triangle()
        {
        }

        public Triangle(Vector2 p0, Vector2 p1, Vector2 p2)
        {
            point1 = new Vector2(p0.X, p0.Y);
            point2 = new Vector2(p1.X, p1.Y);
            point3 = new Vector2(p2.X, p2.Y); 

            CalcTriangle();
            center = new Vector2((point1.X + point2.X + point3.X) / 3.0f,(point1.Y + point2.Y + point3.Y) / 3.0f);
            // Heron's formula
            // area = 0.25 * √( (a->b + a->c + b->c) * (-a->b + a->c + b->c) * (a->b - a->c + b->c) * (a->b + a->c - b->c) )
            area = (float)Math.Sqrt((pointAToB + pointAToC + pointBToC) * (-pointAToB + pointAToC + pointBToC)
                * (pointAToB - pointAToC + pointBToC) * (pointAToB + pointAToC - pointBToC));
            area = (float)(area * 0.25);

        }
        /*
         *    
         */

        public override float Circumference => (pointAToB + pointAToC + pointBToC);

        public override Vector3 Center => new Vector3 (center.X,center.Y,0.0f);

        public override float Area => area;
        public override string ToString()
        {
            Console.WriteLine("Triangle @({0}, {1}): p1({2}, {3}), p2({4}, {5}), p3({6}, {7})",
                center.X, center.Y, point1.X, point1.Y, point2.X, point2.Y, point3.X, point3.Y);
            
            return "";
        }
        private void CalcTriangle()
        {

            pointAToB = (float)Math.Sqrt((point1.X - point2.X) * (point1.X - point2.X)
                + (point2.Y - point1.Y) * (point2.Y - point1.Y));

            pointAToC = (float)Math.Sqrt((point1.X - point3.X) * (point1.X - point3.X)
                + (point3.Y - point1.Y) * (point3.Y - point1.Y));

            pointBToC = (float)Math.Sqrt((point2.X - point3.X) * (point2.X - point3.X)
                + (point3.Y - point2.Y) * (point3.Y - point2.Y));

        }
    }
}
