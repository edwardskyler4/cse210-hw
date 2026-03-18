using System;

class Program
{
    static void Main(string[] args)
    {
        string completion = "[4028/4028]";
        int splitIndex = completion.IndexOf("/");

        string completedRepsStr = completion[1..splitIndex];
        Console.WriteLine(completedRepsStr);

        int adjustedIndex = splitIndex + 1;
        string totalRepsStr = completion[adjustedIndex..^1];
        Console.WriteLine(totalRepsStr);

    }
}