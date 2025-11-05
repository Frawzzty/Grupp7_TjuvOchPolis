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

        public void ReleasePrisoners(City city)
        {
            for (int i = 0; i < People.Count(); i++)
            {               
                if (((Thief)People[i]).InPrison == false)
                {
                    Msg.Add($"Freed {People[i].Name} from prison");
               
                    city.People.Add(People[i]);
                    People.Remove(People[i]);
                }
            }
        }

        public void UpdateTimeInPrison()
        {
            foreach (Person person in People)
            {
                ((Thief)person).SittingInPrison();
            }
        }

    }
}
