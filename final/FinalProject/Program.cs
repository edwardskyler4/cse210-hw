using System;
using System.ComponentModel.DataAnnotations;
using System.IO.Enumeration;
using System.Text.Json;

// Note to grader:
// Feel free to use my test username, "username". The second client "Jabroni" has a program book and one type of each program entry. Or feel free to do your own testing and use. If you do make your own username, set your qualification to BCBA. You won't be able to edit or create anything otherwise. The idea is that if this program were more fleshed out and used actual databases, the clients and programs would be created, managed, and assigned by the BCBAs, with the RBTs only having viewing and data collection permissions.

class Program
{
    static void Main(string[] args)
    {
        bool run = true;
        while (run == true)
        {
            run = MainMenu();
        }
    }
    public static User CreateNewUser(string username)
    {
       User newUser = new(username);
       return newUser; 
    }
    public static User Login(string username)
    {
        string filename = $"{username}.json";
        if (File.Exists(filename))
        {
            Console.WriteLine("User found. Loading data...");
            User user = Load(username);
            return user;     
        }
        else
        {
            Console.WriteLine("User not found. Creating new user...");
            User user = CreateNewUser(username);
            return user;
        }
    }
    private static bool MainMenu()
    {
        List<string> acceptedAnswers = new() { "1", "2" };

        Console.Clear();
        Console.WriteLine("Main Menu:");
        Console.WriteLine("   1. Login");
        Console.WriteLine("   2. Quit");
        string input = VerifyInput("Enter your selection: ", acceptedAnswers);

        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Login:");
            Console.WriteLine("Enter your username: ");
            string username = Console.ReadLine();
            User user = Login(username);
            
            bool run = true;
            while (run == true)
            {
                run = UserMenu(user);
            }
            return true;
        }
        else
        {
            Console.WriteLine();
            Console.WriteLine("Goodbye!");
            return false;
        }
    }
    private static bool UserMenu(User user)
    {
        bool canEdit = false;
        if (user.GetQualification() == "BCBA")
        {
            canEdit = true;
        }
        List<string> acceptedAnswers = new() { "1", "2", "3", "4", "5", "6" };

        Console.Clear();
        Console.WriteLine("User Menu:");
        Console.WriteLine("   1. Display User information");
        Console.WriteLine("   2. Update Qualification");
        Console.WriteLine("   3. Add Client");
        Console.WriteLine("   4. List Clients");
        Console.WriteLine("   5. View Client Details");
        Console.WriteLine("   6. Logout");
        string input = VerifyInput("Enter your selection: ", acceptedAnswers);

        if (input == "1")
        {
            Console.Clear();
            string name = user.GetUsername();
            string qualification = user.GetQualification();
            Console.WriteLine($"Username: {name} - Qualification: {qualification}");
            Console.WriteLine("Press ENTER to return to menu");
            Console.ReadLine();
            ReturnToMenuDialog();
            return true;
        }
        else if (input == "2")
        {
            Console.Clear();
            List<string> acceptedQualAnswers = new() { "BCBA", "RBT", "N/A" };
            string qual = VerifyInput("Enter your qualification (BCBA, RBT, N/A): ", acceptedQualAnswers);
            user.ChangeQualification(qual);

            Console.WriteLine("Successfully changed!");
            ReturnToMenuDialog();
            return true;
        }
        else if (input == "3")
        {
            Console.Clear();
            if (canEdit)
            {
                Console.WriteLine("Add a client:");
                Console.WriteLine("Enter the client's name: ");
                string name = Console.ReadLine();

                int age = -1;
                while (age < 0)
                {
                    Console.WriteLine("Enter the client's age: ");
                    string intInput = Console.ReadLine();
                    if (int.TryParse(intInput, out int intAge))
                    {
                        age = intAge;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }
                }

                Console.WriteLine("Enter the client's diagnosis: ");
                string diagnosis = Console.ReadLine();

                Console.WriteLine("Enter other information about the client or type 'skip' to skip this step (you'll be able to add this later): ");
                string otherInfo = Console.ReadLine();

                if (otherInfo.ToLower() == "skip")
                {
                    user.CreateClient(name, age, diagnosis);
                }
                else
                {
                    user.CreateClient(name, age, diagnosis, otherInfo);
                }

                Console.WriteLine();
                Console.WriteLine("Client added");
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }
                        
            return true;
        }
        else if (input == "4")
        {
            Console.Clear();
            user.DisplayClientList();
            Console.WriteLine("Press ENTER to return to menu");
            Console.ReadLine();
            ReturnToMenuDialog();
            return true;
        }
        else if (input == "5")
        {
            Console.Clear();
            user.DisplayClientList();
            Console.WriteLine("-------------");

            bool run = true;
            int index = -1;
            while (run == true)
            {
                Console.WriteLine("Enter the number of the client whose details you want to see: ");
                string strInput = Console.ReadLine();

                if (int.TryParse(strInput, out int intInput))
                {
                    index = intInput - 1;
                    if (user.GetClient(index) != null)
                    {
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine("No client found at that number");
                    }
                }
                else
                {
                    Console.WriteLine("--- Invalid input. Try again ---");
                }
            }

            Client client = user.GetClient(index);

            run = true;
            while (run == true)
            {
                run = ClientMenu(client, canEdit);
            }

            return true;
        }
        else
        {
            Save(user);
            return false;
        }
    }
    private static bool ClientMenu(Client client, bool canEdit)
    {
        List<string> acceptedAnswers = new() { "1", "2", "3", "4" };

        Console.Clear();
        Console.WriteLine("Client Menu:");
        Console.WriteLine("   1. View Client Info");
        Console.WriteLine("   2. Edit Client Info");
        Console.WriteLine("   3. View Program Book");
        Console.WriteLine("   4. Return to User Menu");
        string input = VerifyInput("Enter your selection: ", acceptedAnswers);

        if (input == "1")
        {
            Console.Clear();
            client.DisplayClientInfo();
            Console.WriteLine("-------------");
            Console.WriteLine("Press ENTER to return to client menu");
            Console.ReadLine();
            ReturnToMenuDialog();

            return true;
        }
        if (input == "2")
        {
            Console.Clear();
            if (canEdit)
            {
                client.EditClientInfo();
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }

            return true;
        }
        if (input == "3")
        {
            ProgramBook book = client.GetProgramBook();
            bool run = true;
            while (run == true)
            {
                run = ProgramBookMenu(book, canEdit);
            }
            return true;
        }
        else
        {
            return false;
        }
    }
    private static bool ProgramBookMenu(ProgramBook book, bool canEdit)
    {
        List<string> acceptedAnswers = new() { "1", "2", "3", "4", "5", "6", "7" };

        Console.Clear();
        Console.WriteLine("Program Book Menu:");
        Console.WriteLine("   1. Display All Programs");
        Console.WriteLine("   2. Remove Program");
        Console.WriteLine("   3. Add Target");
        Console.WriteLine("   4. Add Maladaptive Behavior");
        Console.WriteLine("   5. Add Behavior Goal");
        Console.WriteLine("   6. View Program Details");
        Console.WriteLine("   7. Return to Client Menu");
        string input = VerifyInput("Enter your selection: ", acceptedAnswers);

        if (input == "1")
        {
            Console.Clear();
            book.DisplayProgramBook();
            Console.WriteLine("Press ENTER to return to menu");
            Console.ReadLine();
            ReturnToMenuDialog();
            return true;
        }
        if (input == "2")
        {
            Console.Clear();
            if (canEdit)
            {
                book.DisplayProgramList();
                Console.WriteLine("-------------");

                bool run = true;
                int index = -1;
                while (run == true)
                {
                    Console.WriteLine("Enter the number of the program to delete: ");
                    string strInput = Console.ReadLine();

                    if (int.TryParse(strInput, out int intInput))
                    {
                        index = intInput - 1;
                        if (book.GetProgram(index) != null) // I know that using this method here as confirmation is super janky code, but it works and right now I'm just tyring to get this program to function
                        {
                            book.RemoveProgram(index);
                            run = false;
                        }
                        else
                        {
                            Console.WriteLine("No program found at that number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("--- Invalid input. Try again ---");
                    }
                }
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }
            return true;
        }
        if (input == "3")
        {
            Console.Clear();
            if (canEdit)
            {
                book.AddTarget();
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }
            return true;
        }
        if (input == "4")
        {
            Console.Clear();
            if (canEdit)
            {
                book.AddMaladaptiveBehavior();
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }
            return true;
        }
        if (input == "5")
        {
            Console.Clear();
            if (canEdit)
            {
                book.AddBehaviorGoal();
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }
            return true;
        }
        if (input == "6")
        {
            Console.Clear();
            book.DisplayProgramList();
            Console.WriteLine("-------------");

            bool run = true;
            int index = -1;
            while (run == true)
            {
                Console.WriteLine("Enter the number of the program to view: ");
                string strInput = Console.ReadLine();

                if (int.TryParse(strInput, out int intInput))
                {
                    index = intInput - 1;
                    if (book.GetProgram(index) != null)                     {
                        run = false;
                    }
                    else
                    {
                        Console.WriteLine("No program found at that number");
                    }
                }
                else
                {
                    Console.WriteLine("--- Invalid input. Try again ---");
                }
            }
            
            ProgramEntry entry = book.GetProgram(index);

            run = true;
            while (run == true)
            {
                run = ProgramEntryMenu(entry, canEdit);                
            }

            return true;
        }
        else
        {
            return false;
        }
    }
    private static bool ProgramEntryMenu(ProgramEntry entry, bool canEdit)
    {
        List<string> acceptedAnswers = new() { "1", "2", "3" };

        Console.Clear();
        entry.DisplaySelf();
        Console.WriteLine($"Menu:");
        Console.WriteLine("   1. Edit");
        Console.WriteLine("   2. Add Data Point");
        Console.WriteLine("   3. Return to Program Book Menu");
        string input = VerifyInput("Enter your selection: ", acceptedAnswers);

        if (input == "1")
        {
            Console.Clear();
            if (canEdit)
            {
                entry.EditSelf();
                ReturnToMenuDialog();
            }
            else
            {
                Console.WriteLine("Sorry, you do not have permission to edit");
                ReturnToMenuDialog();
            }

            return true;
        }
        if (input == "2")
        {
            Console.Clear();
            entry.AddDataPoint();
            ReturnToMenuDialog();
            return true;
        }
        else
        {
            return false;
        }
    }
    private static void Save(User userInstance)
    {
        string filename = $"{userInstance.GetUsername()}.json";
        string json = JsonSerializer.Serialize(userInstance);
        File.WriteAllText(filename, json);
        Console.WriteLine("--- Save complete ---");
    }
    private static User Load(string username)
    {
        string filename = $"{username}.json";
        string json = File.ReadAllText(filename);
        User userInstance = JsonSerializer.Deserialize<User>(json);
        Console.WriteLine("--- Load complete ---");
        return userInstance;
    }
    public static string VerifyInput(string question, List<string> acceptedInputs)
    {
        bool run = true;
        string userInput = "";
        while (run == true)
        {
            Console.WriteLine(question);
            userInput = Console.ReadLine();

            if (acceptedInputs.Contains(userInput))
            {
                run = false;
            }
            else
            {
                Console.WriteLine("--- Invalid input. Try again ---");
            }
        }
        return userInput;
    }
    public static void ReturnToMenuDialog(int seconds=2)
    {
        Console.Write("Returning to menu... ");

        DateTime now = DateTime.Now;
        DateTime end = now.AddSeconds(seconds);
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