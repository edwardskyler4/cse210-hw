using System;

class ReflectionActivity : Activity
{
    private List<string> _prompts = new();
    private List<string> _questions = new();
    private List<int> _unaskedQuestions = new();

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        PopulatePrompts();
        PopulateQuestions();
        _unaskedQuestions = Enumerable.Range(0, _questions.Count).ToList();
    }
    public void RunActivity()
    {
        DisplayStartingMessage();
        int runSeconds = GetSeconds();
        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(runSeconds);

        string prompt = GetPrompt();
        Random questionPicker = new();

        Console.Clear();
        Console.WriteLine("Get Ready...");
        Pause();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"\n--- {prompt} ---\n");
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of these questions as they relate to this experience:");
        Pause(2);

        Console.Clear();
        while (now < end)
        {
            int randomPicker = questionPicker.Next(0, _unaskedQuestions.Count);
            int questionIndex = _unaskedQuestions[randomPicker];
            _unaskedQuestions.Remove(questionIndex);
            string question = _questions[questionIndex];

            Console.Write($"> {question} ");
            Pause(5);
            Console.WriteLine();
            now = DateTime.Now;
        }
        DisplayEndingMessage();
    }
    private string GetPrompt()
    {
        Random randomPicker = new();
        int promptListLen = _prompts.Count;
        int index = randomPicker.Next(0, promptListLen);
        string prompt = _prompts[index];
        return prompt;
    }
    private void PopulatePrompts()
    {
        _prompts.AddRange("Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless.");
    }
    private void PopulateQuestions()
    {
       _questions.AddRange("Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"); 
    }
}