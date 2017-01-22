using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShapesHandler.Utils
{
    public class ShapeAddedEventArgs : EventArgs
    {
        public DateTime HappenedOn;
        public string Prefix = "Added Shape: ";
    }
}
