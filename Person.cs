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
        public int[] Position { get; set; }
        public int[] Direction { get; set; } //X -1, Y 0
        //public List<Item> Inventroy { get; set; } //Skapa Item klass

        public Person(string name, int[] position, int[] direction)
        {
            Name = name;
            Position = position;
            Direction = direction;
        }


        public void Move() //Move Person. call function in canvas
        {
            //Can move?
        }

    }
}
