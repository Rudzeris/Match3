namespace Match3;
public class GameGrid : IGameGrid
{
    public int X { get => grid.GetLength(1); }
    public int Y { get => grid.GetLength(0); }
    public BaseEntity? this[Vector2 position]
    {
        get => this[position.Y, position.X];
        set => this[position.Y, position.X] = value;
    }
    public BaseEntity? this[int y, int x]
    {
        get => CheckedEntity(y, x) switch
        {
            true => grid[y, x],
            false => null
        };
        private set => grid[y, x] = value ?? EntityFabric.GetEntity(new Vector2(x, y));
    }
    private BaseEntity[,] grid;
    public GameGrid(Size size)
    {
        grid = new BaseEntity[size.Height, size.Width];
    }
    private bool CheckedEntity(Vector2 vec) => CheckedEntity(vec.Y, vec.X);
    private bool CheckedEntity(int y, int x)
    {
        if (x < 0 || y < 0 ||
            y >= grid.GetLength(0) || x >= grid.GetLength(1))
            return false;

        switch (grid[y, x])
        {
            case BaseEntity entity:
                if (entity.IsDeleted) return false;
                break;
            case null:
                return false;
        }

        return true;
    }
    public void FillGrid()
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                grid[i, j] = EntityFabric.GetEntity(new Vector2(j, i));
            }
        }
    }
    public bool Swap(BaseEntity? first, BaseEntity? second)
    {
        if(first == null || second == null) return false;

        if (Vector2.Length(first.Position, second.Position) != 1) return false;

        if (!CheckedEntity(first.Position) || !CheckedEntity(second.Position))
            return false;

        if (first != grid[first.Position.Y, first.Position.X] ||
            second != grid[second.Position.Y, second.Position.X])
            return false;

        this[first.Position] = second;
        this[second.Position] = first;

        Vector2 position = first.Position;
        first.Position = second.Position;
        second.Position = position;
        return true;
    }
}