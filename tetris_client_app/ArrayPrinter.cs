using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetrisCient
{
    class ArrayPrinter
    {
        public const int Y_DIMENSION = 16;
        public const int X_DIMENSION = 10;

        public void Print(string[,] a)
        {
            for (int i = 0; i < Y_DIMENSION; i++)
            {
                for (int j = 0; j < X_DIMENSION; j++)
                {
                    Console.Write(a[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
