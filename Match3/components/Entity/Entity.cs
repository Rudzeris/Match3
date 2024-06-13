namespace Match3.components
{
    abstract internal class Entity : Control
    {
        internal PrintInWindow Add { get; set; }
        internal RemoveInWindow Remove { get; set; }
        internal FigureType FigureType { get; set; }
        internal Vector2 Position { get; }

        internal Entity(Vector2 position, FigureType figureType)
        {
            this.Position = position;
            this.FigureType = figureType;
        }
        internal void AddInWin() => Add(this);
        internal void RemoveFromWin() => Remove(this);
        
    }
}
