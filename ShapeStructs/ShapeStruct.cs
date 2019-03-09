using System;

namespace GeoLib
{
    abstract class ShapeStruct
    {
        protected double X;
        protected double Y;
        public Vector2 Position;

        public abstract bool ContainsPoint(Vector2 point);
        //public abstract bool ContainsRect(RectStruct rect);
        //public abstract bool ContainsCirc(CircStruct circ);
        public abstract bool ContainsLine(MathLine line);
    }
}
