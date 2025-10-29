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
            freePeople = Person.CreatePerson(10, 10, 10);

            City city = new City(40, 20, freePeople);           
            Prison prison = new Prison(40, 10, prisoners);
            bool debugMode = true;
            int tick = 0;

            Msg.Clear(); //Clear för så den inte skriver dubbelt

            while (true)
            {                
                
                while (!Console.KeyAvailable)
                {
                    Console.Clear();
                    Console.Write("\u001bc\x1b[3J"); //Helps clearing things drawn outside of frame. Removes artifacts 

                    city.UpdateMap();
                    prison.UpdateMap();
                    city.SendPrisonersToPrison(prison);
                    prison.UpdatePrisonTime();
                    prison.SendFreePrisonersToCity(city);

                    if (debugMode)
                    {
                        Console.WriteLine("Profesion | Name | position | direcction | inventory |");

                        foreach (Person person in freePeople)
                        {
                            person.PrintDetails();
                            person.PrintRoleDetails();
                            person.PrintInventory();
                            Console.WriteLine();
                        }
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("PRISONERS IN PRISON:");
                        foreach (Person person in prisoners)
                        {
                            person.PrintDetails();
                            person.PrintRoleDetails();
                            person.PrintInventory();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        city.PrintMap();
                        prison.PrintMap();
                        Msg.PrintLast(10);
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
                    Thread.Sleep(500);
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (key.KeyChar == 'd') { debugMode = !debugMode; }              
            }
        }
    }
}
