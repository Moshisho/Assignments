namespace ShapesHandler
{
    public class Square : Rectangle
    {
        private readonly double Side;
        public Square(double sideLength) : base(sideLength, sideLength)
        {
            Side = sideLength;
        }
    }
}
