namespace Grupp7_TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<Person> freePeople = new List<Person>();
            List<Person> prisoners = new List<Person>();
            freePeople = Person.CreatePerson(10, 10, 10);

            City city = new City(40, 20, freePeople);           
            Prison prison = new Prison(40, 10, prisoners);

            int tick = 0;

            Msg.Clear(); //Clear för så den inte skriver dubbelt

            while (true)
            {                
                Console.Clear();
                Console.Write("\u001bc\x1b[3J"); //Helps clearing things drawn outside of frame. Removes artifacts

                city.UpdateMap();
                prison.UpdateMap();
                city.PrintMap();
                city.SendPrisonersToPrison(prison);
                prison.UpdatePrisonTime();
                prison.PrintMap();
                prison.SendFreePrisonersToCity(city);
                
                
                Msg.PrintLast(10);
                

                foreach (Person person in freePeople)
                {
                    Console.WriteLine(person.Description());
                }

                Console.WriteLine("----------------------------------");
                Console.WriteLine("FOlK I FÄNGELSE");
                foreach (Person person in prisoners)
                {
                    Console.WriteLine(person.Description());
                }


                tick++; //Give new direction after five ticks
                if (tick == 5)
                {
                    tick = 0;
                    foreach (Person person in freePeople)
                    {
                        person.SetDirection();
                    }
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.KeyChar == 'x') { Msg.Clear(); }
                //Thread.Sleep(200);
        
            }
        }
    }
}
