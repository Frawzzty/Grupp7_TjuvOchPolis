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
        //beslagta
        

        public void Arrest(Thief thief)
        {
            NumberOfArrests++;
            thief.InPrison = true;
            SeizeItems(thief);
            Msg.Add($"Police {Name} arrested the thief {thief.Name}");
            //skicka till f�ngelse!
            //vi har inget f�ngelse �n...
        }
        private void SeizeItems(Thief thief)
        {
            this.Inventory.AddRange(thief.Inventory);
            thief.Inventory.Clear();
            Msg.Add($"Police {Name} Seized inventory of {thief.Name}");
        }
    }
}