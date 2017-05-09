using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesHandler;

namespace ShapesTests
{
    [TestClass]
    public class ShapesUnitTests
    {
        private const string areaMsg = "Area of calulated and expected are different.";
        private const string circumMsg = "Circumference of calulated and expected are different.";

        [TestMethod]
        public void IsRectangleCreatedCorrectly()
        {
            Rectangle rect = new Rectangle(5, 6);

            Assert.AreEqual(30, rect.Area, 0, areaMsg);
            Assert.AreEqual(22, rect.Circumference, 0, circumMsg);
        }

        [TestMethod]
        public void IsSquareCreatedCorrectly()
        {
            Square square = new Square(2);

            Assert.AreEqual(4, square.Area, 0, areaMsg);
            Assert.AreEqual(8, square.Circumference, 0, circumMsg);
        }

        [TestMethod]
        public void IsRightTriangleCreatedCorrectly()
        {
            RightTriangle rt = new RightTriangle(3, 4);

            Assert.AreEqual(6, rt.Area, 0, areaMsg);
            Assert.AreEqual(12, rt.Circumference, 0, circumMsg);
        }

        [TestMethod]
        public void IsCircleCreatedCorrectly()
        {
            Circle circle = new Circle(1);

            Assert.AreEqual(Math.PI, circle.Area, 0.001, areaMsg);
            Assert.AreEqual(2* Math.PI, circle.Circumference, 0.01, circumMsg);
        }
    }
}
