using System;

namespace Week_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Console.Clear();
            Console.CursorVisible = false;
            while (true)
            {
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write("P");
                System.Threading.Thread.Sleep(100);
                Console.SetCursorPosition(player.x, Console.WindowHeight);
                Console.Write(" ");
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key.Equals(ConsoleKey.J))
                    {
                        player.left();
                    }

                    if (key.Equals(ConsoleKey.K))
                    {
                        player.right();
                    }
                }
            }
        }
    }
}