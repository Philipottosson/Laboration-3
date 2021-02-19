using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_2
{
    class Cuboid : Shape3D
    {
        private Vector3 center = new Vector3();
        private Vector3 size;
        private Boolean IsCube;
        public Cuboid(Vector3 center, Vector3 size)
        {
            this.center = center;
            this.size = new Vector3(size.X, size.Y, size.Z);
            if (size.Z == size.Y && size.X == size.Y)
            {
                IsCube = true;
            }
            else IsCube = false;
        }
        public Cuboid(Vector3 center, float size)
        {
            this.center = center;
            this.size = new Vector3(size, size, size);
            IsCube = true;
        }

        public override Vector3 Center 
        {
            get 
            {
                return center;
            }
        }

        public override float Area => ((size.X * size.Y) * 2 + (size.Z * size.X) * 2 + (size.Y * size.Z) * 2);

        public override float GetVolume => size.X * size.Y * size.Z;

        public override String ToString()
        {
            if (IsCube)
            {
                Console.WriteLine("cube @({0},{1},{2}): w = {3}, h = {4}, l = {5}",center.X,center.Y,center.Z,size.X,size.Y,size.Z);
            }
            else Console.WriteLine("cuboid @({0},{1},{2}): w = {3}, h = {4}, l = {5}", center.X, center.Y, center.Z, size.X, size.Y, size.Z);
            return "";
        }
    }
}
