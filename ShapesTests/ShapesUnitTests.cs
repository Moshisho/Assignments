using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesHandler;

namespace ShapesTests
{
    [TestClass]
    public class ShapesUnitTests
    {
        [TestMethod]
        public void IsRectangleCreatedCorrectly()
        {
            Rectangle rect = new Rectangle(5, 6);

            Assert.AreEqual(30, rect.Area, 0, "Area of calulated and expected are different.");
            Assert.AreEqual(22, rect.Circumference, 0, "Circumference of calulated and expected are different.");
        }

        [TestMethod]
        public void IsSquareCreatedCorrectly()
        {
            Square square = new Square(2);

            Assert.AreEqual(4, square.Area, 0, "Area of calulated and expected are different.");
            Assert.AreEqual(8, square.Circumference, 0, "Circumference of calulated and expected are different.");
        }
    }
}
