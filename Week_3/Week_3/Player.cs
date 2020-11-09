using System;

namespace Week_3
{
    public class Player
    {
        public int x;

        public Player()
        {
            x = Console.WindowWidth / 2;
        }

        public void left()
        {
            x = Math.Max(0, x - 1);
        }

        public void right()
        {
            x = Math.Min(Console.WindowWidth, x + 1);
        }
    }
}