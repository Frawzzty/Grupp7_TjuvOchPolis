using System.Drawing;

namespace Grupp7_TjuvOchPolis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            List<Person> freePeople = new List<Person>();
            List<Person> prisoners = new List<Person>();
            freePeople = Person.CreatePerson(20, 10, 15);

            City city = new City(100, 20, freePeople);           
            Prison prison = new Prison(50, 5, prisoners);

            bool debugMode = false;

            while (true)
            {                
                
                while (!Console.KeyAvailable)
                {
                    Console.Clear();
                    Console.Write("\u001bc\x1b[3J"); //Helps clearing things drawn outside of frame. Removes artifacts 

                    Stats.Time++;
                    city.UpdateMap();
                    prison.UpdateMap();
                    city.SendArrestedToPrison(prison);
                    prison.UpdateTimeInPrison();
                    prison.ReleasePrisoners(city);

                    if (!debugMode)
                    {
                        city.PrintMap();
                        //Msg.PrintLastToSide(5, 100, 25);
                        prison.PrintMap();
                        Msg.PrintLast(5);
                        Stats.Print();
                    }
                    else
                    {
                        Console.WriteLine("Role".PadRight(8) + "Name".PadRight(10) + "Position".PadRight(10) + "Direction".PadRight(16) + "Inventory".PadRight(30) + "Extra info");

                        foreach (Person person in freePeople)
                        {
                            person.PrintInformation();
                        }
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("PRISONERS IN PRISON:");
                        foreach (Person person in prisoners)
                        {
                            person.PrintInformation();
                        }
                    }
                    Thread.Sleep(400);
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (key.KeyChar == 'd') { debugMode = !debugMode; }              
            }
        }
    }
}
