namespace Match3;

public abstract class BaseEntity
{
    public bool IsDeleted { get; private set; }
    public virtual Vector2 Position { get; set; }
    public virtual EntityColor EntityColor { get; init; }

    public BaseEntity(Vector2 position, EntityColor entityColor)
    {
        Position = position;
        EntityColor = entityColor;
        IsDeleted = false;
    }

    public void SetPosition(int Y,int X)
        => Position = new Vector2(X,Y);

    public abstract void Action();

    public abstract override string ToString();
}
