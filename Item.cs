using System;

namespace Grupp7_TjuvOchPolis
{
    internal class Item
    {
        public string Type { get; set; }

        // Kanske lägga till värde på item?
        public Item(string type)
        {
            Type = type;
            
        }
    }
}
