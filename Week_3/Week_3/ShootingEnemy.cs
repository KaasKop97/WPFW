using System;

namespace Week_3
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
            int bulletVel = 1;
            if (Ypos >= Console.WindowHeight / 2)
            {
                Shoot();
                bullet.Xpos = Xpos;
                bullet.Ypos = Ypos + bulletVel;
                bulletVel++;
            }
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