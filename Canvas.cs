using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Canvas
    {
        private Person[,] Map { get; set; }
        private int Height;
        private int Width;
        private List<Person> People { get; set; }

        public Canvas(int width, int height, List<Person> people)
        {
            Height = height;
            Width = width;
            Map = new Person[Height, Width];
            People = people;
            SetRandomPosition(); 
        }
        public void HandleCollision(Person personA, Person personB) //Keep?
        {
            Msg.Add($"Collision Detected X:{personA.PosX} Y:{personA.PosY} - {personA.GetType().Name} {personA.Name} vs {personB.GetType().Name} {personB.Name}");

            if (personA is Thief && personB is Citizen || personB is Citizen && personA is Thief) //Tjuv kolliderar med citizen
            {
                Thief thief = personA is Thief ? (Thief)personA : (Thief)personB;
                Citizen citizen = personA is Thief ? (Citizen)personB : (Citizen)personA;

                if (citizen.Inventory.Count > 0)
                    thief.StealItem(citizen);
            }

            if (personA is Thief && personB is Police || personB is Police && personA is Thief) //Polis kolliderar med Tjuv 
            {
                Thief thief = personA is Thief ? (Thief)personA : (Thief)personB;
                Police police = personA is Thief ? (Police)personB : (Police)personA;

                if (thief.IsWanted) police.Arrest(thief);
            }
        }
        private void ClearMap()
        {
            for (int row = 0; row < Height; row++) 
            {
                for (int col = 0; col < Width; col++)
                {
                    Map[row, col] = null;
                }
            }
        }
        /// <summary>
        /// Clears previous Data in matrix. Updares people positions. Checks collision. Place people in the matrix.
        /// </summary>
        public void UpdateMap()
        {
            UpdatePeoplePosition();
            ClearMap(); //Array.Clear(Map);

            foreach (Person personA in People) 
            {
                int x = personA.PosX;
                int y = personA.PosY;
                if(Map[y, x] != null) // Collision detected //Bug när fler kliver på varandra? Skippar en check
                {
                    Person personB = Map[y, x]; //Person som redan står på rutan
                    HandleCollision(personA, personB); //beröm till patrik för variable namn
                }

                Map[y, x] = personA;
            }
        }
        /// <summary>
        /// Prints data in matrix.
        /// </summary>
        public void PrintMap() 
        {
            Console.WriteLine($"╔{new string('═', Width)}╗"); //new string('<whatChar>', <howMany>) 
            for (int row = 0; row < Height; row++)
            {
                Console.Write("║");
                for (int col = 0; col < Width; col++)
                {
                    if (Map[row,col] == null) //If null print space
                    {
                        Console.Write(" ");
                    }
                    else //If person. Print person symbol
                    {
                        Console.ForegroundColor = Map[row, col].Color;
                        Console.Write(Map[row, col].Symbol);
                        Console.ResetColor();
                    }            
                }
                Console.Write("║");
                Console.WriteLine();
            }
            Console.WriteLine($"╚{new string('═', Width)}╝");
        }
        public void SetRandomPosition() // Sätter en random position inom Canvas width och height för varje person
        {
            foreach (Person person in People)
            {
                person.PosX = Random.Shared.Next(1, Width - 1);     // -1 because of index in Map from Canvas
                person.PosY = Random.Shared.Next(1, Height - 1);    // -1 because of index in Map from Canvas
            }
        }

        public void UpdatePeoplePosition()
        {
            foreach (Person person in People)
            {
                person.Move(Width, Height);
            }
        }
    }
}
