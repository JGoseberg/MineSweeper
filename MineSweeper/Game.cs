using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    internal class Game
    {
        int sizeHeight;
        int sizeWidth;
        int minesCount;

        int cursorHeight = 1;
        int cursorLeft = 1;

        public Game(int sizeHeight, int sizeWidth, int minesCount)
        {
            SizeHeight = sizeHeight;
            SizeWidth = sizeWidth;
            MinesCount = minesCount;
        }


        public int SizeHeight { get => sizeHeight; set => sizeHeight = value; }
        public int SizeWidth { get => sizeWidth; set => sizeWidth = value; }
        public int MinesCount { get => minesCount; set => minesCount = value; }
        public int CursorHeight { get => cursorHeight; set => cursorHeight = value; }
        public int CursorLeft { get => cursorLeft; set => cursorLeft = value; }


        public static void GameLoop(Game game)
        {
            Game.Init(game);
        }


        public static void Init(Game game)
        {
            int[] minesHeight = new int[game.MinesCount];
            int[] minesWidth = new int[game.MinesCount];

            Random rnd = new Random((int)DateTime.Now.Ticks);

            //Fenstergroesse begrenzen
            //Console.WindowHeight = game.SizeHeight+3;
            //Console.WindowWidth = game.SizeWidth+2;

            Console.Clear();

            //0     = void
            //1-9   = Hinweis
            //10    = Bombe
            int[,] gameField = new int[game.sizeHeight, game.sizeWidth];


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
            bool[,] isActivated = new bool[gameField.GetLength(0), gameField.GetLength(1)];
            bool[,] bombDetected = new bool[gameField.GetLength(0), gameField.GetLength(1)];
            for (int i = 0; i < isActivated.GetLength(0); i++)
            {
                for (int j = 0; j < isActivated.GetLength(1); j++)
                {
                    isActivated[i, j] = false;
                    bombDetected[i, j] = false;
                }
            }
            DrawBaseField(game, gameField, isActivated, bombDetected);
        }


        public static void CheckVoid(Game game, int[,] gameField, bool[,] isActivated, int i, int j, bool[,] bombDetected)
        {//TODO zeilen obendrueber
            for (int k = -1; k < 2; k++)
            {
                for (int l = -1; l < 2; l++)
                {
                    if (i + k < 0 || j + l < 0 ||
                    i + k >= gameField.GetLength(0) || j + l >= gameField.GetLength(1) ||
                    i + k == i && j + l == j) ;
                    else if (gameField[i + k, j + l] == 0 && isActivated[i + k, j + l] == false)
                    {
                        isActivated[i + k, j + l] = true;
                        CheckVoid(game, gameField, isActivated, i + k, j + l, bombDetected);
                    }
                    else
                    {
                        isActivated[i + k, j + l] = true;
                    }
                }
            }
        }



        public static void DrawBaseField(Game game, int[,] gameField, bool[,] isActivated, bool[,] bombDetected)
        {
            bool loose = false;
            int counter = 0;


            //Spielfeld malen, weiteres bool array nach jeder Navigation neu erstellen(alternative)
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
                    if (gameField[i, j] == 10 && isActivated[i, j] && bombDetected[i, j] == false)
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.Write("#");

                        loose = true;
                        //EndScreen
                    }
                    else if (gameField[i, j] == 10 && isActivated[i, j] || bombDetected[i, j])
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("B");
                        Console.ResetColor();
                    }
                    else if (gameField[i, j] > 0 && gameField[i, j] < 9 && isActivated[i, j])
                    {
                        Console.SetCursorPosition(j + 1, i + 1);
                        switch (gameField[i, j])
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                            case 8:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                        }
                        Console.Write(gameField[i, j]);
                        Console.ResetColor();

                    }
                    else if (isActivated[i, j])
                    {
                        CheckVoid(game, gameField, isActivated, i, j, bombDetected);

                        //DrawBaseField(game, gameField, isActivated, bombDetected);

                        Console.SetCursorPosition(j + 1, i + 1);
                        Console.Write("*");

                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine("|");
            }

            for (int i = 0; i < game.SizeWidth + 2; i++)
            {
                Console.Write("-");
            }

            for (int i = 0; i < isActivated.GetLength(0); i++)
            {
                for (int j = 0; j < isActivated.GetLength(1); j++)
                {
                    if (isActivated[i, j]) counter++;
                }
            }

            if (loose)
            {
                (int posL, int posT) = Console.GetCursorPosition();
                Console.SetCursorPosition(0, game.SizeHeight + 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Loose");
                Console.ResetColor();
                Console.WriteLine("Do you want to play again? (Y/N)");
                Console.SetCursorPosition(game.CursorLeft, game.CursorHeight);
                if (Console.ReadKey().Key == ConsoleKey.Y) Menue.MainMenue(GetDiff(game.MinesCount));
                Environment.Exit(0);
            }
            else if (isActivated.GetLength(0) * isActivated.GetLength(1) - game.MinesCount == counter)
            {
                Console.SetCursorPosition(0, game.SizeWidth + 3);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You Won");
                Console.ResetColor();
                Console.WriteLine("\n\n\n\nDo you want to play again? (Y/N)");
                if (Console.ReadKey().Key == ConsoleKey.Y) Menue.MainMenue(GetDiff(game.MinesCount));
                Environment.Exit(0);

            }
            Console.WriteLine("\n\n\n" +
                "Navigate with the Arrows\n" +
                "Press Enter to reveal the field\n" +
                "Press B to place a Flag");

            int[] actualNavigation = new int[3];
            actualNavigation = NavigationNew.CursorNavigation(game.CursorHeight, game.CursorLeft, game.SizeHeight, game.SizeWidth);

            game.CursorHeight = actualNavigation[0];
            game.CursorLeft = actualNavigation[1];

            switch (actualNavigation[2])
            {
                case 0:
                    //BombDetection
                    if (BombDetected(game.CursorHeight, game.CursorLeft, bombDetected))
                    {
                        bombDetected[game.CursorHeight - 1, game.CursorLeft - 1] = true;
                        isActivated[game.CursorHeight - 1, game.CursorLeft - 1] = false;
                    }
                    else bombDetected[game.CursorHeight - 1, game.CursorLeft - 1] = false;
                    DrawBaseField(game, gameField, isActivated, bombDetected);
                    break;
                case 1:
                    //Enter
                    isActivated[game.CursorHeight - 1, game.CursorLeft - 1] = true;
                    DrawBaseField(game, gameField, isActivated, bombDetected);
                    break;
                default:
                    break;
            }
        }

        internal static int GetDiff(int mines)
        {
            switch (mines)
            {
                case 10:
                    return 1;
                    
                case 40:
                    return 2;
                    
                case 99:
                    return 4;
                default:
                    return 1;

            }
        }


        public static bool BombDetected(int actualHeight, int actualLeft, bool[,] bombDetected)
        {
            if (bombDetected[actualHeight - 1, actualLeft - 1])
                return false;
            else
                return true;

        }



    }
}
