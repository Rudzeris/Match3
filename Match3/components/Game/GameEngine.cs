namespace Match3;

public enum ClickType
{
    FirstClick, SecondClick, Animation
}
public class GameEngine
{
    private IChecker checker;
    private int delayMs = 200;
    public GameGrid GameGrid { get; private set; }
    public Score Score { get; set; }
    private readonly GameVisual _window;

    public BaseEntity? FirstEntity { get; set; }
    public BaseEntity? SecondEntity { get; set; }
    private ClickType _clickType;

    public GameEngine(GameVisual window)
    {
        _window = window;
        GameGrid = new GameGrid(new Size(8, 8));
        checker = new Checker(GameGrid);
    }

    public async void Click(Vector2 position)
    {
        BaseEntity? entity = GameGrid[position];
        if (entity == null)
            return;
        switch (_clickType)
        {
            case ClickType.FirstClick:
                FirstEntity = entity;
                _clickType = ClickType.SecondClick;
                _window.Select(entity.Position);
                break;
            case ClickType.SecondClick:
                if (entity == FirstEntity)
                {
                    FirstEntity = null;
                    _window.UnSelect(entity.Position);
                    _clickType = ClickType.FirstClick;

                }
                else
                {
                    SecondEntity = entity;
                    _window.Select(entity.Position);
                    _clickType = ClickType.Animation;
                    Click(position);
                }
                break;
            case ClickType.Animation:
                await Task.Delay(delayMs);

                // TODO: swap entity
                SwapEntity();
                // TODO: activate entity

                await Task.Delay(delayMs);

                if (FirstEntity != null)
                    _window.UnSelect(FirstEntity.Position);
                if (SecondEntity != null)
                    _window.UnSelect(SecondEntity.Position);
                FirstEntity = SecondEntity = null;
                _clickType = ClickType.FirstClick;
                break;
        }
        _window.Update();
    }

    private void CheckAndActivate(BaseEntity entity)
    {
        // Checking
        CheckResult result = checker.CheckCells(entity,out _);
        // Remove and Activate
    }

    private void SwapEntity()
    {
        if (FirstEntity == null || SecondEntity == null) return;

        _window.Swap(FirstEntity.Position, SecondEntity.Position);
        GameGrid.Swap(FirstEntity, SecondEntity);
    }

    public void Start()
    {
        GameGrid.FillGrid();
        _clickType = ClickType.FirstClick;
        _window.Update();
    }
}
