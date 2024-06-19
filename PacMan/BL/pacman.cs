using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace PacMan.BL
{
    class pacman
    {
        private int x;
        private int y;
        private int score;
        grid mazeGrid;

        public pacman(int x, int y, grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.mazeGrid = mazeGrid;
        }

        public void remove()
        {
            mazeGrid.getMaze()[x, y].setValue(' ');
            Console.SetCursorPosition(y, x);
            Console.Write(' ');
        }

        public void draw()
        {
            mazeGrid.getMaze()[x, y].setValue('P');
            Console.SetCursorPosition(y, x);
            Console.Write('P');
        }

        public void moveLeft(cell current, cell next)
        {
            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                cell previous = mazeGrid.findPacman();
                remove();
                cell n = mazeGrid.getLeftCell(previous);
                if(n.getValue() == '.')
                {
                    score++;
                }
                x = n.getX();
                y = n.getY();
            }
        }

        public void moveRight(cell current, cell next)
        {

            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                cell previous = mazeGrid.findPacman();
                remove();
                cell n = mazeGrid.getRightCell(previous);
                if (n.getValue() == '.')
                {
                    score++;
                }
                x = n.getX();
                y = n.getY();
            }
        }

        public void moveUp(cell current, cell next)
        {

            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                cell previous = mazeGrid.findPacman();
                remove();
                cell n = mazeGrid.getUpCell(previous);
                if (n.getValue() == '.')
                {
                    score++;
                }
                x = n.getX();
                y = n.getY();
            }
        }

        public void moveDown(cell current, cell next)
        {

            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                cell previous = mazeGrid.findPacman();
                remove();
                cell n = mazeGrid.getDownCell(previous);
                if (n.getValue() == '.')
                {
                    score++;
                }
                x = n.getX();
                y = n.getY();
            }
        }

        public void move()
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                cell current = mazeGrid.getMaze()[x, y];
                cell next = mazeGrid.getUpCell(current);
                moveUp(current, next);
            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                cell current = mazeGrid.getMaze()[x, y];
                cell next = mazeGrid.getDownCell(current);
                moveDown(current, next);
            }
            if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {
                cell current = mazeGrid.getMaze()[x,y];
                cell next = mazeGrid.getLeftCell(current);
                moveLeft(current, next);
            }
            if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                cell current = mazeGrid.getMaze()[x, y];
                cell next = mazeGrid.getRightCell(current);
                moveRight(current, next);
            }
        }

        public int getScore()
        {
            return score;
        }

    }
}
