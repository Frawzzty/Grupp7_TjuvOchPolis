using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Canvas
    {
        //public Person[,] Matrix { get; set; }//tempnamn //varje index har person, if index null print " "
        private int Height;
        private int Width;
        public List<Person> People { get; set; }

        public Canvas(int width, int height, List<Person> people)
        {
            Height = height;
            Width = width;         
            People = people;
            RandomPos(); 
        }
        public void PrintBoarder()
        {

            Console.WriteLine($"╔{new string('═', Width)}╗"); //new string('<whatChar>', <howMany>) 
            for (int row = 0; row < Height; row++)
            {
                Console.Write("║");
                for (int col = 0; col < Width; col++)
                {                   
                    Console.Write(" ");                  
                }
                Console.Write("║");
                Console.WriteLine();
            }
            Console.WriteLine($"╚{new string('═', Width)}╝");
        }
        public void RandomPos() // Sätter en random position inom Canvas width och height för varje person
        {
            foreach (Person person in People)
            {
                int positionX = Random.Shared.Next(1, Width + 1);   // +1 because of map border
                int positionY = Random.Shared.Next(1, Height + 1);  // +1 because of map border
                int[] position = new int[2];

                position[0] = positionX;
                position[1] = positionY;
                person.Position = position;             
            }
        }
        public void PrintSimulation()
        {
            PrintBoarder();
            PrintPeople();
            Console.SetCursorPosition(0, Height+2); //math to put cursor after          
        }
        public void PrintPeople()
        {
            foreach (Person person in People)
            {
                Console.SetCursorPosition(person.Position[0], person.Position[1]); //x y          
                Console.Write(person.Symbol);
                person.AddStatus();
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
