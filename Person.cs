using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Person
    {
        //if (List.Contains(person.Position))
        public string Name { get; set; }
        public int[] Position { get; set; }
        public int[] Direction { get; set; } //X -1, Y 0
        //public List<Item> Inventroy { get; set; } //Skapa Item klass
        public string Symbol { get; set; }

        public Person(string name, int[] position)
        {
            Name = name;
            Position = position;
            Direction = RandomDirection();
            Symbol = "X";
        }

        public static int[] RandomDirection()
        {
            int directionX = Random.Shared.Next(-1, 2);
            int directionY = Random.Shared.Next(-1, 2);
            int[] direction = new int[2];

            direction[0] = directionX;
            direction[1] = directionY;

            return direction;
        }

        public static List<Person> CreatePerson(int amountOfPeople)
        {
            string[] names = new string[]
            {
                "Anna", "Erik", "Maria", "Johan", "Sara", "Anders", "Emma", "Lars", "Linda", "Per",
                "Elin", "Karl", "Sofie", "Fredrik", "Ida", "Magnus", "Camilla", "Daniel", "Jessica", "Oskar",
                "Malin", "Henrik", "Josefin", "Niklas", "Caroline", "Mattias", "Rebecca", "Patrik", "Helena", "Thomas"
            };
            List<Person> people= new List<Person>();
            for (int i = 0; i < amountOfPeople; i++)
            {
                people.Add(new Person(names[Random.Shared.Next(0, names.Length)], [0, 0]));
                System.Console.WriteLine($"Namn: {people[i].Name} Y: {people[i].Direction[1]} X: {people[i].Direction[0]}");
            }
            return people;
        }      
    }
}
