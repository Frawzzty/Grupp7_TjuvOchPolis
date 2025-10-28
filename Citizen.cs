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
            Symbol = "C";
            SetInventory();
        }
        public void SetInventory()
        {
            string[] defaultItems = ["Watch", "Phone", "Money", "Keys"];
            foreach (string itemType in defaultItems)
            {
                Inventory.Add(new Item(itemType));
            }           
        }
    }
}
