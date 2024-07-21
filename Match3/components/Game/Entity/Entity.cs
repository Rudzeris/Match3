namespace Match3;

public class Entity : BaseEntity
{
    public Entity(Vector2 position, EntityColor entityType) : base(position, entityType)
    {
    }

    public override void Action()
    {
        // TODO: Запуск проверки
    }

    public override string ToString()
        => $"{Position.Y},{Position.X}";
}
