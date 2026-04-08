using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

// If I wanted to I could make a method in this class that takes in a timeframe, then calculates a rate, then zeros out the instances of the behavior. I could call it in the program book class and add the start and end session methods to that class.
class MaladptiveBehvaior : ProgramEntry
{
    [JsonInclude]
    private int _instances;

    public MaladptiveBehvaior() : base() {}
    public MaladptiveBehvaior(string name, string desc) : base(name, desc, "Maladaptive Behvaior")
    {
        _instances = 0;
    }
    public override void DisplaySelf()
    {
        Console.WriteLine();
        Console.WriteLine(base.GetEntryType());
        Console.WriteLine();
        Console.WriteLine(base.GetName());
        Console.WriteLine(base.GetDescription());
        Console.WriteLine();
        Console.WriteLine($"Behavior Instances: {_instances}");
        Console.WriteLine();
        Console.WriteLine("---------------------");
    }
    public override void AddDataPoint()
    {
        bool run = true;
        int instances = 0;
        while (run == true)
        {
            Console.WriteLine("How many instances of this behavior would you like to record? ");
            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int intUsrInput))
            {
                run = false;
                instances = intUsrInput;
            }
            else
            {
                Console.WriteLine("--- Invalid input. Try again ---");
            }
        }

        _instances += instances;
        if (instances > 1)
        {
            Console.WriteLine($"Successfully added {instances} instances. ");
        }
        else
        {
            Console.WriteLine($"Successfully added {instances} instance. ");
        }
    }
}