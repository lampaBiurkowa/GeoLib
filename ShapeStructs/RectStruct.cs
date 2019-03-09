using System;

namespace GeoLib
{
    class RectStruct : ShapeStruct
    {
        public override bool ContainsPoint(Vector2 point)
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
