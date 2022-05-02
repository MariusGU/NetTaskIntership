using NetTask;
using Newtonsoft.Json;

bool end = false;
string loggedInPerson = "";

/// <summary>
/// Method to enter a command
/// </summary: method to enter the command>
string EnterCommand()
{
    string command = Console.ReadLine();
    return command;
}
void Login()
{
    while (loggedInPerson == "")
    {
        var firstName = "";
        while (firstName == "")
        {
            Console.WriteLine("Please enter your first name");
            firstName = Console.ReadLine();
            if (firstName.Length == 0)
            {
                Console.WriteLine("To use the system you must enter your first name");
            }
        }
        var lastName = "";
        while (lastName == "")
        {
            Console.WriteLine("Please enter your last name");
            lastName = Console.ReadLine();
            if (lastName.Length == 0)
            {
                Console.WriteLine("To use the system you must enter your last name");
            }
        }
        loggedInPerson = firstName + " " + lastName;

        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine("Successfully logged in");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine();
        Console.WriteLine("Hello " + loggedInPerson + "!");
        Console.WriteLine();
    }
}

MeetingsContainer meetings = new MeetingsContainer();

Login();

while (end != true)
{
    Console.WriteLine("Enter the command, enter: X to exit");

    string command = EnterCommand();

    if (command == "CreateMeeting")
    {
        meetings.CreateMeeting(loggedInPerson);
    }
    if(command == "DeleteMeeting")
    {
        meetings.RemoveMeeting(loggedInPerson);
    }
    if(command == "AddPersonToTheMeeting")
    {
        meetings.AddPersonToTheMeeting();
    }
    if(command == "RemovePersonFromTheMeeting")
    {
        meetings.RemovePersonFromTheMeeting();
    }
    if(command == "ListAllTheMeetings")
    {
        meetings.ListAllTheMeetings();
    }
    if (command == "X")
    {
        end = true;
    }
}