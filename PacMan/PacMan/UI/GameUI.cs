using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.UI
{
    class GameUI
    {
        public static void printOnConsole(char show)
        {
            Console.Write(show);
        }
        public static int menu()
        {
            while (true)
            {
                Console.WriteLine("1.New Game");
                Console.WriteLine("2.Resume");
                int opt = int.Parse(Console.ReadLine());
                if (opt > 0 && opt < 3)
                {
                    return opt;
                }
                else
                {
                    Console.WriteLine("Enter again");
                }

            }
        }
        public static void scoreshow(int score,int y,int x)
        {
            Console.SetCursorPosition(x, y);
            Console.Write($"Total Score: {score} ");
            

        }
    }
}
