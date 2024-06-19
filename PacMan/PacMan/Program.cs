using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using PacMan.GL;
using PacMan.UI;
using EZInput;
using PacMan.DL;

namespace PacMan
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string path= "maze.txt";
            while (true)
            {
                Console.Clear();
                int option = GameUI.menu();
                if (option == 1)
                {
                    path = "maze.txt";
                }
                else if (option == 2)
                {
                    path = "mazeContinue.txt";

                }
                Console.Clear();
                Grid mazeGrid = new Grid(24, 71, path);
                Pacman player = new Pacman(9, 32, mazeGrid);
                Ghost g1 = new Ghost(15, 39, 'H', "Left", 1F, ' ', mazeGrid);
                Ghost g2 = new Ghost(20, 57, 'V', "Up", 1F, ' ', mazeGrid);
                Ghost g3 = new Ghost(19, 26, 'R', "Up", 1F, ' ', mazeGrid);
                Ghost g4 = new Ghost(5, 60, 'C', "Up", 1F, ' ', mazeGrid);
                List<Ghost> enemies = new List<Ghost>();
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
                       // GridDL.Store(path);
                    }
                    
                    Thread.Sleep(100);
                   
                    GameUI.scoreshow(player.getScore(), 5,80);
                    player.move();
                    player.draw();
                    //if (mazeGrid.isStoppingCondition(enemies))
                    //{
                    //    gameRunning = false;
                    //    break;
                    //}
                   
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
