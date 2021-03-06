using System;

namespace Week_10
{
    public class Player
    {
        public int Xpos;
        public int Lives { get; private set; }

        public bool Alive = true;

        public Player()
        {
            Xpos = Console.WindowWidth / 2;
            Lives = 3;
        }

        public void Left()
        {
            Xpos = Math.Max(0, Xpos - 1);
        }

        public void Right()
        {
            Xpos = Math.Min(Console.WindowWidth, Xpos + 1);
        }

        public void Hit()
        {
            Lives -= 1;
            if (Lives < 1)
            {
                Alive = false;
            }
        }

        public bool Overlap(int xPosEnemy, int yPosEnemy)
        {
            // Player is always at Y pos of window height so we can just check that.
            if (xPosEnemy == Xpos && yPosEnemy == Console.WindowHeight)
            {
                return true;
            }

            return false;
        }
    }
}