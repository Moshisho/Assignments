using System.Linq;

namespace ShapesHandler
{
    public abstract class CartesianCoordinatesShape : I2DShape
    {
        private readonly double circumference;

        public abstract double Area { get; }

        public CartesianCoordinatesShape(double[] sides)
        {
            circumference = CalculateCircumference(sides);
        }

        public double Circumference
        {
            get
            {
                return circumference;
            }
        }

        protected double CalculateCircumference(double[] sides)
        {
            return sides.Sum();
        }   
    }
}
