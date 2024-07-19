namespace Match3;
public class GameGrid
{
    private BaseEntity[,] grid;
    public GameGrid(uint height, uint width)
    {
        grid = new BaseEntity[height, width];
    }
}