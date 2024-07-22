namespace Match3;

public static class EntityFabric
{
    public static BaseEntity GetEntity(Vector2 position)
    => new Entity(position, (EntityColor)Rnd.Next(5));
    public static BaseEntity GetEntity(int y, int x) => GetEntity(new Vector2(x, y));

}
