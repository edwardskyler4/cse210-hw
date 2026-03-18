using System;
// Known bug: saving only saves your goals, not your score. I'm okay with some points getting docked for this. I figured I should just turn in what I have given that my assignment is already ~5 days late. I may come back and fix this, then resubmit.
// Creativity: I added a user class that takes care of every function relating to the program. This class opens the way in the future to be able to save content by user, including saving usernames.
// Areas to improve: if I have time later, I want to come back and add the option to delete a goal.
class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        User user = new();

        while (run == true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to your Goals Tracker!");
            Console.WriteLine("Please select a menu option by typing its number.");
            Console.WriteLine("   1. Create a goal");
            Console.WriteLine("   2. View your goals");
            Console.WriteLine("   3. Mark a goal complete");
            Console.WriteLine("   4. View your total score");
            Console.WriteLine("   5. Save");
            Console.WriteLine("   6. Load");
            Console.WriteLine("   7. Quit");
            Console.Write("Enter your selection: ");
            string ans = Console.ReadLine();

            if (ans == "1")
            {
                user.CreateGoal();
            }
            else if (ans == "2")
            {
                user.DisplayGoals();
                Console.Write("\nPress [ENTER] to return to menu");
                Console.ReadLine();
            }
            else if (ans == "3")
            {
                user.CompleteGoal();
            }
            else if (ans == "4")
            {
                int score = user.GetScore();
                Console.WriteLine($"Your score is: {score}");
                user.Pause();
            }
            else if (ans == "5")
            {
                user.SaveData();
            }
            else if (ans == "6")
            {
                user.LoadData();
            }
            else if (ans == "7")
            {
                Console.WriteLine("Goodbye!");
                run = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
                user.Pause();
            }
        }
    }
}