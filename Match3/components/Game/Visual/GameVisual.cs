using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Match3;

public class GameVisual : GameState
{
    private GameEngine _engine;
    private Panel _mainPanel;
    private Grid _gameGrid;
    private Button _button;
    private ProgressBar _progressBar;
    private Grid _status;
    public Score Score => _engine.Score;
    private Label _label;
    public GameVisual(Panel panel, RoutedEventHandler routedEventHandler) : base(panel)
    {
        _engine = new GameEngine(this);

        // MainPanel
        Grid mainGrid = new Grid();
        _mainPanel = mainGrid;

        mainGrid.Background = Brushes.DarkCyan;

        mainGrid.RowDefinitions.Add(
            new RowDefinition()
            );
        mainGrid.RowDefinitions.Add(
            new RowDefinition()
            { Height = new GridLength(30) }
            );

        // StatusPanel
        _status = new Grid();
        _status.ColumnDefinitions.Add(
            new ColumnDefinition()
            { Width = GridLength.Auto }
            );
        _status.ColumnDefinitions.Add(
            new ColumnDefinition()
            );
        _status.ColumnDefinitions.Add(
            new ColumnDefinition()
            { Width = new GridLength(40) }
            );
        mainGrid.Children.Add(_status);
        Grid.SetRow(_status, 1);

        int column = 0;
        // Label
        _label = new Label();
        _label.FontSize = 12;
        _status.Children.Add(_label);
        Grid.SetColumn(_status, column++);

        // ProgressBar
        _progressBar = new ProgressBar();
        Grid.SetRow(_progressBar, 1);
        _status.Children.Add(_progressBar);
        _progressBar.Maximum = 60;
        Grid.SetColumn(_progressBar, column++);

        // Button
        _button = new Button { Content = "Click" };
        _button.Click += routedEventHandler;
        void a(object? sender, RoutedEventArgs e)
        {
            if (_progressBar.Value != 60)
            {
                _progressBar.Value++;
                Score.Value++;
                if (Rnd.Next(10) == 4)
                    Score.Value = 0;
            }
            else
            {
                _progressBar.Value = 0;
                routedEventHandler(sender, e);
            }
        };
        _status.Children.Add(_button);
        Grid.SetColumn(_button, column++);


        // GameGrid
        _gameGrid = new Grid();
        for (int i = 0; i < 8; i++)
        {
            _gameGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            _gameGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        }
        mainGrid.Children.Add(_gameGrid);


    }
    public override void Start()
    {
        panel.Children.Add(_mainPanel);
    }

    public override void Stop()
    {
        panel.Children.Remove(_mainPanel);
    }

    public override void Update()
    {

    }

    private void VisualGameGrid()
    {

    }
}
