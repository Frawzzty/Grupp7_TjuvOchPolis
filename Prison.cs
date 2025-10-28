using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class Prison : Canvas
    {
        public Prison(int width, int height, List<Person> people) : base(width, height, people)
        {


        }

        public void SendFreePrisonersToCity(City city)
        {
            for (int i = 0; i < People.Count() - 1; i++)
            {
                Console.WriteLine(((Thief)People[i]).InPrison);
                Console.WriteLine(((Thief)People[i]).InPrison);
                Console.WriteLine(((Thief)People[i]).InPrison);
                Console.WriteLine(((Thief)People[i]).InPrison);
                Console.WriteLine(((Thief)People[i]).InPrison);

                if (((Thief)People[i]).InPrison == false)
                    {
                        city.People.Add(People[i]);
                        People.Remove(People[i]);
                    }
            }
        }

        public void UpdatePrisonTime()
        {
            foreach (Person person in People)
            {
                ((Thief)person).SittingInPrison();
            }
        }

    }
}
