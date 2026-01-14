using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        bool play = true;

        do
        {
            Random randomGenerator = new Random();
            int magicNum = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            do
            {
                guessCount ++;

                Console.WriteLine("Enter your guess: ");
                guess = int.Parse(Console.ReadLine());

                if (guess > magicNum)
                {
                 Console.WriteLine("Lower");   
                }
                else if (guess < magicNum)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"Correct! It took you {guessCount} guesses");
                }
            } while (guess != magicNum);

            Console.WriteLine("Would you like to play again? y/n");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "n")
            {
                play = false;
            }
        } while (play == true);

        Console.Write("Thanks for playing!");
    }
}