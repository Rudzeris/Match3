using System.Windows;
using System.Windows.Controls;

namespace Match3;

public class GameStateCreator : GameState
{
    public GameStateCreator(Panel panel, RoutedEventHandler routedEventHandler) : base(panel)
    {
        GameState menu = new MainMenu(panel, routedEventHandler);
        GameState game = new GameVisual(panel, routedEventHandler);
        GameState end = new EndMenu(panel, routedEventHandler);
        menu.nextState = game;
        game.nextState = end;
        end.nextState = menu;
        this.nextState = menu;
    }

    public override void Start()
    {

    }

    public override void Stop()
    {
    }

    public override void Update()
    {
    }
}
