using System;

namespace GeoLib.GeoLib
{
    public class Vector2
    {
        public float X { get; private set; }
        public float Y { get; private set; }

        public Vector2(Vector2 coors)
        {
            X = coors.X;
            Y = coors.Y;
        }

        public Vector2(float x, float y)
        {
            X = x;
            Y = y;
        }


    }
}
