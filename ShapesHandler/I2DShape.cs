namespace ShapesHandler
{
    // Square extends Rectangle (width = height)
    // add abstruct Shape.cs with default implementations. (virtual)
    // override ToString()

    public interface I2DShape 
    {
        double Area { get; }
        double Circumference { get; }
    }
}
