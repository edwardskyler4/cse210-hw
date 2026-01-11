using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade? ");
        string grade = Console.ReadLine();
        float numGrade = float.Parse(grade);

        string letterGrade = "";
        string signGrade = "";

        // Letter grade
        if (numGrade > 89)
        {
            letterGrade = "A";
        }
        else if (numGrade > 79)
        {
            letterGrade = "B";
        }
        else if (numGrade > 69)
        {
            letterGrade = "C";
        }
        else if (numGrade > 59)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Sign grade
        if (numGrade % 10 >= 7)
        {
            signGrade = "+";
        }
        else if (numGrade % 10 <= 3)
        {
            signGrade = "-";
        }
        else
        {
            signGrade = "";
        }

        // Print logic
        if (letterGrade == "A" && signGrade != "-" || letterGrade == "F")
        {
            Console.WriteLine($"Your grade is {letterGrade}");
        }
        else
        {
            Console.WriteLine($"Your grade is {letterGrade}{signGrade}");
        }

        if (numGrade >= 70)
        {
            Console.WriteLine("You passed! Good Job!");
        }
        else
        {
            Console.WriteLine("You didn't pass. You can do it if you try again though!");
        }
    }
}