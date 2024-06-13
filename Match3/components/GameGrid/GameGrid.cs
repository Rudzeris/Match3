namespace Match3.components
{
    internal class GameGrid
    {
        private Entity[,] grid;
        internal Entity this[Vector2 position]
        {
            get => grid[position.Y, position.X];
        }
        internal Entity this[int y, int x]
        {
            get => grid[y, x];
        }
        internal Size Size { get; private set; }
        internal int Height { get => Size.Height; }
        internal int Width { get => Size.Width; }

        private FigureFabric figureFabric;
        internal GameGrid(Size size,FigureFabric figureFabric)
        {
            this.grid = new Entity[size.Height, size.Width];
            this.figureFabric = figureFabric;
            this.Size = size;
        }
        internal void Fill()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (grid[i,j] == null ? true : !grid[i,j].IsActivity)
                        grid[i, j] = figureFabric.Create(new Vector2(j, i));
                }
            }
        }
        internal void FillUp()
        {
            int j = 0;
            for(int i = 0;i < Width; i++)
                if (grid[i, j] == null ? true : !grid[i, j].IsActivity)
                    grid[i, j] = figureFabric.Create(new Vector2(j, i));
        }
        internal void AddInForm()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if(grid[i,j].IsActivity)
                        grid[i, j].AddInWin();
                }
            }
        }
    }
}
