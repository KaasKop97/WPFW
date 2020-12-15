using System;

namespace Week_10
{
    public class ShootingEnemy : AbstractEnemy
    {
        public ShootingEnemy()
        {
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
            bullet = new Bullet();
        }
    }
}