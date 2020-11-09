using System;
using System.Collections.Generic;

namespace Week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            List<AbstractEnemy> enemies = new List<AbstractEnemy>();
            enemies.Add(new BasicEnemy());
            enemies.Add(new EnemyLr());
            enemies.Add(new ShootingEnemy());
            Console.Clear();
            Console.CursorVisible = false;
            int currentEnemy = 0;
            while (player.Alive)
            {
                if (currentEnemy == enemies.Count)
                {
                    // We done here
                    Environment.Exit(0);
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("Lives: " + player.Lives);
                Console.SetCursorPosition(player.Xpos, Console.WindowHeight);
                Console.Write("P");
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(player.Xpos, Console.WindowHeight);
                Console.Write(" ");
                if (currentEnemy < enemies.Count && enemies[currentEnemy].isAlive)
                {
                    enemies[currentEnemy].Move();
                    if (currentEnemy == 2)
                    {
                        if (enemies[currentEnemy].Ypos == Console.WindowHeight / 2)
                        {
                            enemies[currentEnemy].Shoot();
                            enemies[currentEnemy].bullet.Xpos = enemies[currentEnemy].Xpos;
                            enemies[currentEnemy].bullet.Ypos = enemies[currentEnemy].Ypos;
                        }

                        if (enemies[currentEnemy].Ypos > Console.WindowHeight / 2)
                        {
                            enemies[currentEnemy].bullet.Move();
                            if (enemies[currentEnemy].bullet.Overlap(player.Xpos, Console.WindowHeight))
                            {
                                // Hit by bullet.
                                player.Hit();
                            }
                            enemies[currentEnemy].bullet.Move();
                        }
                    }

                    if (player.Overlap(enemies[currentEnemy].Xpos, enemies[currentEnemy].Ypos))
                    {
                        player.Hit();
                    }

                    if (enemies[currentEnemy].Ypos == Console.WindowHeight)
                    {
                        // They successfully evaded the enemy
                        if (currentEnemy != enemies.Count)
                        {
                            currentEnemy += 1;
                            Console.Clear();
                        }
                    }
                }

                if (!Console.KeyAvailable) continue;
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        player.Left();
                        break;
                    case ConsoleKey.RightArrow:
                        player.Right();
                        break;
                    case ConsoleKey.Q:
                        // To quit the game.
                        player.Alive = false;
                        break;
                }
            }
        }
    }
}