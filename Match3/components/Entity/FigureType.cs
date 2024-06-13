using System;

namespace Match3.components
{
    internal enum FigureType
    {
        Red,
        Green,
        Blue,
        Yellow,
        Gray
    }
    internal static class FigureTypeRandom
    {
        static private Array value = Enum.GetValues(typeof(FigureType));
        static internal FigureType RandomType
        {
            get
            { 
                int length = value.Length;
                int random = Rand.Next(length);
                if (length == 0)
                    throw new ArgumentException("FigureType is empty");
                var val = value.GetValue(random);
                if (val is FigureType)
                    return (FigureType)val;
                else
                    throw new ArgumentException("RandomType is bad");
            }
        }

    }
}
