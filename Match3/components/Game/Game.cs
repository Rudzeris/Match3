using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Match3.components.Game
{
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

            mainPanel = mainGrid;
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
}
