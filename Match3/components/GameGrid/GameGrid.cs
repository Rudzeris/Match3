namespace Match3.components
{
    internal class GameGrid
    {
        private Entity[,] grid;
        internal Entity this[Vector2 position]
        {
            get => grid[position.Y, position.X];
        }
        public int Height { get; private set; }
        public int Width { get; private set; }

        private FigureFabric figureFabric;
        internal GameGrid(Size size,FigureFabric figureFabric)
        {
            this.grid = new Entity[size.Height, size.Width];
            this.figureFabric = figureFabric;
        }
        internal void Fill()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    grid[i, j] = figureFabric.Create(new Vector2(j, i));
                }
            }
        }
        internal void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    grid[i, j].AddInWin();
                }
            }
        }
    }
}
