namespace Match3.components
{
    internal class FigureFabric
    {
        PrintInWindow add;
        DeleteInWindow remove;
        internal FigureFabric(PrintInWindow print, DeleteInWindow remove)
        {
            this.add = print;
            this.remove = remove;
        }

        internal Entity Create(Vector2 position)
        {

            Entity entity = new Figure(position,FigureType.Red);
            entity.add = add;
            entity.remove = remove;
            return entity;

        }
    }
}
