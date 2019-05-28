using System.Collections.Generic;

namespace GeoLib
{
    public class RectStruct : ShapeStruct
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
            x = position.X;
            y = position.Y;
            Position = position;

            h = size.X;
            w = size.Y;
            Size = size;
        }

        public override bool ContainsPoint(Vector2 point)
        {
            if (point.X >= x && point.X <= x + w && point.Y >= y && point.Y <= y + h)
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
            double lineValueLeftSide = line.ValueAt(x);
            double lineValueRightSide = line.ValueAt(x - w);

            if ((lineValueLeftSide <= y && lineValueLeftSide >= y - h) || (lineValueRightSide <= y && lineValueRightSide >= y - h))
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
                if (point.X >= x && point.X <= x - w)
                    return true;

            return false;
        }

        List<MathLine> getHorizontalSidesLines()
        {
            List<MathLine> horizontalLines = new List<MathLine>();

            horizontalLines.Add(new MathLine(0, y));
            horizontalLines.Add(new MathLine(0, y - h));

            return horizontalLines;
        }

        public override bool ContainsCirc(CircStruct circ)
        {
            List<Vector2> vertexes = new List<Vector2>();
            vertexes.Add(new Vector2(x, y));
            vertexes.Add(new Vector2(x + w, y));
            vertexes.Add(new Vector2(x, y + h));
            vertexes.Add(new Vector2(x + w, y + h));

            Vector2 circOriginPosition = new Vector2(circ.Position.X + circ.Size.X / 2, circ.Position.Y + circ.Size.Y / 2);

            RectStruct boxX = new RectStruct(x - circ.Size.X / 2, y, w + circ.Size.X, h);
            RectStruct boxY = new RectStruct(x, y - circ.Size.Y / 2, w, h + circ.Size.X);

            if (boxX.ContainsPoint(circOriginPosition) || boxY.ContainsPoint(circOriginPosition))
                return true;

            foreach (Vector2 vertex in vertexes)
                if (GameMath.GetDistance(vertex, circOriginPosition) <= circ.Size.X / 2)
                    return true;

            return false;
        }

        public override bool ContainsRect(RectStruct rect)
        {
            if (rect.Position.X + rect.Size.X >= x && rect.Position.X <= x + w && rect.Position.Y + rect.Size.Y >= y && rect.Position.Y <= y + h)
               return true;

            return false;
        }
    }
}
