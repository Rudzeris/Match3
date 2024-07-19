namespace Match3;

public static class Rnd
{
    private static Random rnd = new Random();
    public static int Next(int value) => rnd.Next(value);
    public static int Next(int minValue, int maxValue) => rnd.Next(minValue, maxValue);

}
