namespace Grupp7_TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            List<Person> people = new List<Person>();
            people = Person.CreatePerson(2);


            Canvas city = new Canvas(20, 10, people);
            city.PrintSimulation();
            while (true)
            {
                Console.ReadKey();
                Console.Clear();
                city.UpdatePeoplePosition();
                city.PrintSimulation();               
            }
        }

    }
}
