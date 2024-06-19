using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EZInput;

namespace PacMan.GL
{
    class Pacman
    {
        private int X;
        private int Y;
        private int score;
        Grid mazeGrid;
        public Pacman(int X, int Y, Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.mazeGrid = mazeGrid;
        }
        public void remove()
        {
            mazeGrid.getMaze()[X, Y].setValue(' ');

            Console.SetCursorPosition(Y, X);
            Console.Write(' ');
        }
        public int getScore()
        {
            return score;
        }
        public void draw()
        {
            mazeGrid.getMaze()[X, Y].setValue('P');
            Console.SetCursorPosition(Y, X);
            Console.Write('P');
        }
        public void move()
        {
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                moveUp(mazeGrid.getMaze()[X,Y],mazeGrid.getUpCell(mazeGrid.getMaze()[X, Y]));
            }
            else if (Keyboard.IsKeyPressed(Key.DownArrow))
            {
                moveDown(mazeGrid.getMaze()[X, Y], mazeGrid.getDownCell(mazeGrid.getMaze()[X, Y]));

            }
            else if (Keyboard.IsKeyPressed(Key.LeftArrow))
            {

                moveLeft(mazeGrid.getMaze()[X, Y], mazeGrid.getLeftCell(mazeGrid.getMaze()[X, Y]));

            }
            else if (Keyboard.IsKeyPressed(Key.RightArrow))
            {
                moveRight(mazeGrid.getMaze()[X, Y], mazeGrid.getRightCell(mazeGrid.getMaze()[X, Y]));

            }
        }
        public void moveLeft(Cell current, Cell next)
        {
            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                Cell pre = mazeGrid.findPacman();
                remove();
                Cell Next = mazeGrid.getLeftCell(pre);
                if (Next.getValue() == '.')
                {
                    score++;
                }
                X = Next.getX();
                Y = Next.getY();
            }
        }
        public void moveRight(Cell current, Cell next)
        {
            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                Cell pre = mazeGrid.findPacman();
                remove();
                Cell Next = mazeGrid.getRightCell(pre);
                if (Next.getValue() == '.')
                {
                    score++;
                }
                X = Next.getX();
                Y = Next.getY();
            }
        }
        public void moveUp(Cell current, Cell next)
        {
            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                Cell pre = mazeGrid.findPacman();
                remove();
                Cell Next = mazeGrid.getUpCell(pre);
                if (Next.getValue() == '.')
                {
                    score++;
                }
                X = Next.getX();
                Y = Next.getY();
            }
        }
        public void moveDown(Cell current, Cell next)
        {
            if (next.getValue() == ' ' || next.getValue() == '.')
            {
                Cell pre = mazeGrid.findPacman();
                remove();
                Cell Next = mazeGrid.getDownCell(pre);
                if (Next.getValue() == '.')
                {
                    score++;
                }
                X = Next.getX();
                Y = Next.getY();
            }
        }




    }
}
