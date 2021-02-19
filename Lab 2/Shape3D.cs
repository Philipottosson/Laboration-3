using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;


namespace Lab_2
{
    public abstract class Shape3D : Shape
    {
        public abstract float GetVolume { get; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
