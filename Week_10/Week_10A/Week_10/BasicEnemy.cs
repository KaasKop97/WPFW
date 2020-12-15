using System;

namespace Week_10
{
    public class BasicEnemy : AbstractEnemy
    {
        public BasicEnemy()
        {
            Xpos = random.Next(0, Console.WindowWidth);
            Ypos = 0;
        }


        public override void Move()
        {
            Console.SetCursorPosition(Xpos, Ypos + 1);
            Console.Write("E");
            Ypos++;
            // Ypos - 1 is cleaning out the previous written E.
            Console.SetCursorPosition(Xpos, Ypos - 1);
            Console.Write(" ");
        }

        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}