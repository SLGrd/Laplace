using System.Drawing;

namespace Models;
public class Circle
{
    public (double X, double Y) Center { get; set; }
    public double Radius { get; set; }
    public Color FillColor { get; set; }
    public Color StrokeColor { get; set; }
    public int StrokeWidth { get; set; }

    public Circle()
    {
        Center = (0.0, 0.0);
        Radius = 0;
        FillColor = Color.White;
        StrokeColor = Color.Black;
        StrokeWidth = 1;
    }
    public Circle( (double, double) center, double radius, Color fill,  Color stroke, int strokeWidth)
    {
        Center = (center.Item1, center.Item2);
        Radius = radius;
        FillColor = fill;
        StrokeColor = stroke;
        StrokeWidth = strokeWidth;
    }
}