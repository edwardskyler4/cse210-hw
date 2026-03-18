class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int difficulty) : base(name, desc, difficulty, "eternal") {}

    public override bool CompleteGoal()
    {
        Console.WriteLine("This goal cannot ever be truly completed, but you have done well at it today.");
        return true;
    }
    public override string GetCompletionStatus()
    {
        return "N/A";
    }
}