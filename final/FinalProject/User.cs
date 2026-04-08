using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using System.Text.Json.Serialization;

class User
{
    [JsonInclude]
    private string _username;
    [JsonInclude]
    private string _qualification;
    [JsonInclude]
    private List<Client> _clients = new();

    public User() {}
    public User(string username)
    {
        _username = username;
        _qualification = "RBT";
    }
    public User(string username, string qualification)
    {
        _username = username;
        _qualification = qualification;
    }
    public void ChangeQualification(string qualification)
    {
        _qualification = qualification;
    }
    public string GetQualification()
    {
        return _qualification;
    }
    public string GetUsername()
    {
        return _username;
    }
    public void CreateClient(string name, int age, string diagnosis, string otherInfo="N/A")
    {
        Client newClient = new(name, age, diagnosis, otherInfo);
        _clients.Add(newClient);
    }
    public void DisplayClientList()
    {
        if (_clients.Count > 0)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                Client client = _clients[i];
                string name = client.GetName();
                Console.WriteLine($"{i+1}. {name}");
            }
        }
        else
        {
            Console.WriteLine("No clients found!");
        }
    }
    public Client GetClient(int index)
    {
        if (index >= 0 && index < _clients.Count)
        {
            return _clients[index];   
        }
        else
        {
            return null;
        }
    }
}