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
    private int delayMs = 100;
    public GameGrid GameGrid { get; private set; }
    public Score Score { get; set; }
    private readonly GameVisual _window;
    public BaseEntity? FirstEntity { get; set; }
    public BaseEntity? SecondEntity { get; set; }
    private ClickType _clickType;
    private readonly RoutedEventHandler exit;

    private DispatcherTimer _timer;

    public uint TimeValue { get; private set; }
    public uint MaxTimeValue { get; private set; }

    public GameEngine(GameVisual window, RoutedEventHandler exit)
    {
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
        if (entity == null || _clickType == ClickType.Animation)
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

                        CheckAndActivate(FirstEntity);
                        CheckAndActivate(SecondEntity);
                        _window.Update();
                        if (true)
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
                    }

                    FirstEntity = SecondEntity = null;
                    _clickType = ClickType.FirstClick;
                }
                break;
        }
        _window.Update();
    }

    private void CheckAndActivate(BaseEntity entity)
    {
        if (entity == null) return;
        // Checking
        CheckResult result = checker.CheckCells(entity, out _);
        // Remove and Activate
    }

    private bool SwapEntity()
    {
        if (FirstEntity == null || SecondEntity == null) return false;

        return GameGrid.Swap(FirstEntity, SecondEntity);
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
