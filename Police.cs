using System;

namespace Grupp7_TjuvOchPolis
{
    internal class Police : Person
    {
        public int NumberOfArrests { get; set; }        
        public Police() : base ()
        {
            NumberOfArrests = 0;
            Symbol = "P";
            Color = ConsoleColor.DarkBlue;
        }
    }
}