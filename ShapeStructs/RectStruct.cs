using System.Collections.Generic;

namespace GeoLib
{
    public class RectStruct : ShapeStruct
    {
        public Vector2 Size;

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
            Position = position;
            Size = size;
        }

        public override bool ContainsPoint(Vector2 point)
        {
            if (point.X >= Position.X && point.X <= Position.X + Size.X && point.Y >= Position.Y && point.Y <= Position.Y + Size.Y)
               return true;

            return false;
        }

        public override bool ContainsPoint(double x, double y)
        {
            return ContainsPoint(new Vector2(x, y));
        }

        public override bool ContainsLine(MathLine line)
        {
            return isCrossPointOnVerticalSides(line) || isCrossPointOnHorizontalSides(line);
        }

        bool isCrossPointOnVerticalSides(MathLine line)
        {
            double lineValueLeftSide = line.ValueAt(Position.X);
            double lineValueRightSide = line.ValueAt(Position.X - Size.X);

            if ((lineValueLeftSide <= Position.Y && lineValueLeftSide >= Position.Y - Size.Y) || (lineValueRightSide <= Position.Y && lineValueRightSide >= Position.Y - Size.Y))
                return true;

            return false;
        }

        bool isCrossPointOnHorizontalSides(MathLine line)
        {
            List<MathLine> horizontalLines = getHorizontalSidesLines();

            List<Vector2> crossPoints = new List<Vector2>();

            foreach (MathLine l in horizontalLines)
                crossPoints.Add(l.GetCrossPoint(line));

            foreach (Vector2 point in crossPoints)
                if (point.X >= Position.X && point.X <= Position.X - Size.X)
                    return true;

            return false;
        }

        List<MathLine> getHorizontalSidesLines()
        {
            List<MathLine> horizontalLines = new List<MathLine>();

            horizontalLines.Add(new MathLine(0, Position.Y));
            horizontalLines.Add(new MathLine(0, Position.Y - Size.Y));

            return horizontalLines;
        }

        public override bool ContainsCirc(CircStruct circ)
        {
            RectStruct boxX = new RectStruct(Position.X - circ.Size.X / 2, y, Size.X + circ.Size.X, Size.Y);
            RectStruct boxY = new RectStruct(Position.X, Position.Y - circ.Size.Y / 2, Size.X, Size.Y + circ.Size.X);
            Vector2 circOriginPosition = new Vector2(circ.Position.X + circ.Size.X / 2, circ.Position.Y + circ.Size.Y / 2);

            if (boxX.ContainsPoint(circOriginPosition) || boxY.ContainsPoint(circOriginPosition))
                return true;

            List<Vector2> vertexes = new List<Vector2>();
            vertexes.Add(new Vector2(Position.X, Position.Y));
            vertexes.Add(new Vector2(Position.X + Size.X, Position.Y));
            vertexes.Add(new Vector2(Position.X, Position.Y + Size.Y));
            vertexes.Add(new Vector2(Position.X + Size.X, Position.Y + Size.Y));

            foreach (Vector2 vertex in vertexes)
                if (GameMath.GetDistance(vertex, circOriginPosition) <= circ.Size.X / 2)
                    return true;

            return false;
        }

        public override bool ContainsRect(RectStruct rect)
        {
            if (rect.Position.X + rect.Size.X >= Position.X && rect.Position.X <= Position.X + Size.X && rect.Position.Y + rect.Size.Y >= Position.Y && rect.Position.Y <= Position.Y + Size.Y)
               return true;

            return false;
        }
    }
}
