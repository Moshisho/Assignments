using System;

namespace ShapesHandler
{
    public class Rectangle : CartesianCoordinatesShape
    {
        private readonly double area;

        public Rectangle(double height, double width) : base(height, width)
        {
            area = CalculateArea(height, width);
        }

        public override double Area
        {
            get
            {
                return area;
            }
        }

        private double CalculateArea(double height, double width)
        {
            return height * width;
        }
    }
}
