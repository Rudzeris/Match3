namespace Match3;

public static class EntityFabric
{
    public static BaseEntity RandomCreate(Vector2 position)
    => new Entity(position, (EntityColor)Rnd.Next(5));

}
