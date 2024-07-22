using System.Windows;
using System.Windows.Threading;

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
    private readonly RoutedEventHandler exit;

    private DispatcherTimer _timer;

    public uint TimeValue {get; private set;}
    public uint MaxTimeValue { get; private set; }

    public GameEngine(GameVisual window, RoutedEventHandler exit)
    {
        this.exit = exit;
        _window = window;
        GameGrid = new GameGrid(new Size(8, 8));
        checker = new Checker(GameGrid);
        _timer = new DispatcherTimer();
        _timer.Interval = new TimeSpan(0,0,1);
        MaxTimeValue = 5;
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
        CheckResult result = checker.CheckCells(entity, out _);
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
        _timer.Start();
        GameGrid.FillGrid();
        _clickType = ClickType.FirstClick;
        _window.Update();
    }

    public void Stop()
    {
        _timer.Stop();
        exit(this, new RoutedEventArgs());
    }

}
