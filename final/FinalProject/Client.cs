using System.Text.Json.Serialization;

class Client
{
    [JsonInclude]
    private string _name;
    [JsonInclude]
    private int _age;
    [JsonInclude]
    private string _diagnosis;
    [JsonInclude]
    private string _otherInfo;
    [JsonInclude]
    private ProgramBook _programBook = new();

    public Client() {}
    public Client(string name, int age, string diagnosis)
    {
        _name = name;
        _age = age;
        _diagnosis = diagnosis;
        _otherInfo = "N/A";
    }
    public Client(string name, int age, string diagnosis, string otherInfo)
    {
        _name = name;
        _age = age;
        _diagnosis = diagnosis;
        _otherInfo = otherInfo;
    }
    public string GetName()
    {
        return _name;
    }
    public void DisplayClientInfo()
    {
        Console.WriteLine();
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Age: {_age}");
        Console.WriteLine($"Diagnosis: {_diagnosis}");
        Console.WriteLine();
        Console.WriteLine($"Other Information: {_otherInfo}");
    }
    public void EditClientInfo()
    {
        DisplayClientInfo();
        Console.WriteLine();
        Console.WriteLine("-----------------");
        Console.WriteLine();

        Console.WriteLine("Enter a new name or type 'skip' to keep the same one: ");
        string input = Console.ReadLine();
        if (input != "skip")
        {
            _name = input;
        }

        bool run = true;
        while (run == true)
        {
            Console.WriteLine("Enter a new age or type 'skip' to keep the same one: ");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "skip")
            {
                run = false;
            }
            else
            {
                if (int.TryParse(userInput, out int intUsrInput))
                {
                    run = false;
                    _age = intUsrInput;
                }
                else
                {
                    Console.WriteLine("--- Invalid input. Try again ---");
                }
            }
        }

        Console.WriteLine("Enter a new diagnosis or type 'skip' to keep the same one: ");
        input = Console.ReadLine();
        if (input != "skip")
        {
            _diagnosis = input;
        }
        
        Console.WriteLine("Enter a new other information section or type 'skip' to keep the same one: ");
        input = Console.ReadLine();
        if (input != "skip")
        {
            _otherInfo = input;
        }
    }
    public ProgramBook GetProgramBook()
    {
        return _programBook;
    }
}