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
        public static int[] RandomDirection()//bug: person kan få 0,0 direction vilket gör att dom står stilla
        {
            int directionX = Random.Shared.Next(-1, 2);
            int directionY = Random.Shared.Next(-1, 2);

            

            while (directionX == 0 && directionY == 0) // Reroll direction if both x and y is 0
            {
                directionX = Random.Shared.Next(-1, 2);
                directionY = Random.Shared.Next(-1, 2);
                //Msg.Add("Rerolled Direction");
            }

            int[] direction = new int[2];
            direction[0] = directionX;
            direction[1] = directionY;

            return direction;
        }
        public static List<Person> CreatePerson(int citizenCount, int policeCount, int theifCount)
        {
           
            List<Person> people= new List<Person>();
            //Citiezensn
            for (int i = 0; i < citizenCount; i++)
            {
                people.Add(new Citizen());
            }
            //Police
            for (int i = 0; i < policeCount; i++)
            {
                people.Add(new Police());
            }
            //Thieves
            for (int i = 0; i < theifCount; i++)
            {
                people.Add(new Thief());
            }
            return people;
        }
        public void AddStatus()
        {
            Msg.Add($"{Name} Status: pos- X {Position[0]} Y {Position[1]} Dir- X {Direction[0]} Y {Direction[1]}");
        }
        public void Move(int width, int height)//bug: personer kan gå utanför ramen, behöver wrap around
        {
            Position[0] += Direction[0];
            Position[1] += Direction[1];

            //Gör så person kommer ut på andra sidan vägg höger / vänster
            if (Position[0] >= width) // Går in i höger vägg
            {
                Position[0] -= width - 1;
                //Msg.Add("--> Höger vägg");
            }
            else if (Position[0] <= 0) // Går in i Vänster vägg
            {
                Position[0] += width;
                //Msg.Add("--> Vänster vägg");
            }

            //Gör så person kommer ut på andra sidan tak / golv
            if (Position[1] >= height) // Går in i Golv
            {
                Position[1] -= height - 1; //take away width from x
                //Msg.Add("--> Golv");
            }
            else if (Position[1] <= 0) // Går in i Tak
            {
                Position[1] += height;
                //Msg.Add("--> Tak");
            }
        }
        public static string RandomName()
        {
            string[] names = new string[]
            {
                "Anna", "Erik", "Maria", "Johan", "Sara", "Anders", "Emma", "Lars", "Linda", "Per",
                "Elin", "Karl", "Sofie", "Fredrik", "Ida", "Magnus", "Camilla", "Daniel", "Jessica", "Oskar",
                "Malin", "Henrik", "Josefin", "Niklas", "Caroline", "Mattias", "Rebecca", "Patrik", "Helena", "Thomas"
            };
            return names[Random.Shared.Next(0, names.Length)];
        }
    }
}
