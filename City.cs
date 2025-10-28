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
            UpdatePeoplePosition();
            ClearMap(); //Array.Clear(Map);

            foreach (Person personA in People)
            {
                int x = personA.PosX;
                int y = personA.PosY;
                if (Map[y, x] != null) // Collision detected //Bug när fler kliver på varandra? Skippar en check
                {
                    Person personB = Map[y, x]; //Person som redan står på rutan
                    HandleCollision(personA, personB); //beröm till patrik för variable namn
                }

                Map[y, x] = personA;
                //skulle kunna ha SetDirection() här
            }
        }

        public void HandleCollision(Person personA, Person personB) //Keep?
        {
            Msg.Add($"Collision Detected X:{personA.PosX} Y:{personA.PosY} - {personA.GetType().Name} {personA.Name} vs {personB.GetType().Name} {personB.Name}");

            if (personA is Thief && personB is Citizen || personB is Thief && personA is Citizen) //Tjuv kolliderar med citizen
            {
                Thief thief = personA is Thief ? (Thief)personA : (Thief)personB;
                Citizen citizen = personA is Thief ? (Citizen)personB : (Citizen)personA;

                if (citizen.Inventory.Count > 0)
                    thief.StealItem(citizen);
            }

            if (personA is Thief && personB is Police || personB is Thief && personA is Police) //Polis kolliderar med Tjuv 
            {
                Thief thief = personA is Thief ? (Thief)personA : (Thief)personB;
                Police police = personA is Thief ? (Police)personB : (Police)personA;

                if (thief.IsWanted) police.Arrest(thief);
            }
        }

        public void SendPrisonersToPrison(Prison prison)
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
