using System;
using System.Globalization;
using System.Net;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new();
        bool run = true;

        Console.WriteLine("Welcome to your journal! Menu options: ");
        while (run == true)
        {
            string choice = userChoice();

            switch (choice)
            {
                case "1":
                    journal.addEntry();
                    break;
                case "2":
                    journal.printEntries();
                    break;
                case "3":
                    journal.saveToFile();
                    break;
                case "4":
                    journal._entries = journal.loadFromFile();
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