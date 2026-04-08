using System.IO.Compression;
using System.Text.Json.Serialization;

// The menu can take care of deleting the goal if it's complete. Check if the type is Behvaior Goal, and if it is and GetCompetion returns true, then delete it.
class BehaviorGoal : ProgramEntry
{
    [JsonInclude]
    private bool _isComplete;

    public BehaviorGoal() : base() {}
    public BehaviorGoal(string name, string desc) : base(name, desc, "Behavior Goal")
    {
        _isComplete = false;
    }

    public override void DisplaySelf()
    {
        Console.WriteLine();
        Console.WriteLine(base.GetEntryType());
        Console.WriteLine();
        Console.WriteLine(base.GetName());
        Console.WriteLine(base.GetDescription());
        Console.WriteLine();
        Console.WriteLine($"Is complete: {_isComplete}");
        Console.WriteLine();
        Console.WriteLine("---------------------");
    }
    public bool GetCompletion()
    {
        return _isComplete;
    }
    public override void AddDataPoint()
    {
        List<string> yesNoInputs = new() { "yes", "y", "no", "n"};
        string output = Program.VerifyInput("Mark goal as complete? (y/n) ", yesNoInputs);
        if (output == "y" || output == "yes")
        {
            _isComplete = true;
        }
        else
        {
            Program.ReturnToMenuDialog();
        }
    }
}