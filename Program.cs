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

            Msg.Add("msg test 1");
            Msg.Add("msg test 2");
            Msg.Add("Last msg");
            Msg.Print();
            Msg.PrintLast();
            Msg.Clear();
            Msg.Add("all messages have been cleared");
            Msg.Print();
        }

    }
}
