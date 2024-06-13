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
        private const int border = 10;

        private Entity? first;
        private Entity? second;

        private Timer timer;

        private int SizeFigure
        {
            get => Math.Min(
                gridPanel.Height - border * (2 + gameGrid.Height),
                gridPanel.Width - border * (2 + gameGrid.Width))
                / Math.Max(gameGrid.Height, gameGrid.Width);
        }
        public Form1()
        {
            InitializeComponent();

           
            Start();
        }
        private void Start()
        {
            timer = new Timer();
            timer.Tick += Update;
            timer.Interval = 100;
            timer.Start();

            figureFabric = new FigureFabric(AddEntity, RemoveEntity);
            gameGrid = new GameGrid(new Size(8, 8), figureFabric);

            gameGrid.Clear();
        }

        private void Stop()
        {
            timer.Stop();
        }

        public void Update(object? sender, EventArgs? args)
        {
            gameGrid.Update();
            UpdateSizeAndLocationFigures();
            SelectEffect();
        }

        internal void AddEntity(Control item) => gridPanel.Controls.Add(item);
        internal void RemoveEntity(Control item) => gridPanel.Controls.Remove(item);

        private void SelectEffect()
        {
            int border2 = SizeFigure / 8;

            if (first != null)
            {
                first.Size = new Size(SizeFigure-border2, SizeFigure-border2);
                first.Location = new Point(
                    border+border2 + first.Position.X * (SizeFigure+border2 + border),
                    border+border2 + first.Position.Y * (SizeFigure+border2 + border)
                    );
            }
            if (second != null)
            {
                second.Size = new Size(SizeFigure - border2, SizeFigure - border2);
                second.Location = new Point(
                    border + border2 + second.Position.X * (SizeFigure + border2 + border),
                    border + border2 + second.Position.Y * (SizeFigure + border2 + border)
                    );
            }
        }

        private bool Playing
        {
            get => gameGrid.IsFillUp();
        }

        internal void SelectItem(object sender, EventArgs? args)
        {
            if (sender is Entity entity)
            {
                if (first == null)
                {
                    first = entity;
                }
                else
                {
                    if (second == null)
                    {
                        second = entity;
                    }
                }
            }
        }

        private void UpdateSizeAndLocationFigures()
        {

            gameGrid.UpdateSizeAndLocationFigures(SizeFigure, border);
        }

    }
}
