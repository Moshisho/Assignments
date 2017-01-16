using System.Linq;

namespace ShapesHandler
{
    public abstract class CartesianCoordinatesShape : I2DShape
    {
        private readonly double circumference;

        internal CartesianCoordinatesShape(double[] sides)
        {
            circumference = CalculateCircumference(sides);
        }

        internal CartesianCoordinatesShape(double side1, double side2) : this(new double[] { side1, side2, side1, side2 })
        {
        }

        internal CartesianCoordinatesShape(double side1) : this(new double[] { side1, side1, side1, side1 })
        {
        }

        public double Circumference
        {
            get
            {
                return circumference;
            }
        }

        protected virtual double CalculateCircumference(double[] sides)
        {
            return sides.Sum();
        }

        // TODO: check if partly impelement
        public abstract double Area { get; }
    }
}
