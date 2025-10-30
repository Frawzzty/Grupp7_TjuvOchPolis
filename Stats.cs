using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal static class Stats
    {
        static public int TotalArrests { get; set; }
        static public int TotalRobbed { get; set; }
        static public int Time { get; set; }

        public static void Print()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("== STATS =======================================");
            Console.ResetColor();
            Console.WriteLine($"Total Robbed Citizens: {TotalRobbed}");
            Console.WriteLine($"Total Arrested Thieves: {TotalArrests}");
            Console.WriteLine($"Time Passed: {Time}");
        }
    }
}
