using System;

namespace Grupp7_TjuvOchPolis
{
    internal class Item
    {
        public string Type { get; set; }
        public bool IsStolen { get; set; }

        // Kanske lägga till värde på item?
        public Item(string type)
        {
            Type = type;
            IsStolen = false;
        }
    }
}
