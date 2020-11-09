using System;

namespace Week_3
{
    public abstract class AbstractEnemy
    {
        public int Xpos = Console.WindowWidth / 2;
        public int Ypos;
        public bool isAlive = true;
        public Bullet bullet;

        public Random random = new Random();

        public abstract void Move();

        public abstract void Shoot();
    }
}