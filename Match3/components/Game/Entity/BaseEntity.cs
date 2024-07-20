namespace Match3;

public abstract class BaseEntity
{
    public Vector2 Position { get; private set; }
    public EntityColor EntityType { get; init; }
    public BaseEntity(Vector2 position, EntityColor entityType)
    {
        Position = position;
        EntityType = entityType;
    }

    public abstract void Action();
}
