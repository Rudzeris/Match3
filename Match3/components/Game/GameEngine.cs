using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Match3;

public enum ClickType
{
    FirstClick, SecondClick, Animation
}
public enum Operation
{
    None, Operation, Complete
}
public class GameEngine
{
    private IChecker checker;
    private int delayMs = 100;
    public GameGrid GameGrid { get; private set; }
    private Score _score;
    public Score Score => _score;
    private readonly GameVisual _window;
    public BaseEntity? FirstEntity { get; set; }
    public BaseEntity? SecondEntity { get; set; }
    private ClickType _clickType;
    private readonly RoutedEventHandler exit;
    private bool _operation;

    private DispatcherTimer _timer;

    public uint TimeValue { get; private set; }
    public uint MaxTimeValue { get; private set; }

    public GameEngine(GameVisual window, RoutedEventHandler exit)
    {
        _operation = false;
        _score = new Score();
        _score.UpdateScore += window.UpdateScore;
        this.exit = exit;
        _window = window;
        GameGrid = new GameGrid(new Size(8, 8));
        checker = new Checker(GameGrid);
        _timer = new DispatcherTimer();
        _timer.Interval = new TimeSpan(0, 0, 1);
        MaxTimeValue = 60;
        _timer.Tick += (object? sender, EventArgs e) =>
        {
            _window.UpdateTime();
            TimeValue++;
            if (TimeValue > MaxTimeValue)
            {
                TimeValue = 0;
                _window.UpdateTime();
                this.Stop();
            }
        };
    }

    public async void Click(Vector2 position)
    {
        BaseEntity? entity = GameGrid[position];
        if (entity == null || _operation)
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
                    _operation = true;
                    SecondEntity = entity;
                    _window.Select(entity.Position);
                    _clickType = ClickType.Animation;


                    if (FirstEntity == null || SecondEntity == null)
                    {
                        _clickType = ClickType.FirstClick;
                        break;
                    }
                    await Task.Delay(delayMs);
                    _window.Select(FirstEntity.Position);
                    _window.Select(SecondEntity.Position);

                    await Task.Delay(delayMs);
                    bool swap = SwapEntity();
                    await Task.Delay(delayMs);

                    _window.UnSelect(FirstEntity.Position);
                    _window.UnSelect(SecondEntity.Position);

                    if (swap)
                    {
                        WindowUpdate();
                        bool destroy = DestroyEntities(FirstEntity);
                        destroy = DestroyEntities(SecondEntity) || destroy;
                        WindowUpdate();
                        if (!destroy)
                        {
                            await Task.Delay(delayMs * 3);
                            _window.Select(FirstEntity.Position);
                            _window.Select(SecondEntity.Position);

                            await Task.Delay(delayMs);
                            SwapEntity();
                            await Task.Delay(delayMs);

                            _window.UnSelect(FirstEntity.Position);
                            _window.UnSelect(SecondEntity.Position);
                        }
                        else
                        {
                            await Task.Delay(delayMs);
                            GameGrid.DownEntities();
                            await Task.Delay(delayMs * 3);
                            GameGrid.AddEntities();
                            await Task.Delay(delayMs);
                            GridCheck(true);
                        }
                        WindowUpdate();

                    }
                    else
                    {

                    }

                    FirstEntity = SecondEntity = null;
                    _clickType = ClickType.FirstClick;
                    _operation = false;
                }
                break;
        }
        _window.Update();
    }

    private async void GridCheck(bool show = false)
    {
        _operation = true;
        BaseEntity? entity = null;
        int count = -1;
        while (count != 0)
        {
            count = 0;
            for (int i = 0; i < GameGrid.Y; i++)
            {
                for (int j = 0; j < GameGrid.X; j++)
                {
                    entity = GameGrid[i, j];
                    if (entity != null && !entity.IsDeleted)
                    {
                        count += DestroyEntities(entity) ? 1 : 0;
                    }
                }
            }
            if (show)
            {
                WindowUpdate();
                await Task.Delay(delayMs);
            }
            GameGrid.DownEntities();
            if(show)
                await Task.Delay(delayMs * 3);
            if (show)
                WindowUpdate();
            GameGrid.AddEntities();
            if(show)
            await Task.Delay(delayMs);
        }
        WindowUpdate();
        _operation = false;
    }

    private bool DestroyEntities(BaseEntity entity)
    {
        _operation = true;
        if (entity == null || entity.IsDeleted) return false;

        List<BaseEntity> entities;
        // Checking
        CheckResult result = checker.CheckCells(entity, out entities);

        if (result == CheckResult.None) return false;
        foreach (var ent in entities)
        {
            _score.Value += ent.Activate();
        }

        GameGrid[entity.Position] = result switch
        {
            CheckResult.Bomb => new Bomb(entity.Position, entity.EntityColor, GameGrid),
            CheckResult.HorizontalLine => new HorizontalLine(entity.Position, entity.EntityColor, GameGrid),
            CheckResult.VerticalLine => new VerticalLine(entity.Position, entity.EntityColor, GameGrid),
            _ => entity
        };
        return true;
    }

    public void WindowUpdate()
    {
        _window.Update();
    }

    private bool SwapEntity()
    {
        if (FirstEntity == null || SecondEntity == null) return false;

        return GameGrid.Swap(FirstEntity, SecondEntity);
    }

    public void Start()
    {
        TimeValue = 0;
        _window.UpdateTime();
        _timer.Start();
        GameGrid.RandomFillGrid();
        _clickType = ClickType.FirstClick;
        GridCheck();
        _score.Value = 0;
        WindowUpdate();
    }

    public void Stop()
    {
        _timer.Stop();
        exit(this, new RoutedEventArgs());
    }

}
