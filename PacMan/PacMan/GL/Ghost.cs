using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GL
{
    class Ghost
    {
        private int X;
        private int Y;
        private string ghostDirection;
        private char ghostCharacter;
        private float speed;
        private char previousItem;
        private float deltaChange;
        Grid mazeGrid;
        public Ghost(int X,int Y,char ghostCharacter,string ghostDirection,float speed,char previousItem,Grid mazeGrid)
        {
            this.X = X;
            this.Y = Y;
            this.ghostCharacter = ghostCharacter;
            this.ghostDirection = ghostDirection;
            this.speed = speed;
            this.mazeGrid = mazeGrid;
            this.previousItem = previousItem;
           

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
            mazeGrid.getMaze()[X, Y].setValue(previousItem);

            Console.SetCursorPosition(Y, X);
            Console.Write(previousItem);
        }
        public void draw()
        {
            
            mazeGrid.getMaze()[X, Y].setValue(ghostCharacter);
            Console.SetCursorPosition(Y, X);
            Console.Write(ghostCharacter);
        }
        public char GetCharacter()
        {
            return ghostCharacter;
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
                if (ghostCharacter == 'H')
                {
                    moveHorizontal();
                    setDeltaZero();

                }
                else if(ghostCharacter == 'V')
                {
                    moveVertically();
                    setDeltaZero();

                }
                else if (ghostCharacter == 'R')
                {
                    moveRandom();
                    setDeltaZero();

                }
                else if (ghostCharacter == 'C')
                {
                    smartMovement();
                    setDeltaZero();

                }
            }
        } 
        public void moveHorizontal()
        {


            if (ghostDirection == "Left" )
            {
                Cell pre = mazeGrid.findGhost(ghostCharacter);
                while (pre == null)
                {
                    Cell c = new Cell(ghostCharacter, X, Y);
                    mazeGrid.getLeftCell(c).setValue(ghostCharacter);
                    //mazeGrid.getMaze()[X, Y - 1].setValue(ghostCharacter);
                    pre = mazeGrid.findGhost(ghostCharacter);
                }
                remove();
                Cell next = mazeGrid.getLeftCell(pre);
                previousItem = next.getValue();
                X = next.getX();
                Y = next.getY();
                if (Y == 3)
                {
                    ghostDirection = "Right";
                }
                
            }
            else if(ghostDirection == "Right")
            {
                if (Y == 67 || mazeGrid.getMaze()[X, Y + 2].getValue() == '|')
                {
                    ghostDirection = "Left";
                }
                if( mazeGrid.getLeftCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '|')
                {
                    Cell pre = mazeGrid.findGhost(ghostCharacter);
                    while (pre == null)
                    {
                        Cell c = new Cell(ghostCharacter, X, Y);
                        mazeGrid.getLeftCell(c).setValue(ghostCharacter);
                        //mazeGrid.getMaze()[X, Y - 1].setValue(ghostCharacter);
                        pre = mazeGrid.findGhost(ghostCharacter);
                    }
                    remove();
                    Cell next = mazeGrid.getRightCell(pre);
                    previousItem = next.getValue();
                    X = next.getX();
                    Y = next.getY();
                }
                
            }
            

           


        }
        public void moveVertically()
        {
            if (ghostDirection == "Up" )
            {
                Cell pre = mazeGrid.findGhost(ghostCharacter);
                while (pre == null)
                {
                    Cell c = new Cell(ghostCharacter, X, Y);
                    mazeGrid.getUpCell(c).setValue(ghostCharacter);
                    //mazeGrid.getMaze()[X, Y - 1].setValue(ghostCharacter);
                    pre = mazeGrid.findGhost(ghostCharacter);
                }
                remove();
                Cell next = mazeGrid.getUpCell(pre);
                previousItem = next.getValue();
                X = next.getX();
                Y = next.getY();
                if (X == 1)
                {
                    ghostDirection = "Down";
                }
            }
            else if(ghostDirection=="Down")
            {
                if (X == 22)
                {
                    ghostDirection = "Up";
                }
                else
                {
                    Cell pre = mazeGrid.findGhost(ghostCharacter);
                    while (pre == null)
                    {
                        Cell c = new Cell(ghostCharacter, X, Y);
                        mazeGrid.getDownCell(c).setValue(ghostCharacter);
                        //mazeGrid.getMaze()[X, Y - 1].setValue(ghostCharacter);
                        pre = mazeGrid.findGhost(ghostCharacter);
                    }
                    remove();
                    Cell next = mazeGrid.getDownCell(pre);
                    previousItem = next.getValue();
                    X = next.getX();
                    Y = next.getY();
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
                if (mazeGrid.getMaze()[X, Y - 1].getValue() == ' ' || mazeGrid.getMaze()[X, Y - 1].getValue() == '.' || mazeGrid.getMaze()[X, Y - 1].getValue() == 'P')
                {
                    Cell pre = mazeGrid.findGhost(ghostCharacter);
                    while (pre == null)
                    {
                        //mazeGrid.getMaze()[X, Y - 1].setValue(ghostCharacter);
                        Cell c = new Cell(ghostCharacter, X, Y);
                        mazeGrid.getLeftCell(c).setValue(ghostCharacter);
                        pre = mazeGrid.findGhost(ghostCharacter);
                    }
                    remove();
                    Cell next = mazeGrid.getLeftCell(pre);
                    previousItem = next.getValue();
                    X = next.getX();
                    Y = next.getY();
                }
            }
            else if (value == 2)
            {
                if (mazeGrid.getMaze()[X - 1, Y].getValue() == ' ' || mazeGrid.getMaze()[X - 1, Y].getValue() == '.' || mazeGrid.getMaze()[X - 1, Y].getValue() == 'P')
                {
                    Cell pre = mazeGrid.findGhost(ghostCharacter);
                    while (pre == null)
                    {
                        //mazeGrid.getMaze()[X - 1, Y].setValue(ghostCharacter);
                        Cell c = new Cell(ghostCharacter, X, Y);
                        mazeGrid.getUpCell(c).setValue(ghostCharacter);
                        pre = mazeGrid.findGhost(ghostCharacter);
                    }
                    remove();
                    Cell next = mazeGrid.getUpCell(pre);
                    previousItem = next.getValue();
                    X = next.getX();
                    Y = next.getY();
                }
            }
            else if (value == 3)
            {
                //right
                if (mazeGrid.getMaze()[X, Y + 1].getValue() == ' ' || mazeGrid.getMaze()[X, Y + 1].getValue() == '.' || mazeGrid.getMaze()[X, Y + 1].getValue() == 'P')
                {
                    Cell pre = mazeGrid.findGhost(ghostCharacter);
                    while (pre == null)
                    {
                        // mazeGrid.getMaze()[X , Y+1].setValue(ghostCharacter);
                        Cell c = new Cell(ghostCharacter, X, Y);
                        mazeGrid.getRightCell(c).setValue(ghostCharacter);
                        pre = mazeGrid.findGhost(ghostCharacter);
                    }
                    remove();
                    Cell next = mazeGrid.getRightCell(pre);
                    previousItem = next.getValue();
                    X = next.getX();
                    Y = next.getY();
                }
            }
            else if(value==4)
            {

                if (mazeGrid.getMaze()[X + 1, Y].getValue() == ' ' || mazeGrid.getMaze()[X + 1, Y].getValue() == '.' || mazeGrid.getMaze()[X + 1, Y].getValue() == 'P')
                {
                    Cell pre = mazeGrid.findGhost(ghostCharacter);
                    while (pre == null)
                    {
                        //mazeGrid.getMaze()[X+1, Y ].setValue(ghostCharacter);
                        Cell c = new Cell(ghostCharacter, X, Y);
                        mazeGrid.getDownCell(c).setValue(ghostCharacter);
                        pre = mazeGrid.findGhost(ghostCharacter);
                    }
                    remove();
                    Cell next = mazeGrid.getDownCell(pre);
                    previousItem = next.getValue();
                    X = next.getX();
                    Y = next.getY();
                }
            }

        }
        public void smartMovement()
        {
            double[] distance = new double[4] { 1000000, 1000000, 1000000, 1000000 };
            if (mazeGrid.getLeftCell(mazeGrid.findGhost(ghostCharacter)).getValue()!= '|' && mazeGrid.getLeftCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '%')
            {
                distance[0] = (calculateDistance(mazeGrid.getLeftCell(mazeGrid.findGhost(ghostCharacter)), mazeGrid.findPacman()));
            }
            if (mazeGrid.getRightCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '|' && mazeGrid.getRightCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '%')
            {
                distance[1] = (calculateDistance(mazeGrid.getRightCell(mazeGrid.findGhost(ghostCharacter)), mazeGrid.findPacman()));
            }
            if (mazeGrid.getDownCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '|' && mazeGrid.getDownCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '%' && mazeGrid.getRightCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '#')
            {
                distance[2] = (calculateDistance(mazeGrid.getDownCell(mazeGrid.findGhost(ghostCharacter)), mazeGrid.findPacman()));
            }
            if (mazeGrid.getUpCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '|' && mazeGrid.getUpCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '%' && mazeGrid.getUpCell(mazeGrid.findGhost(ghostCharacter)).getValue() != '#')
            {
                distance[3] = (calculateDistance(mazeGrid.getUpCell(mazeGrid.findGhost(ghostCharacter)), mazeGrid.findPacman()));
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
                moveVertically();
            }
            else
            {
                ghostDirection = "Up";
                moveVertically();
                
            }
                

        }
        public double calculateDistance(Cell current, Cell Pacman)
        {
           return Math.Sqrt(Math.Pow((current.getX() - Pacman.getX()), 2) + Math.Pow((current.getY() - Pacman.getY()), 2));

        }
        

    }
}
