using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab_2
{
    public abstract class Shape2D : Shape
    {
        public abstract float Circumference{get;}

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
