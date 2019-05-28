using System;

namespace GeoLib
{
    public class Vector2
    {
        const double INFINITY = Double.MaxValue;

        public double X { get; private set; }
        public double Y { get; private set; }

        public Vector2()
        {
            X = 0;
            Y = 0;
        }

        public Vector2(Vector2 coors)
        {
            X = coors.X;
            Y = coors.Y;
        }

        public Vector2(double x, double y)
        {
            X = x;
            Y = y;
        }

        public static Vector2 operator +(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X + vec2.X, vec1.Y + vec2.Y);
        }

        public static Vector2 operator +(Vector2 vec1, double value)
        {
            return new Vector2(vec1.X + value, vec1.Y + value);
        }

        public static Vector2 operator -(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X - vec2.X, vec1.Y - vec2.Y);
        }

        public static Vector2 operator -(Vector2 vec1, double value)
        {
            return new Vector2(vec1.X - value, vec1.Y - value);
        }

        public static Vector2 operator *(Vector2 vec1, Vector2 vec2)
        {
            return new Vector2(vec1.X * vec2.X, vec1.Y * vec2.Y);
        }

        public static Vector2 operator *(Vector2 vec1, double value)
        {
            return new Vector2(vec1.X * value, vec1.Y * value);
        }

        public static Vector2 operator /(Vector2 vec1, Vector2 vec2)
        {
            double xAxis = getDividedAxis(vec1.X, vec2.X);
            double yAxis = getDividedAxis(vec1.Y, vec2.Y);

            return new Vector2(xAxis, yAxis);
        }

        static double getDividedAxis(double x1, double x2)
        {
            double axis;

            if (x2 != 0)
                axis = x1 / x2;
            else if (x1 > 0)
                axis = INFINITY;
            else if (x1 == 0)
                axis = 0;
            else
                axis = -INFINITY;

            return axis;
        }

        public static Vector2 operator /(Vector2 vec1, double value)
        {
            double xAxis = getDividedAxis(vec1.X, value);
            double yAxis = getDividedAxis(vec1.Y, value);

            return new Vector2(xAxis, yAxis);;
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
        }
    }
}
