class ChecklistGoal : Goal
{
    private int _stepsCompleted;
    private int _totalSteps;
    
    public ChecklistGoal(string name, string desc, int difficulty, int repetitions) : base(name, desc, difficulty, "checklist")
    {
        _stepsCompleted = 0;
        _totalSteps = repetitions;
    }
    public override int GetPoints()
    {
        int basePoints = base.GetPoints();
        int partPoints = basePoints / 5;
        if (_stepsCompleted < _totalSteps)
        {
            return partPoints;
        }
        else
        {
            return partPoints * 10;
        }
    }
    public override bool CompleteGoal()
    {
        if (_stepsCompleted < _totalSteps)
        {
            _stepsCompleted += 1;
            return true;
        }
        else
        {
            return false;
        }
    }
    public override string GetCompletionStatus()
    {
        return $"[{_stepsCompleted}/{_totalSteps}]";
    }
}