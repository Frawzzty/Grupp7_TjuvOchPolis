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
        //lista med personer

        public Canvas(int width = 100, int height = 100) 
        {
            Height = height;
            Width = width;
            Matrix = new Person[Height, Width];
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

    }
}
