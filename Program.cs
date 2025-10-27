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

            Canvas city = new Canvas(40, 20, freePeople);           
            Canvas prison = new Canvas(40, 10, prisoners);

            int tick = 0;

            Msg.Clear(); //Clear för så den inte skriver dubbelt

            while (true)
            {                
                Console.Clear();
                Console.Write("\u001bc\x1b[3J"); //Helps clearing things drawn outside of frame. Removes artifacts

                city.UpdateMap();
                prison.UpdateMap();
                city.PrintMap();              
                prison.People = city.GetPrisoners();
                prison.PrintMap();
                
                Msg.Print();
                Msg.Clear();

                //foreach (Person person in freePeople)
                //{
                //    Console.WriteLine(person.Description());
                //}

                tick++;
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
