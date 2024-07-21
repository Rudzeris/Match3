using Match3.components.Other;

namespace Match3;

public struct Vector2
{
    public int X;
    public int Y;
    public Vector2(int x, int y)
    {
        X = x; Y = y;
    }
    public static double Length(Vector2 v1, Vector2 v2)
        => Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
    public static Vector2 operator +(Vector2 v1, Vector2 v2)
        => new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    public static Vector2 operator -(Vector2 v1, Vector2 v2)
        => new Vector2(v1.X - v2.X, v1.Y - v2.Y);

    public static Vector2 operator +(Vector2 v1, Direction dir)
        => v1 + dir switch
        {
            Direction.Up => new Vector2(0, -1),
            Direction.Down => new Vector2(0, 1),
            Direction.Left => new Vector2(-1, 0),
            Direction.Right => new Vector2(1, 0),
            _ => new Vector2(0, 0)
        };

}
