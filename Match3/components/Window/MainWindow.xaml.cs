using System.Timers;
using System.Windows;

namespace Match3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private GameState gameState;
    private System.Timers.Timer timer;
    public MainWindow()
    {
        InitializeComponent();
        gameState = new GameStateCreator(mainGrid, NextStateClick);
        GameState.NextState(ref gameState);

        timer = new System.Timers.Timer();
        timer.Interval = 100;
        timer.Elapsed += (object? sender, ElapsedEventArgs e) =>
        {
            gameState.Update();
            this.UpdateDefaultStyle();
        };
    }
    private void NextStateClick(object? sender, RoutedEventArgs e)
    {
        GameState.NextState(ref gameState);
    }


}