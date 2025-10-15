using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Canvas
    {
        public Person[,] Matrix { get; set; }//tempnamn //varje index har person, if index null print " "
        private int Height;
        private int Width;
        public List<Person> People { get; set; }

        public Canvas(int width, int height, List<Person> people)
        {
            Height = height;
            Width = width;
            Matrix = new Person[Height, Width];
            People = people;
            RandomPos(); 
        }

        public void Update()
        {
            //börja bygga uppdate här 
            //move person?
            //foreach person something something
            //collision check = kolla om har samma possition värde 
            //spara person pos, om pos true, placera person tecken?
            //Person.Pos
            //
        }

        public void Print()
        {

            Console.WriteLine($"╔{new string('═', Width)}╗"); //new string('<whatChar>', <howMany>) 
            for (int row = 0; row < Height; row++)
            {
                Console.Write("║");
                for (int col = 0; col < Width; col++)
                {
                    if (Matrix[row, col] == null)
                        Console.Write(" ");
                    else
                    {
                        //Console.Write(Matrix[row, col].Char);
                    }
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
                int positionX = Random.Shared.Next(0, Width);
                int positionY = Random.Shared.Next(0, Height);
                int[] position = new int[2];

                position[0] = positionX;
                position[1] = positionY;
                person.Position = position;
                Console.WriteLine($"Person:{person.Name} X:{person.Position[0]} Y:{person.Position[1]}");
            }
        }


    }
}
