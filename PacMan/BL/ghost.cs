using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.BL
{
    class ghost
    {
        private int x;
        private int y;
        private char ghostChar;
        private string ghostDirection;
        private float speed;
        private char previousItem;
        private float deltaChange;
        grid mazeGrid;

        public ghost(int x, int y, char ghostChar, string ghostDirection, float speed, char previousItem, grid mazeGrid)
        {
            this.x = x;
            this.y = y;
            this.ghostChar = ghostChar;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.previousItem = previousItem;
            this.mazeGrid = mazeGrid;
        }

        public void setDirection(string ghostDirection)
        {
            this.ghostDirection = ghostDirection;
        }

        public string getDirection()
        {
            return ghostDirection;
        }

        public void remove()
        {
            mazeGrid.getMaze()[x, y].setValue(previousItem);
            Console.SetCursorPosition(y, x);
            Console.Write(previousItem);
        }

        public void draw()
        {
            mazeGrid.getMaze()[x, y].setValue(ghostChar);
            Console.SetCursorPosition(y, x);
            Console.Write(ghostChar);
        }

        public char getChar()
        {
            return ghostChar;
        }

        public void changeDelta()
        {
            deltaChange = deltaChange + speed;
        }

        public float getDelta()
        {
            return deltaChange;
        }

        public void setDeltaZero()
        {
            deltaChange = 0;
        }

        public void move()
        {
            changeDelta();
            
            if (Math.Floor(getDelta()) == 1)
            {
                if (ghostChar == 'H')
                {
                    moveHorizontal();
                    setDeltaZero();
                }             

                if (ghostChar == 'V')
                {
                    moveVertical();
                    setDeltaZero();
                }               

                if (ghostChar == 'R')
                {
                    moveRandom();
                    setDeltaZero();
                }               

                if (ghostChar == 'C')
                {
                    moveChasing();
                    setDeltaZero();
                }    
            }
        }

        public void moveHorizontal()
        {
            if (ghostDirection == "Left")
            {
                cell pre = mazeGrid.findGhost(ghostChar);
                while (pre == null)
                {
                    cell c = new cell(ghostChar, x, y);
                    mazeGrid.getLeftCell(c).setValue(ghostChar);
                    pre = mazeGrid.findGhost(ghostChar);
                }
                remove();
                cell next = mazeGrid.getLeftCell(pre);
                previousItem = next.getValue();
                x = next.getX();
                y = next.getY();
                if (y == 3)
                {
                    ghostDirection = "Right";
                }

            }
            else if (ghostDirection == "Right")
            {
                if (y == 67 || mazeGrid.getMaze()[x, y + 2].getValue() == '|')
                {
                    ghostDirection = "Left";
                }
                if (mazeGrid.getLeftCell(mazeGrid.findGhost(ghostChar)).getValue() != '|')
                {
                    cell pre = mazeGrid.findGhost(ghostChar);
                    while (pre == null)
                    {
                        cell c = new cell(ghostChar, x, y);
                        mazeGrid.getLeftCell(c).setValue(ghostChar);
                        pre = mazeGrid.findGhost(ghostChar);
                    }
                    remove();
                    cell next = mazeGrid.getRightCell(pre);
                    previousItem = next.getValue();
                    x = next.getX();
                    y = next.getY();
                }

            }
        }

        public void moveVertical()
        {
            if (ghostDirection == "Up")
            {
                cell pre = mazeGrid.findGhost(ghostChar);
                while (pre == null)
                {
                    cell c = new cell(ghostChar, x, y);
                    mazeGrid.getUpCell(c).setValue(ghostChar);
                    pre = mazeGrid.findGhost(ghostChar);
                }
                remove();
                cell next = mazeGrid.getUpCell(pre);
                previousItem = next.getValue();
                x = next.getX();
                y = next.getY();
                if (x == 1)
                {
                    ghostDirection = "Down";
                }
            }
            else if (ghostDirection == "Down")
            {
                if (x == 22)
                {
                    ghostDirection = "Up";
                }
                else
                {
                    cell pre = mazeGrid.findGhost(ghostChar);
                    while (pre == null)
                    {
                        cell c = new cell(ghostChar, x, y);
                        mazeGrid.getDownCell(c).setValue(ghostChar);
                        pre = mazeGrid.findGhost(ghostChar);
                    }
                    remove();
                    cell next = mazeGrid.getDownCell(pre);
                    previousItem = next.getValue();
                    x = next.getX();
                    y = next.getY();
                }

            }
        }

        
        public int generateRandom()
        {
            Random r = new Random();
            int value = r.Next(4);
            return value;
        }

        public void moveRandom()
        {
            int value = generateRandom();
            if (value == 1)
            {
                if (mazeGrid.getMaze()[x, y - 1].getValue() == ' ' || mazeGrid.getMaze()[x, y - 1].getValue() == '.' || mazeGrid.getMaze()[x, y - 1].getValue() == 'P')
                {
                    cell pre = mazeGrid.findGhost(ghostChar);
                    while (pre == null)
                    {
                        cell c = new cell(ghostChar, x, y);
                        mazeGrid.getLeftCell(c).setValue(ghostChar);
                        pre = mazeGrid.findGhost(ghostChar);
                    }
                    remove();
                    cell next = mazeGrid.getLeftCell(pre);
                    previousItem = next.getValue();
                    x = next.getX();
                    y = next.getY();
                }
            }
            else if (value == 2)
            {
                if (mazeGrid.getMaze()[x - 1, y].getValue() == ' ' || mazeGrid.getMaze()[x - 1, y].getValue() == '.' || mazeGrid.getMaze()[x - 1, y].getValue() == 'P')
                {
                    cell pre = mazeGrid.findGhost(ghostChar);
                    while (pre == null)
                    {
                        cell c = new cell(ghostChar, x, y);
                        mazeGrid.getUpCell(c).setValue(ghostChar);
                        pre = mazeGrid.findGhost(ghostChar);
                    }
                    remove();
                    cell next = mazeGrid.getUpCell(pre);
                    previousItem = next.getValue();
                    x = next.getX();
                    y = next.getY();
                }
            }
            else if (value == 3)
            {
                if (mazeGrid.getMaze()[x, y + 1].getValue() == ' ' || mazeGrid.getMaze()[x, y + 1].getValue() == '.' || mazeGrid.getMaze()[x, y + 1].getValue() == 'P')
                {
                    cell pre = mazeGrid.findGhost(ghostChar);
                    while (pre == null)
                    {
                        cell c = new cell(ghostChar, x, y);
                        mazeGrid.getRightCell(c).setValue(ghostChar);
                        pre = mazeGrid.findGhost(ghostChar);
                    }
                    remove();
                    cell next = mazeGrid.getRightCell(pre);
                    previousItem = next.getValue();
                    x = next.getX();
                    y = next.getY();
                }
            }
            else if (value == 4)
            {

                if (mazeGrid.getMaze()[x + 1, y].getValue() == ' ' || mazeGrid.getMaze()[x + 1, y].getValue() == '.' || mazeGrid.getMaze()[x + 1, y].getValue() == 'P')
                {
                    cell pre = mazeGrid.findGhost(ghostChar);
                    while (pre == null)
                    {
                        cell c = new cell(ghostChar, x, y);
                        mazeGrid.getDownCell(c).setValue(ghostChar);
                        pre = mazeGrid.findGhost(ghostChar);
                    }
                    remove();
                    cell next = mazeGrid.getDownCell(pre);
                    previousItem = next.getValue();
                    x = next.getX();
                    y = next.getY();
                }
            }
        }

        public void moveChasing()
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (mazeGrid.getLeftCell(mazeGrid.findGhost(ghostChar)).getValue() != '|' && mazeGrid.getLeftCell(mazeGrid.findGhost(ghostChar)).getValue() != '%')
            {
                distance[0] = (calculateDistance(mazeGrid.getLeftCell(mazeGrid.findGhost(ghostChar)), mazeGrid.findPacman()));
            }
            if (mazeGrid.getRightCell(mazeGrid.findGhost(ghostChar)).getValue() != '|' && mazeGrid.getRightCell(mazeGrid.findGhost(ghostChar)).getValue() != '%')
            {
                distance[1] = (calculateDistance(mazeGrid.getRightCell(mazeGrid.findGhost(ghostChar)), mazeGrid.findPacman()));
            }
            if (mazeGrid.getDownCell(mazeGrid.findGhost(ghostChar)).getValue() != '|' && mazeGrid.getDownCell(mazeGrid.findGhost(ghostChar)).getValue() != '%' && mazeGrid.getRightCell(mazeGrid.findGhost(ghostChar)).getValue() != '#')
            {
                distance[2] = (calculateDistance(mazeGrid.getDownCell(mazeGrid.findGhost(ghostChar)), mazeGrid.findPacman()));
            }
            if (mazeGrid.getUpCell(mazeGrid.findGhost(ghostChar)).getValue() != '|' && mazeGrid.getUpCell(mazeGrid.findGhost(ghostChar)).getValue() != '%' && mazeGrid.getUpCell(mazeGrid.findGhost(ghostChar)).getValue() != '#')
            {
                distance[3] = (calculateDistance(mazeGrid.getUpCell(mazeGrid.findGhost(ghostChar)), mazeGrid.findPacman()));
            }
            if (distance[0] <= distance[1] && distance[0] <= distance[2] && distance[0] <= distance[3])
            {
                ghostDirection = "Left";
                moveHorizontal();

            }
            if (distance[1] <= distance[0] && distance[1] <= distance[2] && distance[1] <= distance[3])
            {
                ghostDirection = "Right";
                moveHorizontal();
            }
            if (distance[2] <= distance[0] && distance[2] <= distance[1] && distance[2] <= distance[3])
            {
                ghostDirection = "Down";
                moveVertical();
            }
            else
            {
                ghostDirection = "Up";
                moveVertical();

            }
        }

        public double calculateDistance(cell current, cell pacmanLocation)
        {
            return Math.Sqrt(Math.Pow((pacmanLocation.getX() - current.getX()), 2) + Math.Pow((pacmanLocation.getY() - current.getY()), 2));
        }

    }
}
