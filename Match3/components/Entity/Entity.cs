namespace Match3.components
{
    abstract internal class Entity : Control
    {
        internal PrintInWindow add { get; set; }
        internal DeleteInWindow remove { get; set; }
        internal FigureType FigureType { get; set; }
        internal Vector2 Position { get; }

        internal Entity(Vector2 position, FigureType figureType)
        {
            this.Position = position;
            this.FigureType = figureType;
        }
    }
}
