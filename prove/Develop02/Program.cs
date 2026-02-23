using System;
using System.Globalization;
using System.Net;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        // To add creativity, I included a csv file of prompts and code to randomly select a prompt from that csv for each entry. This is on the entries file, under the getPrompt method. I also added a feature to the entry printing in which the user can choose to print only one entry (based on date) or all of them. This can be found in the Journal file, on lines 20-65.

        Journal journal = new();
        bool run = true;

        Console.WriteLine("Welcome to your journal! Menu options: ");
        while (run == true)
        {
            string choice = userChoice();

            switch (choice)
            {
                case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.PrintEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    run = false;
                    break;
                default:
                    Console.WriteLine("You have entered an invalid input. Please enter the number of one of the meny options.");
                    break;
            }
        }
    }

    static string userChoice()
    {
            string choice;
            Console.WriteLine("\n1. Add New Entry \n2. Display Journal Entries \n3. Save Journal \n4. Load Journal\n5. Quit");
            Console.Write("Enter your choice: ");
            choice = Console.ReadLine();
            return choice;
    }
}