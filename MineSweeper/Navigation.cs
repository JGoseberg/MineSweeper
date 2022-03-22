using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class NavigationNew
    {
        public static bool NavigationValidationHeight(int maxHeight, int actualHeight)
        {
            if (actualHeight > 0 && actualHeight < maxHeight + 1) return true;
            return false;
        }

        public static bool NavigationValidationLeft(int maxLeft, int actualLeft)
        {
            if (actualLeft > 0 && actualLeft < maxLeft + 1) return true;
            return false;
        }

        public static int[] CursorNavigation(int actualHeight, int actualLeft, int maxHeight, int maxLeft)
        {
            // B = 0
            // Enter = 1
            do
            {
                Console.SetCursorPosition(actualLeft, actualHeight);
                switch (Console.ReadKey().Key)
                {                    //case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (NavigationNew.NavigationValidationHeight(maxHeight, actualHeight - 1)) actualHeight--;
                        break;
                    //case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (NavigationNew.NavigationValidationLeft(maxLeft, actualLeft - 1)) actualLeft--;
                        break;
                    //case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (NavigationNew.NavigationValidationHeight(maxHeight, actualHeight + 1)) actualHeight++;
                        break;
                    //case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (NavigationNew.NavigationValidationLeft(maxLeft, actualLeft + 1)) actualLeft++;
                        break;
                    case ConsoleKey.B:
                        // B = 0
                        return new int[] { actualHeight, actualLeft, 0 };
                    case ConsoleKey.Enter:
                        // Enter = 1
                        return new int[] { actualHeight, actualLeft, 1 };
                    default:
                        break;
                }
            } while (true);
        }
    }
}
