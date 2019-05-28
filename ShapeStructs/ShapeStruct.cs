using System;

namespace GeoLib
{
    public abstract class ShapeStruct
    {
        protected double x;
        protected double y;
        public Vector2 Position;

        public abstract bool ContainsPoint(Vector2 point);
        public abstract bool ContainsPoint(double x, double y);
        public abstract bool ContainsRect(RectStruct rect);
        public abstract bool ContainsCirc(CircStruct circ);
        public abstract bool ContainsLine(MathLine line);
    }
}
