using System;
using System.Transactions;

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.") {}

    public void RunActivity()
    {
        DisplayStartingMessage();
        int runSeconds = GetSeconds();
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(runSeconds);

        Console.Clear();
        Console.WriteLine("Get Ready...");
        Pause();

        while (now < end)
        {     
            Console.Write("\nBreath In...");
            CountDown();
            Console.Write("\nBreath Out...");
            CountDown();
            Console.Write("\n");
            now = DateTime.Now;
        }
        DisplayEndingMessage();
    }
}