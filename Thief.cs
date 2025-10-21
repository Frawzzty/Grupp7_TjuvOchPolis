using System;

namespace Grupp7_TjuvOchPolis
{
    internal class Thief : Person
    {
        public bool InPrison { get; set; }
        public bool IsWanted { get; set; } //True if got item in inventory
        public int TimeInPrison { get; set; }
        public Thief() : base ()
        {
            InPrison = false;
            TimeInPrison = 0;
            Symbol = "T";
            Color = ConsoleColor.Red;
        }
    }
}