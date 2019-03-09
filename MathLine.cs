using System;
namespace GeoLib
{
    public class MathLine
    {
        public double A { get; private set; }
        public double B { get; private set; }

        public MathLine()
        {
            A = 0;
            B = 0;
        }

        public MathLine(MathLine line)
        {
            A = line.A;
            B = line.B;
        }

        public MathLine(double a, double b)
        {
            A = a;
            B = b;
        }

        public MathLine(Vector2 point1, Vector2 point2)
        {
            if ((point2.X - point1.X) == 0)
                return;

            A = (point2.Y - point1.Y) / (point2.X - point1.X);
            B = ((point1.Y * point2.X) - (point1.X * point2.Y)) / (point2.X - point1.X);
        }

        public double ValueAt(double x)
        {
            return A * x + B;
        }

        public double ArgumentForValue(double y)
        {
            if (A == 0)
                return 0;

            return (y - B) / A;
        }

        public double GetAcuteAngle()
        {
            return Math.Atan(A);
        }

        public MathLine GetPerpendicular(Vector2 point)
        {
            if (A == 0)
                return new MathLine();

            double a = -1 / A;
            double b = point.Y - a * point.X;
            return new MathLine(a, b);
        }

        public MathLine GetPerpendicular(double x, double y)
        {
            return GetPerpendicular(new Vector2(x, y));
        }

        public Vector2 GetCrossPoint(MathLine line)
        {
            if (A - line.A == 0)
                return new Vector2();

            double x = (line.B - B) / (A - line.A);
            double y = A * x + B;

            return new Vector2(x, y);
        }

        public double GetDistanceFromPoint(Vector2 point)
        {
            double a = A;
            int b = -1;
            double c = B;

            return Math.Abs(a + b + c) / Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
}
