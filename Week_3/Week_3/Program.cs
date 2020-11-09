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
                }
            }
        }
    }
}