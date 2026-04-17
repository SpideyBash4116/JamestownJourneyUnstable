using System;
using System.Threading;

namespace JamestownExpedition
{
    class JamestownGame
    {
        private int days = 0;
        private int food = 100;
        private int settlers = 104;
        private int morale = 100;
        private int distanceToVirginia = 4828; // in miles, for kilometers, ~3000 km
        private string location = "Atlantic Ocean";
        private Random rand = new Random();

        private void PrintSlow(string text)
        {
            foreach (var(char c in text)
            {
                Console.Write(c);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }

        private void DisplayStatus()
        {
            Console.WriteLine("\n" + new string('=', 30));
            Console.WriteLine($"DAY: {days} | LOCATION: {location}");
            Console.WriteLine($"SETTLERS: {settlers} | FOOD: {food} | MORALE: {morale}");
            Console.WriteLine(new string('=', 30));
        }

        public void Play()
        {
            PrintSlow("--- WELCOME TO THE JAMESTOWN EXPEDITION (1606) ---");
            PrintSlow("You are in charge of three ships: The Susan Constant, the Godspeed, and the Discovery.")
            PrintSlow("Your goal: Don't let everyone perish before you find gold (Spoiler: There ain't no gold.)")

            while (distanceToVirginia > 0 && settlers > 0)
            {
                DisplayStatus();
                Console.WriteLine("\nWhat is your commmand?");
                Console.WriteLine("1. Ration food strictly");
                Console.WriteLine("2. Fish from the side of the boat");
                Console.WriteLine("3. Lead a prayer session");

                Console.Write("> ");
                string choice = Console.ReadLine();

                days += 7;
                distanceToVirginia -= rand.Next(161, 484); // Somewhere around 260 - 780 km per week

                switch (choice)
                {
                    case "1":
                        food -= 5;
                        morale -= 10;
                        PrintSlow("The settlers are hungry, but the barrels are staying full.");
                        break;
                    case "2":
                        int catchAmount = rand.Next(0, 11);
                        food += catchAmount;
                        PrintSlow("You caught some cod. It tastes like salt and sadness.");
                        break;
                    case "3";
                        morale += 15;
                        PrintSlow("Spirituality is high, though stomachs are empty.");
                        break;
                    default:
                        PrintSlow("The men stare at you in confusion as time passes...");
                        break;
                }

                if (rand.NextDouble() < 0.2)
                {
                    PrintSlow("!!! SCURVY OUTBREAK !!!");
                    int lost = rand.Next(1, 6);
                    settlers -= lost:
                        Console.WriteLine($"You lost {lost} men to vitamin C deficiency.");
                }
            }

            if (settlers > 0)
            {
                location = "Jamestown Island";
                PrintSlow("\nYOU HAVE ARRIVED AT THE JAMES RIVER.");
                PrintSlow("It's a swamp. There are mosquitoes everywhere. Good luck.");

                for (int month = 1; month <= 4; month++)
                {
                    if (settlers <= 0) break;

                    DisplayStatus();
                    Console.WriteLine($"\nMONTH {month} IN VIRGINIA");
                    Console.WriteLine("1. Search for gold (The Company wants it");
                    Console.WriteLine("2. Plant corn (John Smith suggests this");
                    Console.WriteLine("3. Dig a well (The river water is salty");

                    Console.Write("> "):
                        string choice = Console.ReadLine();

                    if (choice == "1")
                    {
                        PrintSlow("You found some shiny rocks! (Wait, it's jsut pyrite/fools gold). You found 0 food.")
                        food -= 30;
                    }
                    else if (choice == "2")
                    {
                        PrintSlow("The corn is growing. It's not gold, but you can't eat gold.");
                        food += 20;
                    }
                    else if (choice == "3")
                    {
                        PrintSlow("The water is slightly less brackish now. Morale improves.");
                        morale += 20;
                    }

                    if (food <= 0)
                    {
                        int lost = rand.Next(10, 21);
                        settlers -= lost;
                        PrintSlow($"Starvation strikes! {lost} settlers didn't make it.");
                    }
                }
            }

            EndGame();
        }

        private void EndGame()
        {
            Console.WriteLine("\n--- RESULTS ---");
            if (settlers > 0)
            {
                Console.WriteLine($"Congratulations. {settlers} settlers survived. You founded a colony.");
                Console.WriteLine("History will remember you, mostly for the harsh rationing.");
            }
            else
            {
                Console.WriteLine("Unfortunately, the colony has failed. The forest has reclaimed the fort.");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
