using System;

namespace Grupp7_TjuvOchPolis
{
    internal class Thief : Person
    {
        public bool InPrison { get; set; }
        public bool IsWanted { get; set; } 
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
            Item stolenItem = citizen.Inventory[rnd];
            citizen.Inventory.RemoveAt(rnd);
            this.Inventory.Add(stolenItem);
            this.IsWanted = true;
            if (!citizen.Robbed)
            {
                Stats.TotalRobbed++;
                citizen.Robbed = true;
            }
            Msg.Add($"Thief {Name} stole {stolenItem.Type} from {citizen.Name}");
        }

        public void SittingInPrison()
        {
            TimeInPrison++;
            if (TimeInPrison > 50) 
            { 
                TimeInPrison = 0;
                InPrison = false;
                IsWanted = false;
            }
        }  
        public override void PrintRoleDetails()
        {
            
            Console.Write("Wanted: ");
            Console.Write(IsWanted.ToString().PadRight(6));
            if (InPrison)
            {
                Console.Write($"Prison: {InPrison} ");
                Console.Write($"Time: {TimeInPrison} ");
            }
            
        }
    }
}