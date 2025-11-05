using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Canvas
    {
        public Person[,] Map { get; set; }
        public int Height;
        public int Width;
        public int DirectionMaxTick = 10;
        public List<Person> People { get; set; }

        public Canvas(int width, int height, List<Person> people)
        {
            Height = height;
            Width = width;
            Map = new Person[Height, Width];
            People = people;
            SetRandomPosition(); 
        }
        public void ClearMap()
        {
            for (int row = 0; row < Height; row++) 
            {
                for (int col = 0; col < Width; col++)
                {
                    Map[row, col] = null;
                }
            }
        }

        public virtual void UpdateMap()
        {
            UpdateDirection(DirectionMaxTick);
            UpdatePeoplePosition();
            ClearMap();

            //Places each person on the matrix
            foreach (Person personA in People)
            {
                int x = personA.PosX;
                int y = personA.PosY;

                Map[y, x] = personA;         
            }
        
        }      

        public void PrintMap() //VIRTUAL OVERRIDE / CITY
        {
            string place = GetType().Name.ToUpper();

            // Console.WriteLine(GetType().Name);
            Console.WriteLine($"╔══ {place} {new string('═', Width - place.Length - 4)}╗");
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
        public void SetRandomPosition() // sets random position
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

        private int tick = 0;
        public void UpdateDirection(int tickMax)
        {
            tick++; //Give new direction after five ticks
            if (tick == tickMax)
            {
                tick = 0;
                foreach (Person person in People)
                {
                    person.SetRandomDirection();
                }
            }
        }
    }
}
