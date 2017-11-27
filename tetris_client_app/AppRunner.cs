using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetrisCient
{
    class AppRunner
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO TETRIS");
            Console.WriteLine("To control figure use LEFT, DOWN, RIGHT arrows on the keyboard. To turn figure use WHITESPACE key");
            Console.WriteLine("Press 'y' to start game");
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.Y)
                {
                    Game game = new Game("127.0.0.1", 8181);
                    game.Start();
                    Console.WriteLine("GAME OVER. To restart press 'y'");
                } else
                {
                    Console.WriteLine("Why do you press something else ? Press 'y' :) ");
                }
                
            }
        }
    }
}
