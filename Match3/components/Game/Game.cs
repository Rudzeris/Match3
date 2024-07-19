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
                { Height = new GridLength(20, GridUnitType.Pixel) }
                );

            // StatusPanel
            status = new Grid();
            status.ColumnDefinitions.Add(
                new ColumnDefinition()
                { Width = new GridLength(80) }
                );
            status.ColumnDefinitions.Add(
                new ColumnDefinition()
                );
            status.ColumnDefinitions.Add(
                new ColumnDefinition()
                { Width = new GridLength(40) }
                );
            mainGrid.Children.Add( status );
            Grid.SetRow(status, 1);

            // ProgressBar
            progressBar = new ProgressBar();
            Grid.SetRow(progressBar, 1);
            status.Children.Add(progressBar);
            progressBar.Maximum = 60;
            Grid.SetColumn(progressBar, 1);

            // Button
            button = new Button { Content = "Click" };
            button.Click += (object? sender,RoutedEventArgs e)=>
            {
                if(progressBar.Value != 60)
                progressBar.Value++;
                else
                {
                    progressBar.Value = 0;
                    routedEventHandler(sender, e);
                }
            };
            status.Children.Add(button);
            Grid.SetColumn(button, 2);

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
