namespace Match3.components
{
    internal class FigureFabric
    {
        PrintInWindow add;
        RemoveInWindow remove;
        internal FigureFabric(PrintInWindow print, RemoveInWindow remove)
        {
            this.add = print;
            this.remove = remove;
        }

        internal Entity Create(Vector2 position)
        {
            Entity entity = new Figure(position,FigureType.Gray);
            entity.Add = add;
            entity.Remove = remove;
            entity.BackColor = Color.Gray;
            return entity;

        }
    }
}
