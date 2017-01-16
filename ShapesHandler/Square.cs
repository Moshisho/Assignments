using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesHandler
{
    public class Square : Rectangle
    {
        public Square(double height) : base(height, height)
        {
        }
    }
}
