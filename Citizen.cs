using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Citizen : Person
    {
        public Citizen() : base()
        {
            Symbol = "M";
            SetInventory();
        }
        public void SetInventory()
        {
            string[] defaultItems = ["Klocka", "Mobiltelefon", "Pengar", "Nycklar"]; 
            foreach (string itemType in defaultItems)
            {
                Inventory.Add(new Item(itemType));
            }
        }
    }
}
