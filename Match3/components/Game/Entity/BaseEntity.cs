namespace Match3;

public abstract class BaseEntity
{
    public bool IsDeleted { get; private set; }
    public virtual Vector2 Position { get; private set; }
    public virtual EntityColor EntityColor { get; init; }

    public BaseEntity(Vector2 position, EntityColor entityColor)
    {
        Position = position;
        EntityColor = entityColor;
        IsDeleted = false;
    }

    public abstract void Action();

    public abstract override string ToString();
}
