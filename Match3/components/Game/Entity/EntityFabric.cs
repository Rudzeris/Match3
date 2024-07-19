namespace Match3;

public static class EntityFabric
{
    public static BaseEntity RandomCreate(Vector2 position)
    => new BaseEntity(position, (EntityType)Rnd.Next(5));

}
