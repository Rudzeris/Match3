using System.Drawing;

namespace Match3;

public interface IGameGrid
{
    BaseEntity? this[Vector2 position] { get; }
    BaseEntity? this[int y, int x] { get; }
    Size Size { get => new Size(X, Y); }
    int Y { get; }
    int X { get; }
}
