namespace Grupp7_TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            List<Person> people = new List<Person>();
            people = Person.CreatePerson(10, 5, 5);

            Canvas city = new Canvas(40, 20, people);
            city.PrintSimulation();
            Msg.Clear(); //Clear för så den inte skriver dubbelt


            while (true)
            {
                Console.Clear();
                
                city.UpdatePeoplePosition();
                city.PrintSimulation();

                //Msg.Print();
                Msg.Clear();
                Console.ReadKey();
            }
        }

    }
}
