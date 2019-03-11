using System;

namespace GeoLib
{
    class RectStruct : ShapeStruct
    {
        public Vector2 Size;

        double h;
        double w;

        public RectStruct(Vector2 position, Vector2 size)
        {
            create(position, size);
        }

        public RectStruct(double x, double y, double w, double h)
        {
            Vector2 position = new Vector2(x, y);
            Vector2 size = new Vector2(w, h);

            create(position, size);
        }

        void create(Vector2 position, Vector2 size)
        {
            X = position.X;
            Y = position.Y;
            Position = position;

            h = size.X;
            w = size.Y;
            Size = size;
        }

        public override bool ContainsPoint(Vector2 point)
        {
            return false;
        }

        public override bool ContainsPoint(double x, double y)
        {
            return false;
        }

        public override bool ContainsLine(MathLine line)
        {
            return false;
        }

        public override bool ContainsCirc(CircStruct circ)
        {
            return false;
        }

        public override bool ContainsRect(RectStruct rect)
        {
            return false;
        }
    }
}
