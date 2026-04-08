using System.Text.Json.Serialization;

class Target : ProgramEntry
{
    [JsonInclude]
    private List<string> _dataOptions = new();
    [JsonInclude]
    private double _score;
    [JsonInclude]
    private double _trialsRun;
    [JsonInclude]
    private double _trialsInd;

    public Target() : base() {}
    public Target(string name, string desc) : base(name, desc, "Target")
    {
        _score = 0;
        EditOptions();
    }
    public List<string> GetOptionsList()
    {
        return _dataOptions;
    }
    public override void DisplaySelf()
    {
        Console.WriteLine();
        Console.WriteLine(base.GetEntryType());
        Console.WriteLine();
        Console.WriteLine(base.GetName());
        Console.WriteLine(base.GetDescription());
        Console.WriteLine();
        Console.WriteLine($"Avg Independent: {_score}");
        Console.WriteLine();
        Console.WriteLine("---------------------");
    }
    public override void EditSelf()
    {
        base.EditSelf();

        Console.WriteLine("Your current data input options are: ");
        foreach (string option in _dataOptions)
        {
            Console.Write($"{option} | ");
        }
        Console.WriteLine("If you would like to edit these options, press enter, otherwise type 'skip': ");
        string input = Console.ReadLine();
        if (input != "skip")
        {
            EditOptions();
        }
    }
    private void EditOptions()
    {
        List<string> options = new() { "Ind", "Repeat SD", "Gesture", "Partial Physical", "Full Physical", "Partial Verbal", "Full Verbal", "Err", "NR" };

        string input = "";
        while (input != "quit")
        {
            for (int i=0; i < options.Count; i++)
            {
                Console.Write($"{i+1}. {options[i]}");
                if (_dataOptions.Contains(options[i]))
                {
                    Console.WriteLine(" [X]");
                }
                else
                {
                    Console.WriteLine(" [ ]");
                }
            }

            List<string> acceptedInputs = new() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "quit" };
            input = Program.VerifyInput("Enter the number of the option to remove/add or type 'quit' to exit: ", acceptedInputs);

            if (input == "quit")
            {
                Console.WriteLine();
            }
            else
            {
                int intInput = int.Parse(input);
                int index = intInput - 1;
                string option = options[index];
                if (_dataOptions.Contains(option))
                {
                    _dataOptions.Remove(option);
                    Console.WriteLine($"--- {option} has been removed ---");
                }
                else
                {
                    _dataOptions.Add(option);
                    Console.WriteLine($"--- {option} has been added ---");
                }
            }
        }
        
    }
    public override void AddDataPoint()
    {
        List<int> intAnswers = Enumerable.Range(1,_dataOptions.Count+1).ToList();
        List<string> acceptedAnswers = new();
        foreach (int n in intAnswers)
        {
            string numStr = n.ToString();
            acceptedAnswers.Add(numStr);
        }
        acceptedAnswers.Add("quit");
        
        bool run = true;
        while (run == true)
        {
            for (int i=0; i < _dataOptions.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_dataOptions[i]}");
            }
            string answer = Program.VerifyInput("Enter the number of the response to record or type 'quit' to finish: ", acceptedAnswers);

            if (answer == "quit")
            {
                run = false;
                Console.WriteLine("Data collection completed.");
            }
            else
            {
                _trialsRun += 1;
            }

            if (_dataOptions[int.Parse(answer)-1] == "Ind")
            {
                _trialsInd += 1;               
            }

            Console.WriteLine();
            List<string> yesNoInputs = new() { "yes", "y", "no", "n"};
            answer = Program.VerifyInput("Would you like to record another response (y/n)? ", yesNoInputs);
            if (answer == "no" || answer == "n")
            {
                run = false;
                Console.WriteLine("Data collection completed.");
            }
        }  
        CalculateScore(); 
        Console.WriteLine();
        Console.WriteLine($"Percent done independently for {base.GetName()} is now {_score}. ");
    }
    private void CalculateScore()
    {
        double score = _trialsInd / _trialsRun;
        _score = score;
    }
}