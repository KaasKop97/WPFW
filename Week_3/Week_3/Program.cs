using System;
using System.Collections.Generic;

namespace Week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            List<Enemy> enemies = new List<Enemy>();
            Console.Clear();
            Console.CursorVisible = false;
            while (player.Alive)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write("Lives: " + player.Lives);
                Console.SetCursorPosition(player.Xpos, Console.WindowHeight);
                Console.Write("P");
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(player.Xpos, Console.WindowHeight);
                Console.Write(" ");
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
