using Match3.components.Other;

namespace Match3;
public class Checker : IChecker
{
    public IGameGrid GameGrid { get; set; }
    public Checker(IGameGrid gameGrid)
    {
        GameGrid = gameGrid;
    }

    private CheckResult GetResult(int number, bool vertical = true)
        => number >= 5 ? CheckResult.Bomb :
            number == 4 ? (vertical ? CheckResult.VerticalLine : CheckResult.HorizontalLine) :
            number == 3 ? CheckResult.Remove :
            CheckResult.None;

    public CheckResult CheckCells(BaseEntity baseEntity, out List<BaseEntity> list)
    {
        // Up -> DownEntities
        list = new List<BaseEntity>();
        for (int i = 0; i <= 2; i += 2)
            CheckCells(baseEntity.Position + (Direction)i, (Direction)i, baseEntity.EntityColor, list);
        list.Add(baseEntity);

        CheckResult result = GetResult(list.Count);

        if (result == CheckResult.None)
        {
            list.Clear();
            for (int i = 1; i <= 3; i += 2)
                CheckCells(baseEntity.Position + (Direction)i, (Direction)i, baseEntity.EntityColor, list);
            list.Add(baseEntity);

            result = GetResult(list.Count, false);
        }
        return result;
    }

    private void CheckCells(Vector2 position, Direction direction, EntityColor color, List<BaseEntity> list)
    {
        BaseEntity? entity = GameGrid[position];
        if (entity == null ||
            position.X < 0 || position.Y < 0 ||
            position.X >= GameGrid.X || position.Y >= GameGrid.Y ||
            entity.EntityColor != color
            ) return;

        CheckCells(position + direction, direction, color, list);
        list.Add(entity);
    }

}

