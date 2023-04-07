global using Microsoft.AspNetCore.Components.QuickGrid;
using System.Drawing;

namespace Laplace;
public class MyLibrary
{
    public class RightTriangle
    {
        public double L1 { get; private set; }
        public double L2 { get; private set; }
        public double L3 { get; private set; }

        public double AngleHy = 0;             //  Angle opposed to hypotenuse
        public double AngleBa = 0;             //  Angle opposed to base
        public double AngleHt = 0;             //  Angle opposed to height
        public double CalculatedRightAngle = 0; //  Right angle recalculated for chicking
        public double SharpestAngle = 0;

        public double hypotenuse = 0;
        public double baseT = 0;
        public double height = 0;

        public Tuple< PointF, PointF, PointF> TriangleCoordinates( double x, double y)
        {
            PointF a = new PointF((float)x, (float)y);
            PointF b = new PointF((float)x + (float)baseT, (float)y);
            PointF c = new PointF((float)x + (float)baseT, (float)y - (float)height);

            Tuple<PointF, PointF, PointF> t = Tuple.Create( a, b, c);
            return t;
        }
        public void sharpAngle()
        {
            AngleHt = Math.Acos(height / hypotenuse);
            AngleBa = Math.Acos(baseT / hypotenuse);
            //  Pela Lei dos Senos : a/sin(A) = b/sin(B) = c/sin(C)
            //  Pela lei dos Cossenos : c^2 = a^2 + b^2 - 2abcos(C) => cos(C) = ( a^2 + b^2 - c^2) / 2 ab                
            AngleHy = Math.Acos((Math.Pow(height, 2) + Math.Pow(baseT, 2) - Math.Pow(hypotenuse, 2)) / (2 * height * baseT));
            SharpestAngle = Math.Atan(height / baseT);

            //double A = Math.Atan2( baseT, height); // angle opposite side a
            //double B = Math.Atan2( height, baseT); // angle opposite side b
            return;
        }
        public double Area() => (baseT * height) / 2;
        public double Area2()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - L1) * (p - L2) * (p - L3));   //  Heron formula
        }
        public double Perimeter() => hypotenuse + baseT + height;
        public RightTriangle() { L1 = 0; L2 = 0; L3 = 0; }
        public RightTriangle(double l1, double l2, double l3)
        {
            //  Classifica os lados
            hypotenuse = Math.Max(Math.Max(l1, l2), l3); ;
            height = Math.Min(Math.Min(l1, l2), l3); ;
            baseT = l1 + l2 + l3 - hypotenuse - height;
            // Almost equal : verifica Pytagoras
            if (Math.Abs(Math.Pow(hypotenuse, 2) - Math.Pow(baseT, 2) - Math.Pow(height, 2)) > 0.0000001)
                throw new Exception("Supplied values do not comply Pytagoras equation");
            sharpAngle();
            L1 = l1; L2 = l2; L3 = l3;
        }
        public RightTriangle(double l1, double l2)
        {
            //  Classifica os lados
            hypotenuse = Math.Sqrt( Math.Pow( l1, 2) + Math.Pow(l2, 2));
            height = Math.Min(l1, l2);
            baseT = Math.Max(l1, l2);
            // Almost equal : verifica Pytagoras
            if (Math.Abs(Math.Pow(hypotenuse, 2) - Math.Pow(baseT, 2) - Math.Pow(height, 2)) > 0.0000001)
                throw new Exception("Supplied values do not comply Pytagoras equation");
            sharpAngle();
            L1 = l1; L2 = l2; L3 = hypotenuse;
        }
    }
}   