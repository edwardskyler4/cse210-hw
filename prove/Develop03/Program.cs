using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new Scripture();

        Console.WriteLine("Hello user! This is a program designed to help you memorize scriptures. Please input the reference and then content of the scripture that you want to memorize. Alternatively, just hit [ENTER] to memorize Isaiah 40:31!");

        Console.Write("Reference: ");
        string reference = Console.ReadLine();

        Console.Write("Scripture: ");
        string scriptureStrContent = Console.ReadLine();

        if (reference != "" || scriptureStrContent != "")
        {
            scripture = new Scripture(reference, scriptureStrContent);
        }

        bool run = true;

        
        while (run == true) {
            Console.Clear();
            scripture.GetScripture();
            Console.WriteLine("\nPress [ENTER] or type 'quit'");
            string usrResponse = Console.ReadLine().ToLower();

            if (usrResponse == "quit" || scripture.GetUnhiddenWordCount() == 0)
            {
                run = false;
            }
            else
            {
                scripture.HideWords();
            }
        } 
    }
}