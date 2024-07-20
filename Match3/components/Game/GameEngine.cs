using System.Windows.Controls;

namespace Match3;

public class GameEngine
{
    public GameGrid gameGrid { get; set; }
    public Score Score { get; set; }
    private readonly GameState _window;

    public GameEngine(GameState window)
    {
        _window = window;
        gameGrid = new GameGrid(8, 8);
    }

}
