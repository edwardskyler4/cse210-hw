abstract public class ProgramEntry
{
    private string _name;
    private string _description;
    private List<string> _dataOptions = new();

    public ProgramEntry(string name, string desc)
    {
        
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
    public List<string> GetOptionsList()
    {
        return _dataOptions;
    }
    public void DisplaySelf()
    {
        
    }
    public abstract void EditSelf();
    private void EditOptions()
    {
        
    }
    public abstract void AddDataPoint();
}