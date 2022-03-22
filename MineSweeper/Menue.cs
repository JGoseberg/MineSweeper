using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class Menue
    {


        public static void MainMenue(int difficulty = 1)
        {
            //Console.SetWindowSize(20, 5);
            Console.WindowHeight = 10;

            Dictionary<int, int[]> diff = new Dictionary<int, int[]>()
            {
                {1, new int[]{9,9,10 } },
                {2, new int[]{16,16,40 }},
                {4, new int[]{30,16,99 }}
            };


            //CursorGesteuertesMenue
            Game game = new(diff[difficulty][0], diff[difficulty][1], diff[difficulty][2]);
            do
            {
                Console.Clear();
                Console.WriteLine(
                    "\tMineSweeper\n" +
                    "\'P\'-\tPlay\n" + //TODO
                                       //"\'H\'-\tHighscores\n" + //TODO
                    "\'S\'-\tSettings\n" +//TODO
                                          //"\'F1\'-\t Help\n" + //TODO
                    "\'E\'-\tExit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.P: //TODO
                        Console.WindowHeight = diff[difficulty][0] + 8;
                        Game.GameLoop(game);
                        break;
                    case ConsoleKey.H://TODO
                        break;
                    case ConsoleKey.S:
                        Settings.SetSettings();
                        break;
                    case ConsoleKey.F1://TODO
                        Console.WriteLine("Coming Soon");
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("\bDo you realy want to exit? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.Y) Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("not a valid Key");
                        break;
                }
            } while (true);
        }
    }
}
