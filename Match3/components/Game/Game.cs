using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Match3;

public class Game : GameState
{
    private Panel mainPanel;
    private Grid gameGrid;
    private Button button;
    private ProgressBar progressBar;
    private Grid status;
    private Score score;
    private Label label;
    public Game(Panel panel, RoutedEventHandler routedEventHandler) : base(panel)
    {

        // MainPanel
        Grid mainGrid = new Grid();
        mainPanel = mainGrid;

        mainGrid.Background = Brushes.DarkCyan;

        mainGrid.RowDefinitions.Add(
            new RowDefinition()
            );
        mainGrid.RowDefinitions.Add(
            new RowDefinition()
            { Height = new GridLength(30) }
            );

        // StatusPanel
        status = new Grid();
        status.ColumnDefinitions.Add(
            new ColumnDefinition()
            { Width = GridLength.Auto }
            );
        status.ColumnDefinitions.Add(
            new ColumnDefinition()
            );
        status.ColumnDefinitions.Add(
            new ColumnDefinition()
            { Width = new GridLength(40) }
            );
        mainGrid.Children.Add(status);
        Grid.SetRow(status, 1);

        int column = 0;
        // Label
        label = new Label();
        label.FontSize = 12;
        status.Children.Add(label);
        Grid.SetColumn(status, column++);

        // Score
        score = new Score(label);

        // ProgressBar
        progressBar = new ProgressBar();
        Grid.SetRow(progressBar, 1);
        status.Children.Add(progressBar);
        progressBar.Maximum = 60;
        Grid.SetColumn(progressBar, column++);

        // Button
        button = new Button { Content = "Click" };
        button.Click += (object? sender, RoutedEventArgs e) =>
        {
            if (progressBar.Value != 60)
            {
                progressBar.Value++;
                score.Value++;
                if(Rnd.Next(10) == 4)
                    score.Value = 0;
            }
            else
            {
                progressBar.Value = 0;
                routedEventHandler(sender, e);
            }
        };
        status.Children.Add(button);
        Grid.SetColumn(button, column++);


        // GameGrid
        gameGrid = new Grid();
        for (int i = 0; i < 8; i++)
        {
            gameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        mainGrid.Children.Add(gameGrid);


    }
    public override void Start()
    {
        panel.Children.Add(mainPanel);
    }

    public override void Stop()
    {
        panel.Children.Remove(mainPanel);
    }

    public override void Update()
    {

    }
}
