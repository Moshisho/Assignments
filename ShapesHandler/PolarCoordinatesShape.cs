namespace ShapesHandler
{
    public abstract class PolarCoordinatesShape : I2DShape
    {
        private readonly double area;
        protected const double PI = 3.141;

        public abstract double Circumference { get; }

        public PolarCoordinatesShape(double r1, double r2)
        {
            area = CalculateArea(r1, r2); 
        }

        protected virtual double CalculateArea(double radius1, double radius2)
        {
            return PI * radius1 * radius2;
        }

        public double Area
        {
            get
            {
                return area;
            }
        }
    }
}
