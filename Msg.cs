using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    public static class Msg
    {

        private static List<string> messages = new List<string>(); 
        public static void Add(string msg) 
        {
            messages.Add(msg);
            if (messages.Count > 25) //Empty last message when there are more than 25 messages
            { 
                messages.RemoveAt(0);
            }
        }
        public static void Print() //Prints All the messages from List on their own lines
        {
            foreach (string m in messages) Console.WriteLine(m);          
        }

        public static void PrintLast(int amount) //Prints the last [amount] messages, latest first.
        {
            if (messages.Count < amount)
            {
                amount = messages.Count;
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("== NEWS FEED ===================================");
            Console.ResetColor();
            for (int i = amount; i > 0; i--)
            {             
                Console.WriteLine(messages[messages.Count - i]);              
            }
            Console.WriteLine();
        }
        public static void PrintLastToSide(int amount, int mapWidth, int mapHeight) 
        {
            mapWidth += 2;
            if (messages.Count < amount)
            {
                amount = messages.Count;
            }
            Console.SetCursorPosition(mapWidth, 0);
            Console.Write(" |== NEWS FEED ===================================");
            for (int i = amount; i > 0; i--)
            {
                Console.SetCursorPosition(mapWidth, amount - i +1);
                Console.Write(" | " + messages[messages.Count - i]);
            }
            Console.SetCursorPosition(mapWidth, amount + 1);
            Console.Write(" |================================================");
            Console.SetCursorPosition(0, mapHeight + 2);
        }

        public static void Clear()
        {         
            messages.Clear();
        }
    }
}
