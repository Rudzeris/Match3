using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Match3.components
{
    abstract internal class Entity : Control
    {
        internal FigureType figureType {  get; set; }
        internal Vector2 position { get; }

        internal Entity(Vector2 position, FigureType figureType)
        {
            this.position = position;
            this.figureType = figureType;
        }
    }
}
