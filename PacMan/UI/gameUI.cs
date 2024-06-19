using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.UI
{
    class gameUI
    {

        public static int menu()
        {
            while (true)
            {
                Console.WriteLine("************************");
                Console.WriteLine("          Pacman        ");
                Console.WriteLine("************************");
                Console.WriteLine("1.Start Game");
                int opt = int.Parse(Console.ReadLine());
                if (opt > 0 && opt < 2)
                {
                    return opt;
                }
                else
                {
                    Console.WriteLine("Enter again");
                }
            }
        }

        public static void scoreshow(int score, int y, int x)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"Total Score: {score} ");
        }
    }
}
