namespace Match3.components
{
    abstract internal class Entity : Button
    {
        internal PrintInWindow? Add { get; set; }
        internal RemoveInWindow? Remove { get; set; }
        internal FigureType FigureType { get; set; }
        internal Vector2 Position { get; set; }
        internal bool IsActivity { get; private set; }

        internal Entity(Vector2 position, FigureType figureType)
        {
            this.Position = position;
            this.FigureType = figureType;
            this.IsActivity = true;
        }
        internal void AddInWin() { if (Add == null) return; Add(this); IsActivity = true;}
        internal void RemoveFromWin() { if (Remove == null) return; Remove(this); IsActivity = false;}
    }
}
