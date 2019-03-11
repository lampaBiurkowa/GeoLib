﻿using System.Collections.Generic;

namespace GeoLib
{
    class CircStruct : ShapeStruct
    {
        public Vector2 Size;
        double r;

        public CircStruct(Vector2 position, double radius)
        {
            create(position, radius);
        }

        public CircStruct(double x, double y, double radius)
        {
            create(new Vector2(x, y), radius);
        }

        void create(Vector2 position, double radius)
        {
            x = position.X;
            y = position.Y;
            Position = position;

            r = radius;
            Size = new Vector2(r * 2, r * 2);
        }

        public override bool ContainsPoint(Vector2 point)
        {
            if (GameMath.GetDistance(Position, point) <= r)
                return true;

            return false;
        }

        public override bool ContainsPoint(double x, double y)
        {
            Vector2 point = new Vector2(x, y);
            if (GameMath.GetDistance(Position, point) <= r)
                return true;

            return false;
        }

        public override bool ContainsLine(MathLine line)
        {
            double distance = line.GetDistanceFromPoint(x + r, y + r);

            if (distance <= r)
                return true;

            return false;
        }

        public override bool ContainsCirc(CircStruct circ)
        {
            if (GameMath.GetDistance(Position, circ.Position) <= r + circ.Size.X)
                return true;

            return false;
        }

        public override bool ContainsRect(RectStruct rect)
        {
            List<Vector2> vertexes = new List<Vector2>();
            vertexes.Add(new Vector2(rect.Position.X, rect.Position.Y));
            vertexes.Add(new Vector2(rect.Position.X + rect.Size.X, rect.Position.Y));
            vertexes.Add(new Vector2(rect.Position.X, rect.Position.Y + rect.Size.Y));
            vertexes.Add(new Vector2(rect.Position.X + rect.Size.X, rect.Position.Y + rect.Size.Y));

            Vector2 originPosition = new Vector2(x + r, y + r);

            RectStruct boxX = new RectStruct(rect.Position.X - r, rect.Position.Y, rect.Size.X + Size.X, rect.Size.Y);
            RectStruct boxY = new RectStruct(rect.Position.X, rect.Position.Y - r, rect.Size.X, rect.Size.Y + Size.Y);

            if (boxX.ContainsPoint(originPosition) || boxY.ContainsPoint(originPosition))
                return true;

            foreach (Vector2 vertex in vertexes)
                if (GameMath.GetDistance(vertex, originPosition) <= r)
                    return true;
     
            return false;
        }
    }
}
