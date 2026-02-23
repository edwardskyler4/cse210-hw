using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Dynamic;
using Microsoft.VisualBasic;

class Journal
{
    private List<Entry> _entries = new();

    public void AddEntry()
    {
        Entry entry = new Entry();
        entry._prompt = entry.getPrompt();
        entry._entry = entry.writeEntry(entry._prompt);

        _entries.Add(entry);
    }
    public void PrintEntries()
    {
        if (_entries.Count > 0)
        {
            List<string> dates = new();

            string response;
            Console.WriteLine($"\nYou have {_entries.Count} entries. Type the date of the entry you want to see, or type 'all' to see all of them. ");
            foreach (Entry item in _entries)
            {
                dates.Add(item._date);
                Console.WriteLine(item._date);
            }

            response = Console.ReadLine();

            if (response == "all")
            {
                foreach (Entry entry in _entries)
                {
                    PrintSingleEntry(entry);
                }
                Console.Write("\nPress [ENTER] to return to menu.");
                Console.ReadLine();
            }
            else if (dates.Contains(response))
            {
                PrintSingleEntry(_entries[dates.IndexOf(response)]);
            }
            else
            {
                Console.WriteLine("Invalid input entered. Returning to menu...");
            }
        }
        else
        {
            Console.WriteLine("Sorry, you don't appear to have any entries. Try writing some or loading your journal from another file.");
        }
    }
    private void PrintSingleEntry(in Entry entry)
    {
        Console.WriteLine();
        Console.WriteLine($"Date: {entry._date}");
        Console.WriteLine($"Prompt: {entry._prompt}");
        Console.WriteLine($"Your Entry: {entry._entry}");
    }
    public void SaveToFile()
    {
        string filename = GetFilename();
    
        foreach (Entry entry in _entries)
        {
            string date = entry._date;
            string prompt = entry._prompt;
            string userInput = entry._entry;
            string comboString = "\n" + date + "|" + prompt + "|" + userInput;
            File.AppendAllText(filename, comboString);
        }

        Console.WriteLine("Successfully Saved.");
    }
    public void LoadFromFile()
    {
        string filename = GetFilename();
        
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (line != "")
            {
                Entry entry = new();
                string[] data = line.Split("|");
                entry._date = data[0];
                entry._prompt = data[1];
                entry._entry = data [2];
                _entries.Add(entry);
            }
        }
        Console.WriteLine("Successfully Loaded");
    }
    private string GetFilename()
    {
        string filename;
        Console.Write("Enter the filename you would like to save to: ");
        filename = Console.ReadLine();
        return filename;
    }
}