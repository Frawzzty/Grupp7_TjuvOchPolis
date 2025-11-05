using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp7_TjuvOchPolis
{
    internal class City : Canvas
    {
        public City(int width, int height, List<Person> people) : base(width, height, people)
        {

        }
        public override void UpdateMap()
        {
            UpdateDirection(DirectionMaxTick);
            UpdatePeoplePosition();
            ClearMap();

            foreach (Person personA in People)
            {
                int x = personA.PosX;
                int y = personA.PosY;
                if (Map[y, x] != null) //Detected two people on the same position.
                {
                    Person personB = Map[y, x]; //For clarity: Save other person to a variable.
                    HandleCollision(personA, personB);
                }

                Map[y, x] = personA;
            }
        }

        public void HandleCollision(Person personA, Person personB)
        {
            //Thief collides with Citizen
            if (personA is Thief && personB is Citizen || personB is Thief && personA is Citizen) 
            {
                Thief thief = personA is Thief ? (Thief)personA : (Thief)personB;
                Citizen citizen = personA is Thief ? (Citizen)personB : (Citizen)personA;

                if (citizen.Inventory.Count > 0)
                    thief.StealItem(citizen);
            }

            //Police collides with Thief
            if (personA is Thief && personB is Police || personB is Thief && personA is Police) 
            {
                Thief thief = personA is Thief ? (Thief)personA : (Thief)personB;
                Police police = personA is Thief ? (Police)personB : (Police)personA;

                if (thief.IsWanted) 
                    police.Arrest(thief);
            }
        }

        public void SendArrestedToPrison(Prison prison)
        {
            for(int i = 0; i < People.Count() - 1; i++)
            {
                if (People[i] is Thief) 
                {
                    if (((Thief)People[i]).InPrison)
                    {
                        prison.People.Add(People[i]);
                        People.Remove(People[i]);
                    }
                }
            }
        }
    }
}
