using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class Menue
    {
        public static void MainMenue()
        {
            //CursorGesteuertesMenue
            do
            {
                Console.WriteLine(
                    "\tMineSweeper\n" +
                    "\'P\'-\tPlay\n" + //TODO
                    "\'H\'-\tHighscores\n" + //TODO
                    "\'S\'-\tSettings\n" +//TODO
                    "\'F1\'-\t Help\n" + //TODO
                    "\'E\'-\tExit");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.P: //TODO
                        Game game = new();
                        Game.BuildField(game);
                        break;
                    case ConsoleKey.H://TODO
                        break;
                    case ConsoleKey.S:
                        Settings();
                        break;
                    case ConsoleKey.F1://TODO
                        Console.WriteLine("Coming Soon");
                        break;
                    case ConsoleKey.E:
                        Console.WriteLine("do you realy want to exit? (Y/N)");
                        if (Console.ReadKey().Key == ConsoleKey.C) Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("not a valid Key");
                        break;
                }
            } while (true);
        }

        public static void Settings()
        {


            Console.Clear();
            Console.WriteLine(
                "\tSettings\n" +//TODO
                "\'S\'-\tSize\n" +//TODO
                "\'T\'-\tColor Text\n" +//TODO
                "\'M\'-\tColor Mines\n" +//TODO
                "\'F\'-\tColor Flags\n" +//TODO
                "\'E\'-\tExit");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.S://TODO
                    //Anfänger (Standard), Fortgeschritten, Profi, CustomProfile
                    break;
                case ConsoleKey.T://TODO
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
