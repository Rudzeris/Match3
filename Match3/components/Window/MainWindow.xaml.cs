using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Match3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private GameState gameState;
    public MainWindow()
    {
        InitializeComponent();
        gameState = new MainMenu(mainGrid, NextStateClick);
        GameState game = new GameVisual(mainGrid, NextStateClick);
        GameState end = new EndMenu(mainGrid, NextStateClick);
        gameState.nextState = game;
        game.nextState = end;
        end.nextState = gameState;

        gameState.Start();
    }
    private void NextStateClick(object? sender, RoutedEventArgs e)
    {
        gameState = gameState.NextState();
    }


}