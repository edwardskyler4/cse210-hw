using System;


// To add creativity, I coded the prompt/question generation so that duplicates aren't shown.
class Program
{
    static void Main(string[] args)
    {
        bool run = true;

        while (run == true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine("Select an option from the menu: ");

            string userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                BreathingActivity activity = new();
                activity.RunActivity();
            } else if (userChoice == "2")
            {
                ReflectionActivity activity = new();
                activity.RunActivity();
            } else if (userChoice == "3")
            {
                ListingActivity activity = new();
                activity.RunActivity();
            } else if (userChoice == "4")
            {
                run = false;
                Console.Clear();
                Console.WriteLine("Goodbye!");
            } else
            {
                Console.WriteLine("Invalid input. Please try again in 3 seconds.");
                Thread.Sleep(3000);
            }
        }
    }
}