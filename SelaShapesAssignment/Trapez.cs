using ShapesHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SelaShapesAssignment
{
    public class Trapez : CartesianCoordinatesShape
    {
        public Trapez(double a, double b, double c) : base(new double[] { a, b, c })
        {

        }

        public override double Area
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
