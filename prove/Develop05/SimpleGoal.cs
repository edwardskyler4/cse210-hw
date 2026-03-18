class SimpleGoal : Goal
{
    private bool _completionStatus;

    public SimpleGoal(string name, string desc, int difficulty) : base(name, desc, difficulty, "simple")
    {
        _completionStatus = false;   
    }
    public override bool CompleteGoal()
    {
        if (_completionStatus == false)
        {
            _completionStatus = true;
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string GetCompletionStatus()
    {
        string returnVal;
        if (_completionStatus == true)
        {
            returnVal = "[X]";
        }
        else
        {
            returnVal = "[ ]";
        }
        return returnVal;
    }
}