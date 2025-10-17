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
        //public List<Item> Inventroy { get; set; } //Skapa Item klass
        public string Symbol { get; set; }

        public Person(string name)
        {
            Name = name;
            Position = [0,0];
            Direction = RandomDirection();
            Symbol = "X";
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
            string[] names = new string[]
            {
                "Anna", "Erik", "Maria", "Johan", "Sara", "Anders", "Emma", "Lars", "Linda", "Per",
                "Elin", "Karl", "Sofie", "Fredrik", "Ida", "Magnus", "Camilla", "Daniel", "Jessica", "Oskar",
                "Malin", "Henrik", "Josefin", "Niklas", "Caroline", "Mattias", "Rebecca", "Patrik", "Helena", "Thomas"
            };

            List<Person> people= new List<Person>();
            //Citiezens
            for (int i = 0; i < citizenCount; i++)
            {
                string randomName = names[Random.Shared.Next(0, names.Length)];
                people.Add(new Citizen(randomName));
            }
            //Police
            for (int i = 0; i < policeCount; i++)
            {
                string randomName = names[Random.Shared.Next(0, names.Length)];
                people.Add(new Person(randomName));
            }
            //Theives
            for (int i = 0; i < theifCount; i++)
            {
                string randomName = names[Random.Shared.Next(0, names.Length)];
                people.Add(new Person(randomName));
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
    }
}
