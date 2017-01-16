namespace ShapesHandler
{
    public class Rectangle : CartesianCoordinatesShape
    {
        private readonly double area;
        private readonly double Height;
        private readonly double Width;

        public Rectangle(double height, double width) : base(new double[] { height, width, height, width })
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
            return height * width;
        }
    }
}
