using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    public static class Msg //static class so you don't have to make a new object to add messages to
    {

        private static List<string> messages = new List<string>(); //a list to contain messages
                                                                   //can change from list to stack

        public static void Add(string msg) //this adds message to List
        {
            messages.Add(msg);
            if (messages.Count > 25)
            { 
                messages.RemoveAt(0);
            }
        }
        public static void Print() //this prints the messages from List on their own lines
        {
            foreach (string m in messages) Console.WriteLine(m);          
        }

        public static void PrintLast(int amount)
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

        public static void Clear() //clears list
        {         
            messages.Clear();
        }

        ///This class would essentially act as a storage for messages and only prints it's content when the PrintBoarder() method is called upon 
        ///so you can continually add debug messages throughout the code but still control the time when it outputs
        ///so you write Msg.Add("a debug message")
    }
}
