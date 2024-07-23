namespace Match3;

public class Bomb : BaseEntity
{
    private readonly IGameGrid _gameGrid;
    public Bomb(Vector2 position, EntityColor entityColor, IGameGrid grid) : base(position, entityColor)
    {
        _gameGrid = grid;
    }

    public override int Activate()
    {
        int count = base.Activate();

        for (int i = Position.Y-1; i <= Position.Y+1; i++)
        {
            for(int j = Position.X-1; j <= Position.X+1; j++)
            {
                BaseEntity? entity = _gameGrid[i, j];
                if(entity != null)
                    count+=entity.Activate();
            }
        }
        return count;
    }

    public override string ToString()
        => $"{Position.Y},{Position.X}";
}
