namespace Match3;

public class Bomb : BaseEntity
{
    private readonly Entity entity;
    public override Vector2 Position { get => entity.Position; }
    public override EntityColor EntityColor { get => entity.EntityColor; }

    public Bomb(Entity entity) : base(entity.Position, entity.EntityColor)
    {
        this.entity = entity;
    }

    public override void Action()
    {

    }

    public override string ToString()
        => $"{Position.Y},{Position.X}";
}
