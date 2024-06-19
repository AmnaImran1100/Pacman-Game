using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PacMan.DL;

namespace PacMan.BL
{
    class grid
    {
        private cell[,] maze;
        private int rowSize;
        private int colSize;

        public grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = gridDL.readData(path);
        }

        public cell[,] getMaze()
        {
            return maze;
        }

        public cell getLeftCell(cell c)
        {
            int x = c.getX();
            int y = c.getY() - 1;
            return maze[x, y];
        }

        public cell getRightCell(cell c)
        {
            int x = c.getX();
            int y = c.getY() + 1;
            return maze[x, y];
        }

        public cell getUpCell(cell c)
        {
            int x = c.getX() - 1;
            int y = c.getY();
            return maze[x, y];
        }

        
        public cell getDownCell(cell c)
        {
            int x = c.getX() + 1;
            int y = c.getY();
            return maze[x, y];
        }

        public cell findPacman()
        {
            foreach (var cell in maze)
            {
                if (cell.isPacmanPresent())
                {
                    return cell;
                }
            }
            return null;

        }

        public cell findGhost(char ghostChar)
        {
            foreach (var cell in maze)
            {
                if (cell.isGhostPresent(ghostChar))
                {
                    return cell;
                }
            }
            return null;
        }

        public void draw()
        {
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize - 1; j++)
                {
                    Console.Write(maze[i, j].getValue());
                }
                Console.WriteLine();
            }
        }

        public bool isStoppingCondition(List<ghost> enemy)
        {
            foreach (var ghostch in enemy)
            {
                if (findGhost(ghostch.getChar()) == findPacman())
                {
                    return true;
                }
            }
            return false;
        }

    }
}
