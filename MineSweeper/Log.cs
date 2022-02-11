using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public static class Log
    {
        public static void WriteLog(string message)
        {
            string path = @".\Logs\";

            Directory.CreateDirectory(path);

            File.AppendAllText(path + "log.txt", $"{ DateTime.Now}:  { message} \n");
        }
    }
}
