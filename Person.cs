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
        public int[] Position { get; set; }//[x,y]
        public int[] Direction { get; set; } //X -1, Y 0
        public List<Item> Inventory { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color{ get; set; }

        public Person()
        {
            Name = RandomName();
            Position = [0,0];
            Direction = RandomDirection();
            Inventory = new List<Item>();
            Symbol = "X";
            Color = ConsoleColor.White;
        }
        public static int[] RandomDirection()
        {
            int directionX = Random.Shared.Next(-1, 2);
            int directionY = Random.Shared.Next(-1, 2);

            while (directionX == 0 && directionY == 0) // Reroll direction if both x and y is 0
            {
                directionX = Random.Shared.Next(-1, 2);
                directionY = Random.Shared.Next(-1, 2);
                //Msg.Add("Rerolled Direction");
            }
            int[] direction = {directionX, directionY };
            return direction;
        }
        public static List<Person> CreatePerson(int citizenCount, int policeCount, int theifCount)
        {
           
            List<Person> people= new List<Person>();
            //Police
            for (int i = 0; i < policeCount; i++)
            {
                people.Add(new Police());
            }
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

            return people;
        }
     
        public void Move(int width, int height)
        {
            // Update position
            Position[0] += Direction[0];
            Position[1] += Direction[1];

            // Wrap X and Y using modulo
            Position[0] = (Position[0] + width) % width;
            Position[1] = (Position[1] + height) % height;
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
