using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string userName = PromptUserName();
        int favNum = PromptUserNumber();

        int birthYear;
        PromptUserBirthYear(out birthYear);
        int squareNum = SquareNumber(favNum);
        
        DisplayResult(userName, squareNum, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int num = int.Parse(Console.ReadLine());
        return num;
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Enter your birth year: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string userName, int squaredNumber, int birthYear)
    {
        int age = 2026 - birthYear;

        Console.WriteLine($"{userName}, the square of your favorite number is {squaredNumber}");
        Console.WriteLine($"{userName}, you will turn {age} this year");
    }
}