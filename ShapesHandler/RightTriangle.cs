using System;

namespace ShapesHandler
{
    public class RightTriangle : CartesianCoordinatesShape
    {
        private readonly double area;
        private readonly double Height;
        private readonly double Width;

        public RightTriangle(double height, double width) : base(new double[] { height, width, Math.Sqrt(height*height + width*width) })
        {
            Height = height;
            Width = width;
            area = CalculateArea(Height, Width);
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
            return height * width / 2;
        }
    }
}
