using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    public static class Msg //static class so you don't have to make a new object to add messages to every time
    {

        private static List<string> messages = new List<string>(); //a list to contain messages

        public static void Add(string msg) //this adds message to string
        {
            messages.Add(msg);
        }
        public static void Print() //this prints the messages from List on their own lines
        {
            foreach (string m in messages) Console.WriteLine(m);       
        }

        public static void PrintLast()
        {
            Console.WriteLine(messages[messages.Count -1]);
        }

        public static void Clear() //this is if you'd like to clear everything from list before printing
        {         
            messages.Clear();
        }

        ///This class would essentially act as a storage for messages and only print it's content when the Print() method is called upon 
        ///so you can continually add debug messages throughout the code but still control the time when it outputs
        ///so you write Msg.Add("a debug message")
    }
}
