using System;

namespace Match3.components
{
    internal class FigureFabric
    {
        private PrintInWindow add;
        private RemoveInWindow remove;


        internal FigureFabric(PrintInWindow print, RemoveInWindow remove)
        {
            this.add = print;
            this.remove = remove;
        }

        private Color GetColor(FigureType type) =>
            type switch
            {
                FigureType.Blue => Color.Blue,
                FigureType.Red => Color.Red,
                FigureType.Green => Color.Green,
                FigureType.Yellow => Color.Yellow,
                FigureType.Gray => Color.Gray,
                _ => Color.Black
            };

        internal Entity Create(Vector2 position)
        {
            
            Entity entity = new Figure(position,FigureTypeRandom.RandomType);
            entity.Add = add;
            entity.Remove = remove;
            entity.BackColor = GetColor(entity.FigureType);
            return entity;

        }
    }
}
