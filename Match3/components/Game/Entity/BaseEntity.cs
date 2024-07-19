namespace Match3;

public class BaseEntity
{
    public Vector2 Position { get; private set; }
    public EntityType EntityType { get; init; }
    public BaseEntity(Vector2 position, EntityType entityType)
    {
        Position = position;
        EntityType = entityType;
    }
}
