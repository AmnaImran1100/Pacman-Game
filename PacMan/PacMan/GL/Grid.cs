using PacMan.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GL
{
    class Grid
    {
        private Cell[,] maze;
        private int rowSize;
        private int colSize;
        public Grid(int rowSize, int colSize, string path)
        {
            this.rowSize = rowSize;
            this.colSize = colSize;
            maze = GridDL.readData(path);

        }
       
        public Cell getLeftCell(Cell c)
        {
            
            return maze[c.getX(), c.getY() - 1];
        }
        public Cell getRightCell(Cell c)
        {
            return maze[c.getX(), c.getY() + 1];

        }
        public Cell getUpCell(Cell c)
        {
            return maze[c.getX() - 1, c.getY()];

        }
        public Cell[,] getMaze()
        {
            return maze;
        }
        public Cell getDownCell(Cell c)
        {
            return maze[c.getX() + 1, c.getY()];

        }
        public Cell findPacman()
        {
            foreach (var storedCell in maze)
            {
                if (storedCell.isPacmanPresent())
                {
                    return storedCell;
                }
            }
            return null;

        }
        public Cell findGhost(char ghostCharacter)
        {
            foreach (var storedCell in maze)
            {
                if (storedCell.isGhostPresent(ghostCharacter))
                {
                    return storedCell;
                }
            }
            return null;
        }
        public bool isStoppingCondition(List<Ghost> enemy)
        {
            foreach (var ghostch in enemy)
            {
                if (findGhost(ghostch.GetCharacter()) == findPacman())
                {
                    return true;
                }
            }
            return false;
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
    }
}
