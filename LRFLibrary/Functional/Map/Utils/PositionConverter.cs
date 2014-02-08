using System;
using System.Drawing;

using LRFLibrary.Functional.Map.Generic;

namespace LRFLibrary.Functional.Map.Utils
{
    static public class PositionConverter
    {
        public static Point toPoint(IPosition position)
        {
            return new Point(position.x, position.y);
        }

        public static IPosition toPosition(Point point)
        {
            return new Position(point.X,point.Y);
        }
    }
}
