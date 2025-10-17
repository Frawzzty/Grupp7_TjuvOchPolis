using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Citizen : Person
    {
        public Citizen(string name) : base (name)
        {
            Symbol = "M";
        }
    }
}
