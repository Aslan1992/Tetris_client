using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace tetrisCient
{
    class StringTo2DArrayDecoder
    {
        private static string threeSymbolsGroupDelimiterPattern = "(?<=\\G.{3})";
        
        public static string[,] Decode(String line)
        {
            string[,] result = new string[ArrayPrinter.Y_DIMENSION, ArrayPrinter.X_DIMENSION];
            string[] elements = Regex.Split(line, threeSymbolsGroupDelimiterPattern);
            int k = 0;
            for (int i = 0; i < ArrayPrinter.Y_DIMENSION; i++)
            {
                for (int j = 0; j < ArrayPrinter.X_DIMENSION; j++)
                {
                    result[i, j] = elements[k];
                    k++;
                }
            }
            return result;
        }

    }
}
