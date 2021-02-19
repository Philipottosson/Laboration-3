using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    class Sphere : Shape3D
    {
        public const double PI = 3.1415926535897931;
        private Vector3 center;
        private float radius;
        public Sphere(Vector3 center, float radius)
        {
            this.center = new Vector3(center.X,center.Y,center.Z);
            this.radius = radius;
        }
        public override Vector3 Center => center;

        public override float Area => (float)(4*PI *(radius*radius)); //4πr^2

        public override float GetVolume => (float)((4 / 3) * PI * (radius * radius * radius)); //(4/3) × π × r
        public override string ToString()
        {
            Console.WriteLine("sphere @({0}, {1}, {2}): r = {3}",center.X,center.Y,center.Z, radius);
            return "";
        }
    }
}
