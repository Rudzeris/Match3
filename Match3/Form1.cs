global using System.Windows.Forms;
global using System.Drawing;

using Match3.components;
using System;

namespace Match3
{
    public partial class Form1 : Form
    {
        private State state;
        private GameGrid gameGrid;
        private FigureFabric figureFabric;
        private const int border = 10;

        private Entity? first;
        private Entity? second;

        private Timer timer;
        private int timerValue;
        private int gameTimeInSecond;

        private int SizeFigure
        {
            get => Math.Min(
                gridPanel.Height - border * (2 + gameGrid.Height),
                gridPanel.Width - border * (2 + gameGrid.Width))
                / Math.Max(gameGrid.Height, gameGrid.Width);
        }
        public Form1(int gameTimeInSecond)
        {
            timer = new Timer();
            timer.Tick += Update;
            timer.Interval = 100;

            this.gameTimeInSecond = gameTimeInSecond;
            InitializeComponent();
            gridPanel.Visible = false;
            scoreStatus.Text = "0";
        }
        private void Start()
        {
            first = second = null;
            state = new State();

            mainMenuPanel.Visible = false;
            gridPanel.Visible = true;

            timer.Start();

            timerValue = gameTimeInSecond * 1000 / timer.Interval;

            timerProgressStatus.Minimum = 0;
            timerProgressStatus.Maximum = timerValue;

            figureFabric = new FigureFabric(AddEntity, RemoveEntity);
            gameGrid = new GameGrid(new Size(8, 8), figureFabric);

            gameGrid.Clear();
        }

        private void Stop()
        {
            timerValue = 0;
            PrintTimer();
            timer.Stop();
            gridPanel.Visible = false;
            overPanel.Visible = true;
        }

        public void Update(object? sender, EventArgs? args)
        {
            PrintTimer();
            PrintScore();
            gameGrid.Update();
            UpdateSizeAndLocationFigures();
            if (timerValue <= 0)
                Stop();
            else
                timerValue--;
        }

        private void PrintTimer()
        {
            timerStatus.Text = $"Time: {timerValue * timer.Interval / 1000 + 1}";
            timerProgressStatus.Increment(timerValue - timerProgressStatus.Value);
        }
        private void PrintScore()
        {
            scoreStatus.Text = $"Score: {state.Score}";
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
                if (first != null && second != null)
                {
                    if (Vector2.TheNextCell(first.Position, second.Position))
                    {
                        gameGrid.Swap(first, second);

                        int a = gameGrid.Check(first);
                        a += gameGrid.Check(second);

                        if (a == 0)
                        {
                            gameGrid.Swap(first, second);
                            UpdateSizeAndLocationFigures();
                            this.Update();
                        }
                        else
                            state.Increment(a);

                        first.FlatStyle = unSelectStyle;
                        second.FlatStyle = unSelectStyle;
                        first = null;
                        second = null;

                    }
                }
            }
        }

        private void UpdateSizeAndLocationFigures()
        {

            gameGrid.UpdateSizeAndLocationFigures(SizeFigure, border);
        }

        private void PlayClick(object sender, EventArgs e)
        {
            Start();
        }

        private void OKClick(object sender, EventArgs e)
        {
            overPanel.Visible = false;
            mainMenuPanel.Visible = true;
        }
    }
}
