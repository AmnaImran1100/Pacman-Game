using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PacMan.BL;

namespace PacMan.DL
{
    class gridDL
    {
        public static cell[,] readData(string path)
        {
            cell[,] maze = new cell[24, 71];
            StreamReader fp = new StreamReader(path);
            string record;
            int row = 0;
            while ((record = fp.ReadLine()) != null)
            {
                for (int col = 0; col < 71; col++)
                {
                    cell c = new cell(record[col], row, col);
                    maze[row, col] = c;
                }
                row++;
            }
            fp.Close();
            return maze;
        }

    }
}
