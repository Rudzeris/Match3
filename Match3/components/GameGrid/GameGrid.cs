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
                    grid[i, j] = null;
                }
            }
        }
        internal void Swap(Entity left, Entity right)
        {
            Entity temp = grid[left.Position.Y, left.Position.X];

            grid[left.Position.Y, left.Position.X]
                = grid[right.Position.Y, right.Position.X];

            grid[right.Position.Y, right.Position.X]
                = temp;

            Vector2 tempV = left.Position;
            left.Position = right.Position;
            right.Position = tempV;

        }

        private bool GridActive(int y, int x)
        {
            if(y<0 || y>=Height) 
                return false;
            if(x<0 || x>=Width) 
                return false;
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
                        Vector2 temp = grid[i, j].Position;
                        temp.Y++;
                        grid[i, j].Position = temp;

                        grid[i + 1, j] = grid[i, j];
#pragma warning disable CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
                        grid[i, j] = null;
#pragma warning restore CS8625 // Литерал, равный NULL, не может быть преобразован в ссылочный тип, не допускающий значение NULL.
                    }
                }
            }
        }
        internal int Check(Entity entity)
        {
            if (!GridActive(entity.Position.Y, entity.Position.X))
                return 0;
            int k = 0;
            int x, y;
            for(int i = 0; i<3; i++)
            {
                k = 0;
                for(int j = 0; j < 3; j++)
                {
                    y = entity.Position.Y;
                    x = entity.Position.X-i+j;
                    if (GridActive(y,x))
                    {
                        Entity temp = grid[y, x];
                        if (entity.FigureType == temp.FigureType)
                            k++;
                    }
                }
                if (k == 3)
                {
                    for (int j = 0; j < 3; j++)
                        grid[entity.Position.Y, 
                            entity.Position.X - i + j].RemoveFromWin();
                    return k;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                k = 0;
                for (int j = 0; j < 3; j++)
                {
                    y = entity.Position.Y - i + j;
                    x = entity.Position.X;
                    if (GridActive(y, x))
                    {
                        if (GridActive(y, x))
                        {
                            Entity temp = grid[y, x];
                            if (entity.FigureType == temp.FigureType)
                                k++;
                        }
                    }
                }
                if (k == 3)
                {
                    for (int j = 0; j < 3; j++)
                        grid[entity.Position.Y - i + j,
                            entity.Position.X].RemoveFromWin();
                    return k;
                }
            }
            return 0;
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
