using System;

class Word
{
    private string _word;
    private int _wordLen;
    private bool _isHidden = false;

    public Word()
    {
        _word = "N/A";
        _wordLen = _word.Length;
    }
    public Word(string word)
    {
        _word = word;
        _wordLen = word.Length;
    }
    public void GetWord()
    {
        Console.Write(_word);
    }
    public bool GetIsHidden()
    {
        return _isHidden;   
    }
    public void HideWord()
    {
        _word = new string('_', _wordLen);
        _isHidden = true;
    }
}