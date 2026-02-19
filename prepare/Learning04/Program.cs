using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new("Samuel Bennett", "Multiplication");
        string summary = assignment.GetSummary();
        Console.WriteLine(summary);
        Console.WriteLine();

        MathAssignment mAss = new("Roberto Rodriguez", "Fractions", "Section 7.3", "Problems 8-19");
        string mSummary = mAss.GetSummary();
        string homeworkList = mAss.GetHomeworkList();
        Console.WriteLine(mSummary);
        Console.WriteLine(homeworkList);
        Console.WriteLine();

        WritingAssignment wAss = new("Mary Waters", "European History", "The Causes of World War II by Mary Waters");
        string wSummary = wAss.GetSummary();
        string writingInformation = wAss.GetWritingInformation();
        Console.WriteLine(wSummary);
        Console.WriteLine(writingInformation);
    }
}