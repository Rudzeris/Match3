using System;

namespace Match3.components
{
    internal static class Rand
    {
        private static Random rnd = new Random();
        public static int Next(int start, int end)
            => rnd.Next(start, end);
        public static int Next(int end)
            => rnd.Next(end);
    }
}
