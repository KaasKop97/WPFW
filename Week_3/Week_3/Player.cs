using System;

namespace Week_3
{
    public class Player
    {
        public int Xpos;

        public Player()
        {
            Xpos = Console.WindowWidth / 2;
        }

        public void Left()
        {
            Xpos = Math.Max(0, Xpos - 1);
        }

        public void Right()
        {
            Xpos = Math.Min(Console.WindowWidth, Xpos + 1);
        }
    }
}