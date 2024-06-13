global using System.Windows.Forms;
global using System.Drawing;

using Match3.components;
using System;

namespace Match3
{
    public partial class Form1 : Form
    {
        private GameGrid gameGrid;
        private FigureFabric figureFabric;
        private const int border = 1;

        private Timer timer;

        public Form1()
        {
            InitializeComponent();

            timer = new Timer();
            timer.Tick += Update;
            timer.Interval = 100;
            timer.Start();

            figureFabric = new FigureFabric(AddEntity, RemoveEntity);
            gameGrid = new GameGrid(new Size(8, 8), figureFabric);
            Start();
        }
        private void Start()
        {
            gameGrid.Fill();
            gameGrid.AddInForm();
        }

        public void Update(object? sender, EventArgs? args)
        {
            UpdateSizeAndLocationFigures();
        }

        internal void AddEntity(Control item) => gridPanel.Controls.Add(item);
        internal void RemoveEntity(Control item) => gridPanel.Controls.Remove(item);

        private void UpdateSizeAndLocationFigures()
        {
            int sizeFigure = Math.Min(
                gridPanel.Height - border * (2 + gameGrid.Height),
                gridPanel.Width - border * (2 + gameGrid.Width))
                / Math.Max(gameGrid.Height, gameGrid.Width);

            for (int i = 0; i < gameGrid.Height; i++)
            {
                for (int j = 0; j < gameGrid.Width; j++)
                {
                    gameGrid[i, j].Size = new Size(sizeFigure, sizeFigure);
                    gameGrid[i, j].Location = new Point(
                        border + j * (sizeFigure + border),
                        border + i * (sizeFigure + border)
                        );
                }
            }
        }

    }
}
