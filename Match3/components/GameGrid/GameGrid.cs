using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3.components
{
    internal class GameGrid
    {
        private Entity[,] grid;
        internal GameGrid(Size size)
        {
            grid = new Entity[size.Height, size.Width];
        }
    }
}
