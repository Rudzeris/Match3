using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    private readonly IGameGrid GameGrid;
    public Score Score => _engine.Score;
    private Label _label;
    private ButtonBase[,] buttons;

    private Size defaultSize;
    private Brush defaultColor;
    private Size selectSize;
    private Brush selectColor;

    public GameVisual(Panel panel, RoutedEventHandler routedEventHandler) : base(panel)
    {


        defaultSize = new Size(40, 40);
        selectSize = new Size(20, 20);

        defaultColor = Brushes.White;
        selectColor = Brushes.Red;

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


        // GameEngine
        _engine = new GameEngine(this);
        this.GameGrid = _engine.GameGrid;

        // Buttons
        buttons = new ButtonBase[GameGrid.Y, GameGrid.X];


        for (int i = 0; i < GameGrid.Y; i++)
        {
            for (int j = 0; j < GameGrid.X; j++)
            {
                buttons[i, j] = new Button();
                buttons[i, j].Height = defaultSize.Height;
                buttons[i, j].Width = defaultSize.Width;
                _gameGrid.Children.Add(buttons[i, j]);
                Grid.SetRow(buttons[i, j], i);
                Grid.SetColumn(buttons[i, j], j);
                buttons[i, j].Click += ButtonClick;
            }
        }
    }


    public override void Start()
    {
        panel.Children.Add(_mainPanel);
        _engine.Start();
        foreach (var button in buttons)
        {
            button.Height = defaultSize.Height;
            button.Width = defaultSize.Width;
        }

    }

    public override void Stop()
    {
        panel.Children.Remove(_mainPanel);
    }

    public override void Update()
    {
        VisualGameGrid();
    }

    private void VisualGameGrid()
    {
        for (int i = 0; i < GameGrid.Y; i++)
        {
            for (int j = 0; j < GameGrid.X; j++)
            {
                if (GameGrid[i, j] is BaseEntity entity && entity!=null)
                {
                    Brush brush = ColorForButton.GetColor(entity.EntityColor);
                    buttons[i, j].Background = brush;
                    buttons[i, j].Content = GameGrid[i,j];
                }
            }
        }
    }
    public void ButtonClick(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            Vector2 position = new Vector2(Grid.GetColumn(button), Grid.GetRow(button));
            _engine.Click(position);
        }
    }

    public void Select(Vector2 position)
    {
        buttons[position.Y, position.X].Height = selectSize.Height;
        buttons[position.Y, position.X].Width = selectSize.Width;
    }

    public void UnSelect(Vector2 position)
    {
        buttons[position.Y, position.X].Height = defaultSize.Height;
        buttons[position.Y, position.X].Width = defaultSize.Width;
    }
    protected override void InfoForNextState()
    {
        base.InfoForNextState();

        if (nextState is EndMenu ending)
        {
            ending.Score = Score;
        }
    }

    public void Swap(Vector2 left, Vector2 right)
    {
        Vector2 direction = left - right;
    }

    public override string ToString()
        => "Game";
}
