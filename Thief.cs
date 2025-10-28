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
            this.IsWanted = true;
            Msg.Add($"Thief {Name} stole {stolenItem.Type} from {citizen.Name}");
        }

        public void SittingInPrison() //tempnamn
        {
            TimeInPrison++;
            if (TimeInPrison > 5) 
            { 
                TimeInPrison = 0;
                InPrison = false;
                IsWanted = false;
            }
        }

        public override string Description()
        {
            string text = "";
            text += this.GetType().Name.PadRight(8);
            text += Name.PadRight(10);
            text += $"X:{PosX} Y:{PosY}".PadRight(10);
            text += $"dirX:{DirX} dirY:{DirY}".PadRight(16);
            text += $"In Prison: {InPrison} ".PadLeft(16);
            text += $"Is Wanted: {IsWanted} ".PadLeft(16);
            text += $"TimeInPrison: {TimeInPrison} ".PadLeft(16);          
            foreach (Item item in Inventory)
            {
                text += item.Type + ", ";
            }
            

            return text;
        }
    }
}