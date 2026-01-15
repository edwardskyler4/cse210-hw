using System;

class Program
{
    static void Main(string[] args)
    {
       List<int> userNums = new List<int>();
       string userInput = "";

        while (userInput != "0")
        {
            Console.WriteLine("What number would you like to add to the list? Type '0' when you want to be done. ");
            userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int result))
            {
                if (result != 0)
                {
                    Console.WriteLine($"{result} has been successfully added to the list.");
                    userNums.Add(result);
                }
            }
            else
            {
                Console.WriteLine("You have not entered a valid number.");
            }
        }

        int highest = 0;
        int smallestPositive = 999999999;
        double sum = 0;
        int count = userNums.Count();

        foreach(int num in userNums)
        {
            sum += num;
            if (num > highest)
            {
                highest = num;
            }
            if (num < smallestPositive && num > 0)
            {
                smallestPositive = num;
            }
        }
        double avg = sum / count;
        userNums.Sort();

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {avg:N1}");
        Console.WriteLine($"The largest number is {highest}");
        Console.WriteLine($"The lowest positive number is {smallestPositive}");
        Console.WriteLine($"The sorted list is:");
        foreach(int num in userNums)
        {
            Console.WriteLine(num);
        }
    }
}