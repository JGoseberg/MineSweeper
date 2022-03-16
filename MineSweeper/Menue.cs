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
            int[,] difficulties = new int[,]
            {
                {9, 9, 10},
                {16, 16, 40},
                {30, 16, 99}
            };

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
                        //Game.BuildField(game);
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



        public static void Settingsa()
        {// nicht konsistent
            int difficulty = 0;

            Console.Clear();
            Console.WriteLine(
                "\tSettings\n" +//TODO
                "\'D\'-\tSchwierigkeitsgrad\n" +
                "\'E\'-\tExit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S://TODO
                    //Anfänger (Standard), Fortgeschritten, Profi, CustomProfile
                    break;
                case ConsoleKey.D://TODO
                    do
                    {

                        Console.WriteLine(
                            "Please Select\n" +
                            "E - Easy\n" +
                            "M - Medium\n" +
                            "H - Hard");
                        switch (Console.ReadKey().Key)
                        {
                            case ConsoleKey.E:
                                MainMenue();
                                break;
                            case ConsoleKey.M:
                                difficulty = 2;
                                MainMenue(difficulty = 1);
                                break;
                            case ConsoleKey.H:
                                MainMenue(difficulty = 2);
                                break;
                            default:
                                Console.WriteLine("Falsche Eingabe");
                                break;
                        }
                    } while (true);
                    break;
                case ConsoleKey.M://TODO
                    break;
                case ConsoleKey.F://TODO
                    break;
                case ConsoleKey.E:
                    MainMenue();
                    break;
                default:
                    Console.WriteLine("not a valid Key");
                    break;
            }
        }
    }
}
