using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Match3;

class EndMenu : GameState
{
    private Grid grid;
    private Button button;
    private Label mainText;
    private Label score;
    public Score Score {
        set
        {
            score.Content = $"_score: {value.Value}\nMaxScore: {value.MaxValue}";
        }
    }
    public EndMenu(Panel panel, RoutedEventHandler routedEventHandler) : base(panel)
    {
        // Grid
        grid = new Grid();
        grid.Background = Brushes.Gray;
        for (int i = 0; i < 3; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }

        // Button
        button = new Button { Content = "Ok" };
        button.Height = 40;
        button.Width = 90;
        grid.Children.Add(button);
        Grid.SetColumn(button, 1);
        Grid.SetRow(button, 1);
        button.Click += routedEventHandler;

        Panel stackPanel = new StackPanel();
        grid.Children.Add(stackPanel);
        Grid.SetColumnSpan(stackPanel, 3);
        // MainText
        mainText = new Label
        {
            Content = @"( -__-)/ You Lose \(-__- )",
            FontSize = 20,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        stackPanel.Children.Add(mainText);
        // ScoreLabel
        score = new Label
        {
            Content = @"0",
            FontSize = 20,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
        };
        stackPanel.Children.Add(score);
        
    }

    public override void Start()
    {
        panel.Children.Add(grid);
    }

    public override void Stop()
    {
        panel.Children.Remove(grid);
    }

    public override void Update()
    {

    }

    public override string ToString()
     => "End";
    
}
