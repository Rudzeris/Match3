namespace Match3;
public class GameGrid : IGameGrid
{
    public int X { get => grid.GetLength(1); }
    public int Y { get => grid.GetLength(0); }
    public BaseEntity? this[Vector2 position]
    {
        get => this[position.Y, position.X];
    }public BaseEntity? this[int y, int x]
    {
        get => CheckedEntity(y,x) switch
        {
            true => grid[y, x],
            false => null
        };
    }
    private BaseEntity[,] grid;
    public GameGrid(Size size)
    {
        grid = new BaseEntity[size.Height, size.Width];
    }
    private bool CheckedEntity(int y,int x)
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
}