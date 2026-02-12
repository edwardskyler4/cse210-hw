using System;

class Reference
{
    private string _reference;

    public Reference()
    {
        _reference = "Isaiah 40:31";   
    }
    public Reference(string reference)
    {
        _reference = reference;
    }
    public void GetReference()
    {
        Console.Write(_reference.ToUpper());
    }
}