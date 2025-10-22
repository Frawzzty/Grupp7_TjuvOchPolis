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
        public void HandleCollssion(Person thisPerson, Person otherPerson) //Keep?
        {
            Msg.Add($"Collission Detected X:{thisPerson.PosX} Y:{thisPerson.PosY} - {thisPerson.GetType().Name} {thisPerson.Name} vs {otherPerson.GetType().Name} {otherPerson.Name}");

            if(thisPerson.GetType().Name == "Theif" && otherPerson.GetType().Name == "Citizen" || otherPerson.GetType().Name == "Citizen" && this.GetType().Name == "Theif") //Tjuv kliver på citizen
            {

            }

            if (thisPerson.GetType().Name == "Police" && otherPerson.GetType().Name == "Theif" || otherPerson.GetType().Name == "Theif" && this.GetType().Name == "Police") //Polis kliver på tjuv
            {

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

            foreach (Person thisPerson in People) 
            {
                int x = thisPerson.PosX;
                int y = thisPerson.PosY;
                if(Map[y, x] != null) // Collision detected //Bug när fler kliver på varandra? Skippar en check
                {
                    Person otherPerson = Map[y, x]; //Person som redan står på rutan
                    HandleCollssion(thisPerson, otherPerson);
                }

                Map[y, x] = thisPerson;
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
