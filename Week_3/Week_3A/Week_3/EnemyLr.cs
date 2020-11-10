using System;

namespace Week_3
{
    public class EnemyLr : AbstractEnemy
    {
        public EnemyLr()
        {
            Xpos = random.Next(3, Console.WindowWidth);
            Ypos = 1;
        }
        public override void Move()
        {
            Ypos++;
            int test = random.Next(0, 1000);
            if (test <= 499)
            {
                Xpos++;
            }
            else
            {
                Xpos--;
            }
            Console.SetCursorPosition(Xpos + 1, Ypos + 1);
            Console.Write("E");
            // Ypos - 1 is cleaning out the previous written E.
            // -1 ArgumentOutOfRangeException
            Console.SetCursorPosition(Xpos - 1, Ypos - 1);
            Console.Write(" ");
        }
        
        public override void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}