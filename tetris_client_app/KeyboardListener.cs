using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetrisCient
{
    class KeyboardListener
    {

        public string WaitForCertainPress()
        {
            string number = "0";
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch(keyInfo.Key)
            {
                case ConsoleKey.DownArrow:
                    number = "1";
                    break;

                case ConsoleKey.LeftArrow:
                    number = "2";
                    break;

                case ConsoleKey.RightArrow:
                    number = "3";
                    break;

                case ConsoleKey.Spacebar:
                    number = "4";
                    break;
            }
            return number;
        }
    }
}
