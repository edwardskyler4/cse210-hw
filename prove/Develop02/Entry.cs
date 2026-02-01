using System;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;

class Entry
{
    public string _date { get; set; }
    public string _entry { get; set; }
    public string _prompt { get; set; }

    public string getPrompt()
    {
        string filename = "prompts.csv";
        string[] lines = System.IO.File.ReadAllLines(filename);

        Random promptChooser = new();
        int choice = promptChooser.Next(lines.Count());

        return lines[choice];
    }
    public string writeEntry(in string prompt)
    {
        DateTime dateTime = DateTime.Now;
        _date = dateTime.ToShortDateString();
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        string entry = "";

        bool run = true;
        while (run == true)
        {
            Console.WriteLine($"Write your entry below. Press [ENTER] when finished. ");
            entry = Console.ReadLine();

            Console.WriteLine($"\nYour entry is:\n{entry}");
            Console.Write("\nDo you accept this entry? (y/n)\nNote: if you don't, you will have to rewrite it from scratch. ");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y")
            {
                Console.WriteLine("Entry accepted. Returning to menu...");
                run = false;
            }
            else
            {
                Console.WriteLine("Rewrite your entry. ");
            }
        }

        return entry;
    }
}