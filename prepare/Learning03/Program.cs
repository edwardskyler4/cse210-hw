using System;
using System.Diagnostics;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Fraction whole1 = new();
        Fraction whole6 = new(6);
        Fraction fract67 = new(6, 7);

        Console.WriteLine("Constructors:");
        Console.WriteLine(whole1.GetFractionString());
        Console.WriteLine(whole6.GetFractionString());
        Console.WriteLine(fract67.GetFractionString());

        whole6.SetTop(9);
        whole6.SetBottom(2);

        Console.WriteLine("\nGetters and Setters:");
        Console.WriteLine(whole6.GetFractionString());

        Fraction whole5 = new(5);
        Fraction fract34 = new(3, 4);
        Fraction fract13 = new(1, 3);

        Console.WriteLine("\nRepresentations");
        Console.WriteLine(whole1.GetFractionString());
        Console.WriteLine(whole1.GetDecimalValue());
        Console.WriteLine(whole5.GetFractionString());
        Console.WriteLine(whole5.GetDecimalValue());
        Console.WriteLine(fract34.GetFractionString());
        Console.WriteLine(fract34.GetDecimalValue());
        Console.WriteLine(fract13.GetFractionString());
        Console.WriteLine(fract13.GetDecimalValue());

        Console.WriteLine("\nLooping Randoms");
        for (int i=0; i < 25; i++)
        {
            Random random = new Random();
            int top = random.Next(1, 100);
            int bottom = random.Next(1, 100);
            Fraction fraction = new();

            fraction.SetTop(top);
            fraction.SetBottom(bottom);

            Console.WriteLine($"Fraction {i + 1}: string: {fraction.GetFractionString()} Number: {Math.Round(fraction.GetDecimalValue(), 2)}");
        }
    }
}