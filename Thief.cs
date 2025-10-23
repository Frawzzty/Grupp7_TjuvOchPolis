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

        public void StealItem(Citizen citizen)
        {
            int rnd = Random.Shared.Next(0, citizen.Inventory.Count);
            Item stolenItem = citizen.Inventory[rnd];//bug
            citizen.Inventory.RemoveAt(rnd);
            this.Inventory.Add(stolenItem);
            IsWanted = true;
            Msg.Add($"Thief {Name} stole {stolenItem.Type} from {citizen.Name}");
        }

        public void SittingInPrison() //tempnamn
        {
            TimeInPrison++;
            if (TimeInPrison > 20) 
            { 
                TimeInPrison = 0;
                InPrison = false;
                IsWanted = false;
            }
        }
    }
}