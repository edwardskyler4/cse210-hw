using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
[JsonDerivedType(typeof(Target), "target")]
[JsonDerivedType(typeof(MaladptiveBehvaior), "behavior")]
[JsonDerivedType(typeof(BehaviorGoal), "goal")]
abstract public class ProgramEntry
{
    [JsonInclude]
    private string _entryType;
    [JsonInclude]
    private string _name;
    [JsonInclude]
    private string _description;

    public ProgramEntry() {}
    public ProgramEntry(string name, string desc, string type)
    {
        _name = name;
        _description = desc;
        _entryType = type;
    }
    public string GetEntryType()
    {
        return _entryType;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public virtual void DisplaySelf()
    {
        Console.WriteLine(_entryType);
        Console.WriteLine();
        Console.WriteLine(_name);
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine("---------------------");
    }
    public virtual void EditSelf()
    {
        DisplaySelf();
        Console.WriteLine("Enter a new title or type 'skip' to keep the same one: ");
        string input = Console.ReadLine();
        if (input != "skip")
        {
            _name = input;
        }

        Console.WriteLine("\nEnter a new description or type 'skip' to keep the same one: ");
        input = Console.ReadLine();
        if (input != "skip")
        {
            _description = input;
        }
    }
    public abstract void AddDataPoint();
}