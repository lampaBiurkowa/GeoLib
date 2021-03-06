﻿using System.Collections.Generic;

namespace GeoLib
{
    public class CircStruct : ShapeStruct
    {
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
            Position = position;
            Size = new Vector2(radius * 2, radius * 2);
        }

        public override bool ContainsPoint(Vector2 point)
        {
            if (GameMath.GetDistance(GetOrigin(), point) <= Size.X / 2)
                return true;

            return false;
        }

        public override bool ContainsPoint(double x, double y)
        {
            Vector2 point = new Vector2(x, y);
            if (GameMath.GetDistance(GetOrigin(), point) <= Size.X / 2)
                return true;

            return false;
        }

        public override bool ContainsLine(MathLine line)
        {
            double distance = line.GetDistanceFromPoint(GetOrigin().X, GetOrigin().Y);

            if (distance <= Size.X / 2)
                return true;

            return false;
        }

        public override bool ContainsCirc(CircStruct circ)
        {
            if (GameMath.GetDistance(GetOrigin(), circ.GetOrigin()) <= Size.X / 2 + circ.Size.X / 2)
                return true;

            return false;
        }

        public bool ContainsFullCirc(CircStruct circ)
        {
            double biggerRadius = Size.X / 2 > circ.Size.X / 2 ? Size.X / 2 : circ.Size.X / 2;

            if (GameMath.GetDistance(GetOrigin(), circ.GetOrigin()) <= biggerRadius)
                return true;

            return false;
        }

        public override bool ContainsRect(RectStruct rect)
        {
            RectStruct boxX = new RectStruct(rect.Position.X - Size.X / 2, rect.Position.Y, rect.Size.X + Size.X / 2, rect.Size.Y);
            RectStruct boxY = new RectStruct(rect.Position.X, rect.Position.Y - Size.X / 2, rect.Size.X, rect.Size.Y + Size.X / 2);

            if (boxX.ContainsPoint(GetOrigin()) || boxY.ContainsPoint(GetOrigin()))
                return true;

            List<Vector2> vertexes = new List<Vector2>();
            vertexes.Add(new Vector2(rect.Position.X, rect.Position.Y));
            vertexes.Add(new Vector2(rect.Position.X + rect.Size.X, rect.Position.Y));
            vertexes.Add(new Vector2(rect.Position.X, rect.Position.Y + rect.Size.Y));
            vertexes.Add(new Vector2(rect.Position.X + rect.Size.X, rect.Position.Y + rect.Size.Y));

            foreach (Vector2 vertex in vertexes)
                if (GameMath.GetDistance(vertex, GetOrigin()) <= Size.X / 2)
                    return true;
     
            return false;
        }
    }
}
