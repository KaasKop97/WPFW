using System;


namespace Week_3
{
    abstract class AbstractEnemy
    {
        public int Xpos;
        public int Ypos;
        public void move(){

        }

    }

    public class Enemy:AbstractEnemy{
        public Enemy(){
            Xpos = Math.random();
            Ypos = 0;
        }
    }

    public class EnemyLR:AbstractEnemy{
        public EnemyLR(){
            Xpos = Math.random();
            Ypos = 0;
        }

        public void left(){

        }

        public void right(){

        }
    }

    public class EnemyShoot:AbstractEnemy{
        public EnemyShoot(){
            Xpos = Math.random();
            Ypos = 0;
        }

        public void shoot(){
            
        }
    }
}