using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using EZInput;
using System.IO;
using PacMan.BL;
using PacMan.UI;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "maze.txt";
            while (true)
            {
                Console.Clear();
                int option = gameUI.menu();

                if (option == 1)
                {
                    path = "maze.txt";
                }

                Console.Clear();

                grid mazeGrid = new grid(24, 71, path);

                pacman player = new pacman(9, 32, mazeGrid);

                ghost g1 = new ghost(15, 39, 'H', "Left", 1F, ' ', mazeGrid);
                ghost g2 = new ghost(20, 57, 'V', "Up", 1F, ' ', mazeGrid);
                ghost g3 = new ghost(19, 26, 'R', "Up", 1F, ' ', mazeGrid);
                ghost g4 = new ghost(5, 60, 'C', "Up", 1F, ' ', mazeGrid);

                List<ghost> enemies = new List<ghost>();
                enemies.Add(g1);
                enemies.Add(g2);
                enemies.Add(g3);
                enemies.Add(g4);

                mazeGrid.draw();
                g1.draw();
                g2.draw();
                g3.draw();
                g4.draw();
                player.draw();

                bool gameRunning = true;
                while (gameRunning)
                {
                    if (Keyboard.IsKeyPressed(Key.Escape))
                    {
                        gameRunning = false;
                        path = "mazeContinue.txt";
                        
                    }

                    Thread.Sleep(100);

                    gameUI.scoreshow(player.getScore(), 1, 80);
                    player.move();
                    player.draw();
                    

                    foreach (var g in enemies)
                    {
                        g.move();
                        g.draw();
                    }
                }
            }
        }
    }
}
