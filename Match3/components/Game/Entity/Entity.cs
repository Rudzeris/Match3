namespace Match3;

public class Entity : BaseEntity
{
    public Entity(Vector2 position, EntityColor entityType) : base(position, entityType)
    {
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override string ToString()
        => $"{Position.Y},{Position.X}";
}
