public abstract class Goal {
    private int _pointValue;
    private string _goalName;
    private string _goalDesc;
    private int _difficulty;
    private string _goalType;

    public Goal(string name, string desc, int difficulty, string goalType)
    {
        _goalName = name;
        _goalDesc = desc;
        _difficulty = difficulty;
        _goalType = goalType;
        if (difficulty == 3)
        {
            _pointValue = 100;
        } 
        else if (difficulty == 2)
        {
            _pointValue = 50;
        }
        else
        {
            _pointValue = 25;
        }
    }
    public string GetName()
    {
        return _goalName;
    }
    public string GetDesc()
    {
        return _goalDesc;
    }
    public int GetDifficulty()
    {
        return _difficulty;
    }
    public string GetGoalType()
    {
        return _goalType;
    }
    public virtual int GetPoints()
    {
        return _pointValue;
    }
    public abstract bool CompleteGoal();
    public abstract string GetCompletionStatus();
}