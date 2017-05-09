namespace ShapesHandler
{
    public class Circle : PolarCoordinatesShape
    {
        private readonly double circumference;
        private readonly double Radius;

        public Circle(double radius) : base(radius, radius)
        {
            Radius = radius;
            circumference = CalculateCircumference(Radius);
        }

        public override double Circumference
        {
            get
            {
                return circumference;
            }
        }

        private double CalculateCircumference(double radius)
        {
            return 2 * PI * radius;
        }
    }
}
