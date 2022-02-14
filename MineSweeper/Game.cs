﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class Game
    {
        int sizeHeight = 5;//TODO
        int sizeWidth = 5;//TODO
        int minesCount = 5;//TODO

        string colorBackground = "black";//TODO
        string colorText = "white";//TODO
        string colorMines = "white";//TODO
        string colorFlags = "red";//TODO

        Dictionary<int, string> colorHint = new Dictionary<int, string>()
        {
            { 1, "blue" },//TODO
            { 2, "green" },//TODO
            { 3, "red" },//TODO
            { 4, "darkblue" },//TODO
            { 5, "brown" },//TODO
            { 6, "turquoise" },//TODO
            { 7, "white" },//TODO
            { 8, "dark grey" }//TODO
        };

        public int SizeHeight { get => sizeHeight; set => sizeHeight = value; }
        public int SizeWidth { get => sizeWidth; set => sizeWidth = value; }
        public Dictionary<int, string> ColorHint { get => colorHint; set => colorHint = value; }
        public string ColorText { get => colorText; set => colorText = value; }
        public string ColorMines { get => colorMines; set => colorMines = value; }
        public string ColorFlags { get => colorFlags; set => colorFlags = value; }
        public int MinesCount { get => minesCount; set => minesCount = value; }
        public string ColorBackground { get => colorBackground; set => colorBackground = value; }


        public static void GameLoop(Game game)
        {
            Game.BuildField(game);
        }

        public static void BuildField(Game game)
        {
            int[] minesHeight = new int[game.MinesCount];
            int[] minesWidth = new int[game.MinesCount];

            Random rnd = new Random((int)DateTime.Now.Ticks);

            //Fenstergroesse begrenzen
            //Console.WindowHeight = game.SizeHeight+3;
            //Console.WindowWidth = game.SizeWidth+2;


            Console.Clear();

            //int cursorLeft = 0;//Console.CursorLeft;
            //int cursorHeight = 0;//Console.CursorTop;

            int[,] gameField = new int[game.sizeHeight, game.sizeWidth];//Test


            //Minen setzen
            for (int i = 0; i < game.MinesCount; i++)
            {
                minesHeight[i] = rnd.Next(0, game.SizeHeight);
                minesWidth[i] = rnd.Next(0, game.sizeWidth);

                //Prüfung auf gleiche Positionen
                for (int j = 0; j < i; j++)
                {
                    if (minesHeight[j] == minesHeight[i] && minesWidth[j] == minesWidth[i])
                    {
                        i--;
                    }
                }
                gameField[minesHeight[i], minesWidth[i]] = 10;
            }


            //HinweisErstellung 
            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    if (gameField[i, j] == 10)
                    {
                        for (int k = -1; k < 2; k++)
                        {
                            for (int l = -1; l < 2; l++)
                            {
                                if (i + k < 0 || j + l < 0 ||
                                    i + k >= gameField.GetLength(0) || j + l >= gameField.GetLength(1) ||
                                    i + k == i && j + l == j) ;
                                else if (gameField[i + k, j + l] == 10) ;
                                else gameField[i + k, j + l]++;
                            }
                        }
                    }
                }
            }
            DrawBaseField(game, gameField);
            Navigation(game, gameField);
        }


        public static void DrawBaseField(Game game, int[,] gameField)
        {
            //Spielfeld malen, weiteres bool array nach jeder Navigation neu erstellen
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < game.SizeWidth + 2; i++)
            {
                Console.Write("-");
            }

            Console.WriteLine();

            for (int i = 0; i < game.sizeHeight; i++)
            {
                Console.Write("|");
                for (int j = 0; j < game.sizeWidth; j++)
                {
                    if (gameField[i, j] == 10)
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.Write("#");
                    }
                    else if (gameField[i, j] > 0 && gameField[i, j] < 9)
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.Write(gameField[i, j]);
                    }
                    else
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.Write("*");
                    }
                }
                Console.WriteLine("|");
            }

            for (int i = 0; i < game.SizeWidth + 2; i++)
            {
                Console.Write("-");
            }
            //Console.WriteLine();

            //Fenster auf letzte Position setzen
            //Console.SetCursorPosition(cursorLeft, cursorHeight);
        }

        public static bool NavigationValidationHeight(Game game, int cursorHeight)
        {
            if (cursorHeight > 0 && cursorHeight < 6) return true;
            return false;
        }

        public static bool NavigationValidationLeft(Game game, int cursorLeft)
        {
            if (cursorLeft > 0 && cursorLeft < 6) return true;
            return false;
        }


        public static void Navigation(Game game, int[,] gameField)
        {
            //Cursorsteuerung
            int cursorHeight = 1;
            int cursorLeft = 1;
            do
            {
                Console.SetCursorPosition(cursorLeft, cursorHeight);
                switch (Console.ReadKey().Key)
                {
                    //case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (NavigationValidationHeight(game, cursorHeight - 1)) cursorHeight--;
                        break;
                    //case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (NavigationValidationLeft(game, cursorLeft - 1)) cursorLeft--;
                        break;
                    //case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (NavigationValidationHeight(game, cursorHeight + 1)) cursorHeight++;
                        break;
                    //case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (NavigationValidationLeft(game, cursorLeft + 1)) cursorLeft++;
                        break;
                    case ConsoleKey.Enter:
                        //DrawField()
                        Console.SetCursorPosition(Console.GetCursorPosition().Left, Console.GetCursorPosition().Top);
                        Console.Write(gameField[Console.GetCursorPosition().Left, Console.GetCursorPosition().Top]);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
