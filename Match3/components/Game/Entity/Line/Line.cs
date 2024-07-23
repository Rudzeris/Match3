using Match3.components.Other;

namespace Match3;

public abstract class Line : BaseEntity
{
    protected IGameGrid gameGrid;
    public Line(Vector2 position, EntityColor type, IGameGrid gameGrid) : base(position, type)
    {
        this.gameGrid = gameGrid;
    }
    public override string ToString()
        => $"L";
}

public class HorizontalLine : Line
{
    public HorizontalLine(Vector2 position, EntityColor type, IGameGrid gameGrid) : base(position, type, gameGrid)
    {

    }
    public override int Activate()
    {
        int count = base.Activate();

        for (int i = 0; i < gameGrid.X; i++)
        {
            BaseEntity? entity = gameGrid[this.Position.Y,i];
            if (entity != null)
                count += entity.Activate();
        }
        return count;
    }
    public override string ToString()
        => $"H";
}

public class VerticalLine : Line
{
    public VerticalLine(Vector2 position, EntityColor type, IGameGrid gameGrid) : base(position, type, gameGrid)
    {
    }
    public override int Activate()
    {
        int count = base.Activate();

        for (int i = 0; i < gameGrid.Y; i++)
        {
            BaseEntity? entity = gameGrid[i, this.Position.X];
            if (entity != null)
                count += entity.Activate();
        }
        return count;
    }
    public override string ToString()
        => $"V";

}