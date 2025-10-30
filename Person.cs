using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Person
    {     
        public string Name { get; set; }

        public int PosX { get; set; }//[x,y]
        public int PosY { get; set; }//[x,y]
        public int DirX { get; set; } //X -1, Y 0
        public int DirY { get; set; } //X -1, Y 0

        public List<Item> Inventory { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color{ get; set; }

        public Person()
        {
            Name = RandomName();
            PosX = 0;
            PosY = 0;
            SetDirection();
            Inventory = new List<Item>();
            Symbol = "X";
            Color = ConsoleColor.White;
        }
        private static int RandomDirection()
        {
            int direction = Random.Shared.Next(-1, 2);
            return direction;
        }

        public void SetDirection()
        {
            DirX = RandomDirection();
            DirY = RandomDirection();

            while (DirX == 0 && DirY == 0) // ReRoll if both
            {
                ReRollDirection();
            }
        }

        private void ReRollDirection()
        {
                DirX = RandomDirection();
                DirY = RandomDirection();
        }
        public static List<Person> CreatePerson(int citizenCount, int policeCount, int theifCount)
        {
           
            List<Person> people= new List<Person>();
            //Citizen
            for (int i = 0; i < citizenCount; i++) 
            {
                people.Add(new Citizen());
            }
            //Thieves
            for (int i = 0; i < theifCount; i++)
            {
                people.Add(new Thief());
            }
            //Police
            for (int i = 0; i < policeCount; i++)
            {
                people.Add(new Police());
            }

            return people;
        }
     
        public void Move(int width, int height)
        {
            // Update position
            PosX += DirX;
            PosY += DirY;

            // Wrap X and Y using modulo
            PosX = (PosX + width) % width; // Kan vi inte bara lägga in "PosX = (PosX + DirX + width) % width" för att slippa Update Position?
            PosY = (PosY + height) % height;
        }

        public void PrintDetails()
        {
            Console.ForegroundColor = Color;
            Console.Write(this.GetType().Name.PadRight(8));
            Console.ResetColor();
            Console.Write(Name.PadRight(10));         
            Console.Write($"X:{PosX}".PadRight(5));
            Console.Write($"Y:{PosY}".PadRight(5));

            Console.Write($"dirX:{DirX}".PadRight(8) + $"dirY:{DirY}".PadRight(8));                      
        }
        public void PrintInventory() 
        {
            string text = "";
            text += "[";
            for (int i = 0; i < Inventory.Count; i++)
            { 
                if (Inventory.Count == i +1)                  
                    text += Inventory[i].Type;
                else                
                    text += Inventory[i].Type + ", ";
            }          
            text += "]";
            Console.Write(text.PadRight(30));
        }
        public virtual void PrintRoleDetails(){}
        private static string RandomName()
        {
            string[] names =
            {
                "Anna", "Erik", "Maria", "Johan", "Sara", "Anders", "Emma", "Lars", "Linda", "Per",
                "Elin", "Karl", "Sofie", "Fredrik", "Ida", "Magnus", "Camilla", "Daniel", "Jessica", "Oskar",
                "Malin", "Henrik", "Josefin", "Niklas", "Caroline", "Mattias", "Rebecca", "Patrik", "Helena", "Thomas"
            };
            return names[Random.Shared.Next(0, names.Length)];
        }
    }
}
