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

            City city = new City(100, 25, freePeople);           
            Prison prison = new Prison(50, 10, prisoners);
            bool debugMode = false;
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
                        Console.WriteLine("Role".PadRight(8) + "Name".PadRight(10) + "Position".PadRight(10) + "Direction".PadRight(16) + "Inventory".PadRight(30) + "Extra info"); //fixa

                        foreach (Person person in freePeople)
                        {
                            person.PrintDetails();
                            person.PrintInventory();
                            person.PrintRoleDetails();
                            Console.WriteLine();
                        }
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("PRISONERS IN PRISON:");
                        foreach (Person person in prisoners)
                        {
                            person.PrintDetails();
                            person.PrintInventory();
                            person.PrintRoleDetails();
                            
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        city.PrintMap();
                        prison.PrintMap();
                        Msg.PrintLast(5);
                    }
                    Thread.Sleep(200);
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                
                if (key.KeyChar == 'd') { debugMode = !debugMode; }              
            }
        }
    }
}
