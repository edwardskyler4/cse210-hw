using System;
using System.Runtime.InteropServices;

class Scripture
{
    private Reference _reference;
    private string _scriptureStr;
    private List<Word> _scripture = new();
    private List<int> _unhiddenWordIndexes = new();

    public Scripture()
    {
        _reference = new Reference();
        _scriptureStr = "But they that wait upon the lord shall renew their strength; they shall mount up with wings as eagles; they shall run and not be weary; and they shall walk and not faint.";
        ParseScriptureStr(_scriptureStr);
        _unhiddenWordIndexes = Enumerable.Range(0, _scripture.Count).ToList();
    }
    public Scripture(string reference, string scripture)
    {
        _reference = new Reference(reference);
        _scriptureStr = scripture;
        ParseScriptureStr(_scriptureStr);   
        _unhiddenWordIndexes = Enumerable.Range(0, _scripture.Count).ToList();
    }
    public void GetScripture()
    {
        _reference.GetReference();
        Console.Write(": ");
        
        foreach (Word word in _scripture)
        {
            word.GetWord();
            Console.Write(" ");
        }
    }
    public int GetUnhiddenWordCount()
    {
        return _unhiddenWordIndexes.Count;
    }
    public void HideWords()
    {
        Random randomChoice = new();
        for (int i=1; i <= 3; i++)
        {
            if (_unhiddenWordIndexes.Count > 0)
            {
                int number = randomChoice.Next(0, _unhiddenWordIndexes.Count);
                int index = _unhiddenWordIndexes[number];
                _scripture[index].HideWord();
                _unhiddenWordIndexes.Remove(index);
            }
        }
    }
    private void ParseScriptureStr(string scripture)
    {
        foreach (string word in scripture.Split(" "))
        {
            if (word != "")
            {
                Word classInstance = new Word(word);
                _scripture.Add(classInstance);
            }
        }
    }
}