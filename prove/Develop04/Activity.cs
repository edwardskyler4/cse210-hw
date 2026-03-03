using System;

public class Activity
{
    private string _name;
    private string _description;
    private int _seconds;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine(_description);
        Console.WriteLine("\nHow long would you like, in seconds, for this session? ");
        int seconds = int.Parse(Console.ReadLine());
        SetSeconds(seconds);
    }
    public void Pause(int seconds=3)
    {
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(seconds);
        while (now < end)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;

            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;

            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;
            
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;
        }
    }
    public void CountDown(int seconds=4)
    {
        int currentCount = seconds;
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(seconds);

        while (now < end)
        {
            Console.Write($" {currentCount}");
            Thread.Sleep(1000);
            Console.Write("\b \b");
            currentCount -= 1;
            now = DateTime.Now;
        }
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("Well done!\n");
        Pause(2);
        Console.WriteLine($"You have completed {_seconds} seconds of the {_name}");
        Pause(4);
        Console.WriteLine("\nReturning to Menu...");
        Pause(2);
    }
    public void SetSeconds(int seconds)
    {
        _seconds = seconds;
    }
    public int GetSeconds()
    {
        return _seconds;
    }
}