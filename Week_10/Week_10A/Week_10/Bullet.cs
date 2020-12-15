using System;

namespace Week_10
{
    public class Bullet
    {
        public int Xpos;
        public int Ypos;

        public int bulletVel = 1;


        public void Move()
        {
            Console.SetCursorPosition(Xpos, Ypos + 1);
            Console.Write("|");
            Ypos++;
            Console.SetCursorPosition(Xpos, Ypos - 1);
            Console.Write(" ");
        }

        public bool Overlap(int xPosPlayer, int yPosPlayer)
        {
            // Player is always at Y pos of window height so we can just check that.
            if (xPosPlayer == Xpos && yPosPlayer == Console.WindowHeight)
            {
                return true;
            }

            return false;
        }
    }
}