using System;
using System.Collections.Generic;

namespace GeoLib
{
    public static class GameMath
    {
        public static double GetDistance(Vector2 pointA, Vector2 pointB)
        {
            double xDistance = pointA.X - pointB.X;
            double yDistance = pointB.Y - pointA.Y;
            return Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        }

        public static T Min<T>(List<T> values) where T : IComparable<T>
        {
            if (values.Count == 0)
                throw new SystemException("Cannot find minimum because values were not passed (List<T>values.Count == 0).");

            T smallest = values[0];
            for (int i = 1; i < values.Count; i++)
                if (values[i].CompareTo(smallest) < 0)
                    smallest = values[i];

            return smallest;
        }

        public static T Max<T>(List<T> values) where T : IComparable<T>
        {
            if (values.Count == 0)
                throw new SystemException("Cannot find minimum because values were not passed (List<T>values.Count == 0).");

            T biggest = values[0];
            for (int i = 1; i < values.Count; i++)
                if (values[i].CompareTo(biggest) > 0)
                    biggest = values[i];

            return biggest;
        }
    }
}
