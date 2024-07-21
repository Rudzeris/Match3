using System.Drawing;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Match3;

public enum ClickType
{
    FirstClick, SecondClick, Animation
}
public class GameEngine
{
    private int delayMs = 200;
    private GameGrid gameGrid { get; set; }
    public IGameGrid GameGrid { get => gameGrid; }
    public Score Score { get; set; }
    private readonly GameVisual _window;

    public BaseEntity? FirstEntity { get; set; }
    public BaseEntity? SecondEntity { get; set; }
    private ClickType _clickType;

    public GameEngine(GameVisual window)
    {
        _window = window;
        gameGrid = new GameGrid(new Size(8, 8));
    }

    public async void Click(Vector2 position)
    {
        BaseEntity? entity = gameGrid[position];
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

    public void Start()
    {
        gameGrid.FillGrid();
        _clickType = ClickType.FirstClick;
        _window.Update();
    }
}
