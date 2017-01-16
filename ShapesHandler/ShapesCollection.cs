using System.Collections.Generic;
using System.Linq;

namespace ShapesHandler
{
    public class ShapesCollection : List<I2DShape>
    {
        //This class is inteded to have extensibility on list of shapes for example:
        public double AverageArea
        {
            get
            {
                return this.Select(x => x.Area).Average();
            }
        }

        public double CircumferencesSum
        {
            get
            {
                return this.Select(x => x.Circumference).Sum();
            }
        }

        public double AreasSum
        {
            get
            {
                return this.Select(x => x.Area).Sum();
            }
        }

        public double BiggestCircumference
        {
            get
            {
                return this.OrderByDescending(x => x.Circumference).First().Circumference;
            }
        }

        public double BiggestArea
        {
            get
            {
                return this.OrderByDescending(x => x.Area).First().Area;
            }
        }
    }
}
