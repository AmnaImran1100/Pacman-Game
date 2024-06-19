using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GL
{
    class Cell
    {
        private char value;
        private int x;
        private int y;
        public Cell(char value, int x, int y)
        {
            this.value = value;
            this.x = x;
            this.y = y;
        }
        public char getValue()
        {
            return value;
        }
        public void setValue(char value)
        {
            this.value = value;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public bool isPacmanPresent()
        {
            if (value == 'P')
            {
                return true;
            }
            return false;
        }
        public bool isGhostPresent(char ghostCharacter)
        {
            if (value == ghostCharacter)
            {
                return true;
            }
            return false;
        }
    }
}
