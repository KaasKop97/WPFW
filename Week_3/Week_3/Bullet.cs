using System;

namespace Week_3
{
    public class Bullet
    {
        public int Xpos;
        public int Ypos;

        public int bulletVel = 1;


        public void Move()
        {
            Console.SetCursorPosition(Xpos, Ypos + bulletVel);
            Console.Write("|");
            Ypos++;
            bulletVel += 2;
        }
    }
}