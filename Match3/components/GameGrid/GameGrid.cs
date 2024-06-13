namespace Match3.components
{
    internal class GameGrid
    {
        private Entity[,] grid;
        internal Entity? this[Vector2 position]
        {
            get => grid[position.Y, position.X];
        }
        internal Entity? this[int y, int x]
        {
            get => grid[y, x];
        }
        internal Size Size { get; private set; }
        internal int Height { get => Size.Height; }
        internal int Width { get => Size.Width; }

        private FigureFabric figureFabric;
        internal GameGrid(Size size, FigureFabric figureFabric)
        {
            this.grid = new Entity[size.Height, size.Width];
            this.figureFabric = figureFabric;
            this.Size = size;
        }
        internal void Clear()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GridActive(i, j))
                        grid[i, j].RemoveFromWin();
                }
            }
        }
        private bool GridActive(int y, int x)
        {
            if (grid[y, x] == null)
                return false;
            if (!grid[y, x].IsActivity)
                return false;
            return true;
        }
        private void FillUp()
        {
            int i = 0;
            for (int j = 0; j < Width; j++)
                if (!GridActive(i, j))
                {
                    grid[i, j] = figureFabric.Create(new Vector2(j, i));
                    grid[i, j].AddInWin();
                }
        }
        internal bool IsFillUp()
        {
            int j = 0;
            for (int i = 0; i < Width; i++)
                if (!GridActive(i, j))
                    return false;
            return true;
        }
        private void EntityFall()
        {
            for (int i = Height - 2; i >= 0; i--)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (!GridActive(i + 1, j) && GridActive(i, j))
                    {
                        grid[i + 1, j] = grid[i, j];
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
                        grid[i, j] = null;
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
                    }
                }
            }
        }
        internal void Update()
        {
            //System.Threading.Thread thread1 = new(FillUp);
            FillUp();
            //thread1.Start();
            //System.Threading.Thread thread2 = new(EntityFall);
            EntityFall();
            //thread2.Start();
        }

        internal void UpdateSizeAndLocationFigures(
            int sizeFigure, int border)
        {

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (GridActive(i, j))
                    {
                        grid[i, j].Size = new Size(sizeFigure, sizeFigure);
                        grid[i, j].Location = new Point(
                            border + j * (sizeFigure + border),
                            border + i * (sizeFigure + border)
                            );
                    }
                }
            }
        }
    }
}
