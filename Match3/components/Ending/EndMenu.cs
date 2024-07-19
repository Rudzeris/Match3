using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Match3;

class EndMenu : GameState
{
    private Grid grid;
    private Button button;
    public EndMenu(Panel panel, RoutedEventHandler routedEventHandler) : base(panel)
    {
        grid = new Grid();
        grid.Background = Brushes.Gray;
        for (int i = 0; i < 3; i++)
        {
            grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        grid.RowDefinitions[1].Height = new GridLength(30);
        grid.ColumnDefinitions[1].Width = new GridLength(80);

        button = new Button { Content = "You Win!\nGo back Menu" };
        grid.Children.Add(button);
        Grid.SetColumn(button, 1);
        Grid.SetRow(button, 1);

        button.Click += routedEventHandler;
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
}
