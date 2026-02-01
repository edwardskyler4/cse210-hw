using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using System.Dynamic;

class Journal
{
    public List<Entry> _entries { get; set; } = new();

    public void addEntry()
    {
        Entry entry = new Entry();
        entry._prompt = entry.getPrompt();
        entry._entry = entry.writeEntry(entry._prompt);

        _entries.Add(entry);
    }
    public void printEntries()
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
                    printSingleEntry(entry);
                }
                Console.Write("\nPress [ENTER] to return to menu.");
                Console.ReadLine();
            }
            else if (dates.Contains(response))
            {
                printSingleEntry(_entries[dates.IndexOf(response)]);
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
    private void printSingleEntry(in Entry entry)
    {
        Console.WriteLine();
        Console.WriteLine($"Date: {entry._date}");
        Console.WriteLine($"Prompt: {entry._prompt}");
        Console.WriteLine($"Your Entry: {entry._entry}");
    }
    public void saveToFile()
    {
        string filename = getFilename();

    
        string json = JsonSerializer.Serialize(_entries);
        File.WriteAllText(filename, json);

        Console.WriteLine("Successfully Saved.");
    }
    public List<Entry> loadFromFile()
    {
        List<Entry> entries = new();
        string filename = getFilename();
        
        string jsons = System.IO.File.ReadAllText(filename);
        List<Entry> entriesList = JsonSerializer.Deserialize<List<Entry>>(jsons);
        
        foreach (Entry entry in entriesList)
        {
            entries.Add(entry);
        }
        Console.WriteLine("Successfully Loaded");
        return entries;
    }
    private string getFilename()
    {
        string filename;
        Console.Write("Enter the filename you would like to save to (use a .json file): ");
        filename = Console.ReadLine();
        return filename;
    }
}