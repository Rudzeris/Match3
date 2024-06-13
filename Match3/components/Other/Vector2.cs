using System;

namespace Match3.components
{
    internal struct Vector2
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal Vector2(int x, int y) { X = x; Y = y; }
        internal static bool TheNextCell(Vector2 a, Vector2 b)
            => ((Math.Abs(a.X - b.X) == 1) || (Math.Abs(a.Y - b.Y) == 1));
    }
}
