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
            DirX = RandomDirection();
            DirY = RandomDirection();

            while (DirX == 0 && DirY == 0) // ReRoll if both
            {
                ReRollDirection();
            }

            Inventory = new List<Item>();
            Symbol = "X";
            Color = ConsoleColor.White;
        }
        private static int RandomDirection()
        {
            int direction = Random.Shared.Next(-1, 2);
            return direction;
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
            PosX = (PosX + width) % width;
            PosY = (PosY + height) % height;
        }
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
