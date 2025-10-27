namespace Grupp7_TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<Person> freePeople = new List<Person>();
            freePeople = Person.CreatePerson(10, 5, 10);
            Canvas city = new Canvas(40, 20, freePeople);
            
            Canvas prison = new Canvas(40, 20, freePeople);



            Msg.Clear(); //Clear för så den inte skriver dubbelt

            while (true)
            {
                Console.Clear();
                Console.Write("\u001bc\x1b[3J"); //Helps clearing things drawn outside of frame. Removes artifacts

                city.UpdateMap();
                city.PrintMap();

                //Msg.Print();
                //Msg.Clear();

                foreach (Person person in freePeople)
                {
                    Console.WriteLine(person.Description());
                }

                //ConsoleKeyInfo key = Console.ReadKey(true);
                //if (key.KeyChar == 'x') { Msg.Clear(); }
                Thread.Sleep(200);
        
            }
        }
    }
}
