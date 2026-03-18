using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using System.Security;

// Lessons learned: I would separate the actual functions of the program from the printing and displays. For example, rather than having the Complete Goal function pull up the whole list and have the user pick from it, I would just have it call the CompleteGoal function of the Goal class and add the points to the user's total. I would keep the printing, selection, and displays for the program class. Also, the pause method should have been in the program class rather than this one. Similar note for the CreateGoal function. I would just have that method take the goal type, name, desc, difficulty, and have an option for it to take repetitions (but set a default value for it so it isn't required), then just have the method create the class itself. Keep the user interaction parts to the program class. Besides that, I'm happy with how this class looks structurally.
class User
{
    private int _score;
    private List<Goal> _goals = new();

    public void CreateGoal()
    {
        bool run = true;
        List<string> acceptedAnswers = new();

        Console.Clear();
        acceptedAnswers.AddRange("simple", "checklist", "eternal");
        string goalType = "";
        do
        {
            Console.Write("Is your goal a SIMPLE goal, a CHECKLIST goal, or an ETERNAL goal? ");
            string ans = Console.ReadLine().ToLower();

            if (acceptedAnswers.Contains(ans))
            {
                goalType = ans;
                run = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Make sure you're spelling it right. Capitalization doesn't matter. ");
            }
        } while (run == true);

        Console.Write("Enter the name of your goal: ");
        string name = Console.ReadLine();

        Console.Write("Enter a description of your goal: ");
        string desc = Console.ReadLine();

        run = true;
        acceptedAnswers.Clear();
        acceptedAnswers.AddRange("1", "2", "3");
        int difficulty = -1;
        do
        {    
            Console.Write("Enter the difficulty level of your goal, 3 being very difficult, 1 being not difficult at all: ");
            string ans = Console.ReadLine();
            if (acceptedAnswers.Contains(ans))
            {
                difficulty = int.Parse(ans);
                run = false;
            }
            else
            {
                Console.WriteLine("Invalid input. Enter either '1', '2', or '3' depending on the difficulty of the goal.\n");
            }
        } while (run == true);

        if (goalType == "simple")
        {
            SimpleGoal goal = new(name, desc, difficulty);
            AddGoalToGoals(goal);
        }
        else if (goalType == "checklist")
        {
            Console.Write("Number of steps in the goal: ");
            int steps = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new(name, desc, difficulty, steps);
            AddGoalToGoals(goal);
        }
        else
        {
            EternalGoal goal = new(name, desc, difficulty);
            AddGoalToGoals(goal);
        }

        Console.WriteLine("Goal successfully added!");
        Pause();
    }
    public void DisplayGoals()
    {
        Console.Clear();
        Console.WriteLine("Number - Name - Description - Completion Status");
        Console.WriteLine("-------------------------------");
        int n = 0;
        foreach (Goal goal in _goals)
        {
            n += 1;
            string name = goal.GetName();
            string desc = goal.GetDesc();
            string completion = goal.GetCompletionStatus();

            Console.WriteLine($"{n}. {name} - {desc} - {completion}");
        }
    }
    public void CompleteGoal()
    {
        DisplayGoals();
        int index = -1;
        do
        {
            Console.Write("\nEnter the number of the goal you'd like to mark complete: ");
            string ans = Console.ReadLine();
            bool test = int.TryParse(ans, out int result);
            if (test && result - 1 <= _goals.Count())
            {
                index = result - 1;
            }
            else
            {
                Console.WriteLine("Invalid input. Enter a valid number.");
            }

        } while (index == -1);

        Goal goal = _goals[index];
        bool givePoints = goal.CompleteGoal();
        if (givePoints)
        {
            int points = goal.GetPoints();
            AddToScore(points);
            int newScore = GetScore();
            
            Console.WriteLine($"\nCongrats on completing your goal! Your total score is now {newScore}");
        }
        else
        {
            Console.WriteLine("You already completed this goal! Congratulations!");
        }
        Pause();
    }
    public void SaveData()
    {
        string filename = GetFilename();
        List<string> goalStrings = new();
        foreach (Goal goal in _goals)
        {
            string goalString = GoalToString(goal);
            goalStrings.Add(goalString);
        }
        string[] goalsArray = goalStrings.ToArray();
        File.WriteAllLines(filename, goalsArray);
        Console.WriteLine("Successfully saved!");
        Pause();
    }
    public void LoadData()
    {
        string filename = GetFilename();
        
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (line != "")
            {
                string[] content = line.Split(", ");
                StrArrayToGoal(content);
            }
        }

        Console.WriteLine("Successfully Loaded!");
        Pause();
    }
    private string GoalToString (Goal goal)
    {
        string goalType = goal.GetGoalType();
        string name = goal.GetName();
        string desc = goal.GetDesc();
        int difficulty = goal.GetDifficulty();
        string completion = goal.GetCompletionStatus();

        string goalString = $"{goalType}, {name}, {desc}, {difficulty}, {completion}";
        return goalString;
    }
    private void StrArrayToGoal (string[] content)
    {
        string goalType = content[0];
        string name = content[1];
        string desc = content[2];
        int difficulty = int.Parse(content[3]);
        string completion = content[4];

        if (goalType == "simple")
        {
            SimpleGoal goal = new(name, desc, difficulty);
            if (completion == "[X]")
            {
                goal.CompleteGoal();
            }
            AddGoalToGoals(goal);
        }
        else if (goalType == "checklist")
        {
            int splitIndex = completion.IndexOf("/");
            int adjustedIndex = splitIndex + 1;

            int completedRepsInt = int.Parse(completion[1..splitIndex]);

            int totalRepsInt = int.Parse(completion[adjustedIndex..^1]);

            ChecklistGoal goal = new(name, desc, difficulty, totalRepsInt);
            for (int i = 0; i <= completedRepsInt; i++)
            {
                goal.CompleteGoal();
            }
            AddGoalToGoals(goal);
        }
        else
        {
            EternalGoal goal = new(name, desc, difficulty);
            AddGoalToGoals(goal);
        }
    }
    private string GetFilename()
    {
        Console.Clear();
        Console.Write("Enter your filename: ");
        string filename = Console.ReadLine();
        return filename;
    }
    public int GetScore()
    {
        return _score;
    }
    private void AddToScore(int points)
    {
        _score += points;   
    }
    private void AddGoalToGoals(Goal goal)
    {
        _goals.Add(goal);
    }
    public void Pause(int seconds=3)
    {
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(seconds);

        Console.Write("Returning to menu... ");
        while (now < end)
        {
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;

            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;

            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;
            
            Console.Write("\\");
            Thread.Sleep(250);
            Console.Write("\b \b");
            now = DateTime.Now;
        }
    }
}