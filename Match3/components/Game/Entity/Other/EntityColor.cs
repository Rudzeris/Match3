using System.Windows.Media;

namespace Match3;
public enum EntityColor
{
    Type1, Type2, Type3, Type4, Type5
}

public static class ColorForButton
{
    public static Brush GetColor(EntityColor? color)
        => color switch
        {
            EntityColor.Type1 => Brushes.Red,
            EntityColor.Type2 => Brushes.Green,
            EntityColor.Type3 => Brushes.Blue,
            EntityColor.Type4 => Brushes.Yellow,
            EntityColor.Type5 => new SolidColorBrush(Color.FromRgb(0x80,0x00,0x80)),
            _ => Brushes.White
        };
}