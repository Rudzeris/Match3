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
        internal GameGrid(Size size)
        {
            grid = new Entity[size.Height, size.Width];
        }
        internal void Fill()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    grid[i, j] =
                        new Figure(
                            new Vector2(j, i),
                            FigureType.Red
                            );
                }
            }
        }
    }
}
