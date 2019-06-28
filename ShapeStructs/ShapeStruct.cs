using System;

namespace GeoLib
{
    public abstract class ShapeStruct
    {
        public Vector2 Position;
        public Vector2 Size;

        public abstract bool ContainsPoint(Vector2 point);
        public abstract bool ContainsPoint(double x, double y);
        public abstract bool ContainsRect(RectStruct rect);
        public abstract bool ContainsCirc(CircStruct circ);
        public abstract bool ContainsLine(MathLine line);
    }
}
