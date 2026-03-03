using System;

class ListingActivity : Activity
{
    private List<string> _questions = new();

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        PopulateQuestions();
    }
    public void RunActivity()
    {
        DisplayStartingMessage();
        int runSeconds = GetSeconds();
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(runSeconds);
        
        string question = GetQuestion();
        int responseCount = 0;

        Console.Clear();
        Console.WriteLine("Get Ready...");
        Pause();
        Console.WriteLine("\nList as many responses as you can to the following question:");
        Console.WriteLine($"\n--- {question} ---\n");

        Console.WriteLine("You may begin in: ");
        CountDown(4);
        Console.Write("\n");

        while (now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            responseCount += 1;
            Console.WriteLine();
            now = DateTime.Now;
        }
        Console.WriteLine($"You listed {responseCount} items!");
        DisplayEndingMessage();
    }
    private void PopulateQuestions()
    {
       _questions.AddRange("Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"); 
    }
    private string GetQuestion()
    {
        Random randomPicker = new();
        int promptListLen = _questions.Count;
        int index = randomPicker.Next(0, promptListLen);
        string prompt = _questions[index];
        return prompt;
    }
}