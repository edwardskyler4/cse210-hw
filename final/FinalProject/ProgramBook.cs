using System.Text.Json.Serialization;

class ProgramBook
{
    [JsonInclude]
    private List<ProgramEntry> _programs = new();

    public ProgramBook() {}
    public ProgramEntry GetProgram(int index)
    {
        if (index >= 0 && index < _programs.Count)
        {
            return _programs[index];   
        }
        else
        {
            return null;
        }
    }
    public void DisplayProgramBook()
    {
        if (_programs.Count == 0)
        {
            Console.WriteLine("No entries found. ");
        }
        else
        {
            foreach (ProgramEntry program in _programs)
            {
                program.DisplaySelf();
            }
        }
    }
    public void DisplayProgramList()
    {
        for (int i = 0; i < _programs.Count; i++)
        {
            ProgramEntry program = _programs[i];
            int number = i + 1;
            string name = program.GetName();
            string type = program.GetEntryType();

            Console.WriteLine($"{number}. {type}-{name}");
        }
    }
    public void RemoveProgram(int index)
    {
        if (index < _programs.Count)
        {
            ProgramEntry program = _programs[index];
            string type = program.GetEntryType();
            string name = program.GetName();
            _programs.RemoveAt(index);
            Console.WriteLine($"Program {type}-{name} has sucessfully been removed");
        }
        else
        {
            Console.WriteLine("Program does not exist at that index");
        }
    }
    public void AddTarget()
    {
        Console.WriteLine("Enter the title of the target: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the details of the target: ");
        string details = Console.ReadLine();

        Target newTarget = new(name, details);
        _programs.Add(newTarget);

        Console.WriteLine("--- Target Successfully Added ---\n");
    }
    public void AddMaladaptiveBehavior()
    {
        Console.WriteLine("Enter the title of the maladaptive behavior: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the details of the maladaptive behavior: ");
        string details = Console.ReadLine();

        MaladptiveBehvaior newBx = new(name, details);
        _programs.Add(newBx);

        Console.WriteLine("--- Maladptive Behavior Successfully Added ---\n");
    }
    public void AddBehaviorGoal()
    {
        Console.WriteLine("Enter the title of the goal: ");
        string name = Console.ReadLine();

        Console.WriteLine("Enter the details of the goal: ");
        string details = Console.ReadLine();

        BehaviorGoal newGoal = new(name, details);
        _programs.Add(newGoal);

        Console.WriteLine("--- Behavior Goal Successfully Added ---\n");
    }
}