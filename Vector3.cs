using System;

namespace GeoLib
{
    public class Vector3
    {
        const double INFINITY = Double.MaxValue;

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(Vector3 coors)
        {
            X = coors.X;
            Y = coors.Y;
            Z = coors.Z;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector3 operator +(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
        }

        public static Vector3 operator +(Vector3 vec1, double value)
        {
            return new Vector3(vec1.X + value, vec1.Y + value, vec1.Z);
        }

        public static Vector3 operator -(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X - vec2.X, vec1.Y - vec2.Y, vec1.Z - vec2.Z);
        }

        public static Vector3 operator -(Vector3 vec1, double value)
        {
            return new Vector3(vec1.X - value, vec1.Y - value, vec1.Z - value);
        }

        public static Vector3 operator *(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.X * vec2.X, vec1.Y * vec2.Y, vec1.Z * vec2.Z);
        }

        public static Vector3 operator *(Vector3 vec1, double value)
        {
            return new Vector3(vec1.X * value, vec1.Y * value, vec1.Z * value);
        }

        public static Vector3 operator /(Vector3 vec1, Vector3 vec2)
        {
            double xAxis = getDividedAxis(vec1.X, vec2.X);
            double yAxis = getDividedAxis(vec1.Y, vec2.Y);
            double zAxis = getDividedAxis(vec1.Z, vec2.Z);

            return new Vector3(xAxis, yAxis, zAxis);
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

        public static Vector3 operator /(Vector3 vec1, double value)
        {
            double xAxis = getDividedAxis(vec1.X, value);
            double yAxis = getDividedAxis(vec1.Y, value);
            double zAxis = getDividedAxis(vec1.Z, value);

            return new Vector3(xAxis, yAxis, zAxis);
        }

        public double GetLength()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        public Vector3 GetCrossProduct(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3(vec1.Y * vec2.Z - vec1.Z * vec2.Y, vec1.Z * vec2.X - vec1.X * vec2.Z, vec1.X * vec2.Z - vec1.Y * vec2.X); ;
        }

        public double GetDotProduct(Vector3 vec1, Vector3 vec2)
        {
            Vector3 standardProduct = vec1 * vec2;
            return standardProduct.X + standardProduct.Y + standardProduct.Z;
        }

        public double GetTripleProduct(Vector3 vec1Cross, Vector3 vec2Cross, Vector3 vecDot)
        {
            return GetDotProduct(GetCrossProduct(vec1Cross, vec2Cross), vecDot);
        }
    }
}
