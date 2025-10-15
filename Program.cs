namespace Grupp7_TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();

            List<Person> people = new List<Person>();
            people = Person.CreatePerson(20);


            Canvas city = new Canvas(20, 10, people);
            city.Print();
        }

    }
}
