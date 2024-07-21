using Match3.components.Other;

namespace Match3;
public class Checker : IChecker
{
    public IGameGrid GameGrid { get; set; }
    public Checker(IGameGrid gameGrid)
    {
        GameGrid = gameGrid;
    }

    private CheckResult GetResult(int number)
        => number >= 5 ? CheckResult.Bomb :
            number == 4 ? CheckResult.Line :
            number == 3 ? CheckResult.Remove :
            CheckResult.None;

    public CheckResult CheckCells(BaseEntity baseEntity, out List<BaseEntity> list)
    {
        // Up -> Down
        list = new List<BaseEntity>();
        for (int i = 0; i <= 2; i += 2)
            CheckCells(baseEntity.Position, (Direction)i, baseEntity.EntityColor,list);

        CheckResult result = GetResult(list.Count);
        if(result == CheckResult.Line) result = CheckResult.VerticalLine;

        if (result == CheckResult.None)
        {
            list.Clear();
            for (int i = 0; i <= 2; i += 2)
                CheckCells(baseEntity.Position, (Direction)i, baseEntity.EntityColor, list);

            result = GetResult(list.Count);
            if (result == CheckResult.Line) result = CheckResult.HorizontalLine;
        }
        return result;
    }

    private void CheckCells(Vector2 position, Direction direction, EntityColor color, List<BaseEntity> list)
    {
        BaseEntity? entity = GameGrid[position];
        if (entity == null ||
            position.X < 0 || position.Y < 0 ||
            position.X >= GameGrid.X || position.Y >= GameGrid.Y
            ) return;

        list.Add(entity);
    }

}

