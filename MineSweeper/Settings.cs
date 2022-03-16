using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MineSweeper
{
    internal class Settings
    {
        int height;
        int width;
        int mines;

        int[,] difficulties = new int[,]
            {
                {9, 9, 10},
                {16, 16, 40},
                {30, 16, 99}
            };

        public Settings(int height, int width, int mines)
        {
            Height = height;
            Width = width;
            Mines = mines;
        }

        public int[,] Difficulties { get => difficulties; set => difficulties = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }
        public int Mines { get => mines; set => mines = value; }

        public Settings InitSettings(int difficultie)
        {
            if (File.Exists("settings.json"))
            {
                //LoadSettings()
            }
            else
            {
                Height = difficulties[difficultie, 0];
                Width = difficulties[difficultie, 1];
                Mines = difficulties[difficultie, 2];
            }
            return new Settings(Height, Width, Mines);
        }

        public static void SaveSettings(Settings settings)
        {
            string save = JsonConvert.SerializeObject(settings);


            File.WriteAllText("settings.json", save);
        }

        public static void SetSettings()
        {
            Console.Clear();
            Console.WriteLine("Please Select\n(E)asy\n(M)edium/n(H)ard");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.E:
                    Menue.MainMenue(1);
                    break;
                case ConsoleKey.M:
                    Menue.MainMenue(2);
                    break;
                case ConsoleKey.H:
                    Menue.MainMenue(4);
                    break;
                default:
                    Console.WriteLine("Falsche Eingabe");
                    break;
            }
        }
    }
}
