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

        }

        internal void AddEntity(Control item)
        {
            if (item != null)
            {
                gridPanel.Controls.Add(item);
                item.Click += SelectItem;
            }
        }
        internal void RemoveEntity(Control item) => gridPanel.Controls.Remove(item);


        private bool Playing
        {
            get => gameGrid.IsFillUp();
        }

        internal void SelectItem(object? sender, EventArgs? args)
        {
            if (sender is Entity entity)
            {
                FlatStyle selectStyle = FlatStyle.Flat;
                FlatStyle unSelectStyle = FlatStyle.Standard;
                if (second == entity)
                {
                    second.FlatStyle = unSelectStyle;
                    second = null;
                }
                else if (first == entity)
                {
                    first.FlatStyle = unSelectStyle;
                    first = second;
                    second = null;
                }
                else
                {
                    if (first == null)
                    {
                        first = entity;
                        first.FlatStyle = selectStyle;
                    }
                    else
                    {
                        if (second == null)
                        {
                            second = entity;
                            second.FlatStyle = selectStyle;
                        }
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
