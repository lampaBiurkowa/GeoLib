using System;

namespace GeoLib
{
    static class GameMath
    {
        public static double GetDistance(Vector2 pointA, Vector2 pointB)
        {
            double xDistance = pointA.X - pointB.X;
            double yDistance = pointB.Y - pointA.Y;
            return Math.Sqrt(Math.Pow(xDistance, 2) + Math.Pow(yDistance, 2));
        }
    }
}
