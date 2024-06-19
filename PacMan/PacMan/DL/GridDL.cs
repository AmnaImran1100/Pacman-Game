using PacMan.GL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.DL
{
    class GridDL
    {
        public static Cell[,] readData(string path)
        {
            Cell[,] maze = new Cell[24, 71];
            StreamReader fp = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int col = 0; col < 71; col++)
                {
                    Cell c = new Cell(record[col], row, col);
                    maze[row, col] = c;



                }
                row++;
            }
            return maze;

            fp.Close();
        }
        
    }
}
