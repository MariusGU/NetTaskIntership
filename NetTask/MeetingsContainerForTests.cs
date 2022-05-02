using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask
{
    /// <summary>
    /// Coppy of the MeetingsContainer with changed input styles from Console.Readline to params for the easier Unit testing
    /// </summary>
    public class MeetingsContainerForTests
    {
        private List<Meeting> Meetings;
        
        public MeetingsContainerForTests()
        {
            if (File.Exists("Meetings.json"))
            {
                var data = File.ReadAllText("Meetings.json");
                var list = JsonConvert.DeserializeObject<List<Meeting>>(data);
                Meetings = list;
            }
            else
            {
                Meetings = new List<Meeting>();
            }
        }
        public MeetingsContainerForTests(List<Meeting> meetings)
        {
            Meetings = meetings;
        }
        /// <summary>
        /// Method to check if there is a meeting contaiig the name provided in the params
        /// </summary>
        /// <param name="name">Name to check</param>
        /// <returns>returns true if a match is found and false if not found</returns>
        public bool ContainsName(string name)
        {
            if (Meetings.Count > 0)
            {
                int count = 0;
                foreach (Meeting item in Meetings)
                {
                    if (item.Name == name)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to write data of the meetings to the json file
        /// </summary>
        /// <param name="path">Path to the json file</param>
        private void WriteToTheFile(string path)
        {
            var dataToWrite = JsonConvert.SerializeObject(Meetings);
            File.WriteAllText(path, dataToWrite);
        }
        /// <summary>
        /// Method to add person to the meeting
        /// </summary>
        /// <returns>Returns true and a message if succeeded and an false with an error message if not</returns>
        public bool AddPersonToTheMeeting(string personToAdd, string meetingName)
        {
            if (Meetings.Count() > 0)
            {
                //Console.WriteLine("Enter a name of the person to add to the meeting: ");
                //string personToAdd = Console.ReadLine();
                if (personToAdd != null && personToAdd.Length > 0)
                {
                    //Console.WriteLine("Enter the name of the meeting to add a person to it: ");
                    //string meetingName = Console.ReadLine();
                    if (meetingName != null)
                    {
                        for (int i = 0; i < Meetings.Count(); i++)
                        {
                            if (Meetings.ElementAt(i).Name == meetingName)
                            {
                                if (!Meetings.ElementAt(i).Attendees.Contains(personToAdd))
                                {
                                    Meetings.ElementAt(i).Attendees.Add(personToAdd);
                                    //Console.WriteLine("Person " + personToAdd + " was successfully added to the meeting at: " + DateTime.Now.ToString());
                                    WriteToTheFile("Meetings.json");
                                    return true;
                                }
                                else
                                {
                                    //Console.WriteLine("This person is already in the meeting");
                                    return false;
                                }
                            }
                        }
                        //Console.WriteLine("Meeting with such a name was not found");
                        return false;
                    }
                    //Console.WriteLine("You must to enter a meeting name to add a person to it");
                    return false;
                }
                //Console.WriteLine("You must to enter a person to add to the meeting");
                return false;
            }
            //Console.WriteLine("There are no meetings yet");
            return false;
        }
        /// <summary>
        /// Method to remove a person from the meeting
        /// </summary>
        /// <returns>Returns true if a person was removed and false with an error message if not</returns>
        public bool RemovePersonFromTheMeeting(string personToRemove, string meetingName)
        {
            if (Meetings.Count() > 0)
            {
                //Console.WriteLine("Enter a name of the person to remove: ");
                //string personToRemove = Console.ReadLine();
                if (personToRemove != null)
                {
                    //Console.WriteLine("Eneter a name of the meeting to remove the person: ");
                    //string meetingName = Console.ReadLine();
                    if (meetingName != null)
                    {
                        for (int i = 0; i < Meetings.Count(); i++)
                        {
                            if (Meetings.ElementAt(i).Name == meetingName)
                            {
                                if (Meetings.ElementAt(i).ResponsablePerson != personToRemove)
                                {
                                    var result = Meetings.ElementAt(i).Attendees.Remove(personToRemove);
                                    WriteToTheFile("Meetings.json");
                                    //Console.WriteLine("Removed");
                                    return result;
                                }
                                else
                                {
                                    //Console.WriteLine("Responsible person can not be removed from the meeting");
                                    return false;
                                }
                            }
                        }
                        //Console.WriteLine("There is no such a meeting with the name privided");
                        return false;
                    }
                    //Console.WriteLine("You must to enter a name of the meeting to remove the person from it");
                    return false;
                }
                //Console.WriteLine("You must to enter a name of the person to remove");
                return false;
            }
            //Console.WriteLine("There are no meetings yet");
            return false;
        }
        /// <summary>
        /// Method to delete the meeting
        /// </summary>
        /// <param name="loggedInPerson">The person who is logged in</param>
        /// <returns>Returns true if meeting is deleted and false with an error message if not</returns>
        public bool RemoveMeeting(string loggedInPerson, string name)
        {
            //Console.WriteLine("Enter the name of the meeting to delete");
            //string name = Console.ReadLine();
            if (name.Length < 1)
            {
                //Console.WriteLine("Name must be provided to delete the meeting");
                return false;
            }
            if (Meetings.Count > 0)
            {
                for (int i = 0; i < Meetings.Count(); i++)
                {
                    if (Meetings.ElementAt(i).Name == name)
                    {
                        if (Meetings.ElementAt(i).ResponsablePerson == loggedInPerson)
                        {
                            Meetings.RemoveAt(i);
                            //Console.WriteLine("Deleted");
                            WriteToTheFile("Meetings.json");
                            return true;
                        }
                        else
                        {
                            //Console.WriteLine("You are not allowed to delete this meeting");
                            return false;
                        }
                    }
                }
                //Console.WriteLine("Element is not deleted, make sure that the meeting with such a name exists");
                return false;
            }
            //Console.WriteLine("There are no meetings yet");
            return false;
        }
        /// <summary>
        /// Lists all the categories of the meeting possible
        /// </summary>
        public void ListCategories()
        {
            string hSeparator = String.Format(new string('-', 27));
            Console.WriteLine(hSeparator);
            Console.WriteLine(String.Format("| {0,20:C} |", "Meeting categories list"));
            Console.WriteLine(hSeparator);
            Console.WriteLine(String.Format("| {0,5} | {1,-15} |", "index", "Category"));
            Console.WriteLine(hSeparator);
            Console.WriteLine(String.Format("| {0,5} | {1,-15} |", "1", Categories.CodeMonkey));
            Console.WriteLine(String.Format("| {0,5} | {1,-15} |", "2", Categories.Hub));
            Console.WriteLine(String.Format("| {0,5} | {1,-15} |", "3", Categories.Short));
            Console.WriteLine(String.Format("| {0,5} | {1,-15} |", "4", Categories.TeamBuilding));
            Console.WriteLine(hSeparator);
        }
        /// <summary>
        /// Method to list all the types of the meeting possible
        /// </summary>
        public void ListTypes()
        {
            string tableHeader = "Meeting types list";
            int width = 26;
            int leftPadding = (width - tableHeader.Length) / 2;
            string paddingString = new string(' ', leftPadding);
            string hSeparator = String.Format(new string('-', 28));
            Console.WriteLine(hSeparator);
            Console.WriteLine("|" + paddingString + tableHeader + paddingString + "|");
            Console.WriteLine(hSeparator);
            Console.WriteLine(String.Format("| {0,5} | {1,-16} |", "index", "Type"));
            Console.WriteLine(hSeparator);
            Console.WriteLine(String.Format("| {0,5} | {1,-16} |", "1", Types.Live));
            Console.WriteLine(String.Format("| {0,5} | {1,-16} |", "2", Types.inPerson));
            Console.WriteLine(hSeparator);
        }
        /// <summary>
        /// Method to select a category of the meeting
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Categories SelectCategory(int index)
        {
            Categories category = new Categories();
            if (index == 1)
            {
                category = Categories.CodeMonkey;
                return category;
            }
            if (index == 2)
            {
                category = Categories.Hub;
                return category;
            }
            if (index == 3)
            {
                category = Categories.Short;
                return category;
            }
            if (index == 4)
            {
                category = Categories.TeamBuilding;
                return category;
            }
            return category;
        }
        /// <summary>
        /// Method to select the type of the meeting by the index provided
        /// </summary>
        /// <param name="index">Index to select the type of the meeting</param>
        /// <returns>Returns the type selected</returns>
        public Types SelectType(int index)
        {
            Types type = new Types();
            if (index == 1)
            {
                type = Types.Live;
                return type;
            }
            if (index == 2)
            {
                type = Types.inPerson;
                return type;
            }
            return type;
        }
        /// <summary>
        /// Method to input meeting's start date or the end date
        /// </summary>
        /// <param name="message">Message for the input explanation</param>
        /// <returns>Returns year 0001 if input was incorrect and date if it was correct</returns>
        public DateTime InputDate(string input)
        {
            DateTime date = new DateTime();
            //Console.WriteLine(message);
            try
            {
                date = DateTime.Parse(input);
                return date;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(error);
            }
            return date;
        }
        /// <summary>
        /// Method to input index via the console
        /// </summary>
        /// <param name="message">Message before the input</param>
        /// <param name="errorMessage">Message if input was not an int type</param>
        /// <returns>returns -1 if input was not an int type and int entered if it was</returns>
        public int InputIndex(string input)
        {
            //Console.WriteLine(message);
            int index = -1;
            //tries to cast input into int
            try
            {
                index = Convert.ToInt32(input);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(errorMessage);
                return index;
            }
            return index;
        }
        /// <summary>
        /// Method to create a meeting
        /// </summary>
        /// <param name="loggedInPerson">Person who is logged in</param>
        /// <returns>Returns created if meeting is created and an error message if not</returns>
        public bool CreateMeeting(string loggedInPerson)
        {
            //Console.WriteLine("Enter a name of the meeting");
            string name = Console.ReadLine();

            if (name == null)
            {
                //Console.WriteLine("Name must be provided");
                return false;
            }

            if (ContainsName(name))
            {
                //Console.WriteLine("There is a meeting with such a name, please try again");
                return false;
            }

            //Console.WriteLine("Enter a description of the meeting: ");
            string description = Console.ReadLine();

            if (description == null)
            {
                description = "";
            }

            //Console.WriteLine();
            //lists the categories available to choose for a meeting
            ListCategories();
            //Console.WriteLine();

            int categoryIndex = InputIndex(Console.ReadLine());

            Categories category;

            //Check if the index provided by the input corresponds to one of the indexes from the categories table if does, selects category else returns error message
            if (categoryIndex > 0 && categoryIndex < 5)
            {
                category = SelectCategory(categoryIndex);
            }
            else
            {
                //Console.WriteLine("There is no such a category with the index you provided, please select the index according to the categories table");
                return false;
            }

            //Console.WriteLine();
            //lists the types of the meeting for the choosing
            ListTypes();
            //Console.WriteLine();

            int typeIndex = InputIndex(Console.ReadLine());

            Types type;
            //Check if the index provided by the input corresponds to one of the indexes from the types table if does, selects a type else returns error message
            if (typeIndex > 0 && typeIndex < 3)
            {
                type = SelectType(typeIndex);
            }
            else
            {
                //Console.WriteLine("There is no such a type with the index you provided, please select the index according to the types table");
                return false;
            }

            DateTime startDate = InputDate(Console.ReadLine());
            DateTime endDate = InputDate(Console.ReadLine());

            if (startDate.Year == 0001)
            {
                return false;
            }
            if (endDate.Year == 0001)
            {
                return false;
            }
            if (startDate > endDate)
            {
                return false;
            }

            List<string> attendees = new List<string>();
            attendees.Add(loggedInPerson);

            Meeting meeting = new Meeting(name, loggedInPerson, description, category, type, startDate, endDate, attendees);
            Meetings.Add(meeting);
            WriteToTheFile("Meetings.json");
            //Console.WriteLine("Created");
            return true;
        }
        /// <summary>
        /// Method to check if given meeting passes the filters given in params
        /// </summary>
        /// <param name="meeting">Meeting to check</param>
        /// <param name="name">Meeting name filter</param>
        /// <param name="responsablePerson">Responsible person filter</param>
        /// <param name="attendees">Attendees filter</param>
        /// <returns>Returns true if passes, returns false if not</returns>
        public bool CheckFirstFilters(Meeting meeting, string name, string responsablePerson, int attendees)
        {
            if (meeting.Name.Contains(name) && meeting.ResponsablePerson.Contains(responsablePerson) && meeting.Attendees.Count() > attendees)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to check if meeting given in params passes the type filter privided in params
        /// </summary>
        /// <param name="meeting">Meeting to check</param>
        /// <param name="type">Type filter</param>
        /// <returns>Return true if passes, returns false if not</returns>
        public bool FilterByType(Meeting meeting, Types type)
        {
            if (meeting.Type == type)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to check if meeting given in params passes the category filter provided in params
        /// </summary>
        /// <param name="meeting">Meeting to check</param>
        /// <param name="category">category filter</param>
        /// <returns>Returns true if passes, returns false if not</returns>
        public bool FilterByCategory(Meeting meeting, Categories category)
        {
            if (meeting.Category == category)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to check if meeting provided in params passes the Date filters provided in params
        /// </summary>
        /// <param name="meeting">Meeting to check</param>
        /// <param name="startDate">StaetDate filter</param>
        /// <param name="endDate">EndDate filter</param>
        /// <returns>Returns true if passes, returns false if not</returns>
        public bool FilterByDate(Meeting meeting, DateTime startDate, DateTime endDate)
        {
            if (endDate > startDate && startDate.Year == 0001 && endDate.Year != 0001)
            {
                if (meeting.EndDate < endDate)
                {
                    return true;
                }
            }
            if (endDate.Year == 0001 && startDate.Year != 0001)
            {
                if (meeting.StartDate > startDate)
                {
                    return true;
                }
            }
            if (endDate > startDate && endDate.Year != 0001 && startDate.Year != 0001)
            {
                if (startDate < meeting.StartDate && endDate > meeting.EndDate)
                {
                    return true;
                }
            }
            if (startDate.Year == 0001 && endDate.Year == 0001)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Method to filter and print all the meetings by all the filters provided in the params
        /// </summary>
        /// <param name="name">Meeting's name filter</param>
        /// <param name="responsablePerson">Meeting's responsible person filter</param>
        /// <param name="category">Meeting's category filter</param>
        /// <param name="isCategoryChosen">Boolean value to determine if filter by category is needed</param>
        /// <param name="type">Meeting's type filter</param>
        /// <param name="isTypeChosen">Boolean value to determine if filter by type is needed</param>
        /// <param name="startDate">Meeting's star date filter</param>
        /// <param name="endDate">Meeting's end date filter</param>
        /// <param name="attendees">Meeting's attendees filter</param>
        public void PrintFilteredMeetings(string name, string responsablePerson, Categories category, bool isCategoryChosen,
            Types type, bool isTypeChosen, DateTime startDate, DateTime endDate, int attendees)
        {
            List<Meeting> meetings = new List<Meeting>();
            foreach (Meeting meeting in Meetings)
            {
                if (CheckFirstFilters(meeting, name, responsablePerson, attendees))
                {
                    Meeting temp = meeting;
                    if (isCategoryChosen && isTypeChosen)
                    {
                        if (FilterByCategory(meeting, category) && FilterByType(meeting, type) && FilterByDate(meeting, startDate, endDate))
                        {
                            temp = meeting;
                        }
                        else
                        {
                            temp = null;
                        }
                    }
                    else if (isTypeChosen)
                    {
                        if (FilterByType(meeting, type) && FilterByDate(meeting, startDate, endDate))
                        {

                            temp = meeting;
                        }
                        else
                        {
                            temp = null;
                        }
                    }
                    else if (isCategoryChosen)
                    {
                        if (FilterByCategory(meeting, category) && FilterByDate(meeting, startDate, endDate))
                        {
                            temp = meeting;
                        }
                        else
                        {
                            temp = null;
                        }
                    }
                    else if (FilterByDate(meeting, startDate, endDate))
                    {
                        temp = meeting;
                    }

                    if (temp != null)
                    {
                        meetings.Add(temp);
                    }
                }
            }
            //Console.WriteLine("Buvo atrinkta: " + meetings.Count().ToString());
        }
        public string AttendeesToString(List<string> attendeeds)
        {
            string stringToReturn = "";
            foreach (string attendee in attendeeds)
            {
                stringToReturn = stringToReturn + attendee + ", ";
            }
            return stringToReturn;

        }
        /// <summary>
        /// Method to input filters for the search of the meetings and invoke PrintFilteredMeetings method
        /// </summary>
        /// <returns>Returns Filtered if filtered and Was not filtered if not</returns>
        public bool ListAllTheMeetings()
        {
            if (Meetings.Count > 0)
            {
                //Console.WriteLine("Enter the name filter");
                string name = Console.ReadLine();
                if (name == null)
                {
                    name = "";
                }

                //Console.WriteLine("Enter the responsable person filter");
                string responsablePerson = Console.ReadLine();
                if (responsablePerson == null)
                {
                    responsablePerson = "";
                }

                //Console.WriteLine();
                //ListCategories();
                //Console.WriteLine();

                //Console.WriteLine();
                int categoryIndex = InputIndex(Console.ReadLine());
                Categories category = new Categories();
                bool isCategoryChosen = false;
                if (categoryIndex > 0 && categoryIndex < 5)
                {
                    category = SelectCategory(categoryIndex);
                    isCategoryChosen = true;
                }

                //Console.WriteLine();
                //ListTypes();
                //Console.WriteLine();
                int typeIndex = InputIndex(Console.ReadLine());
                Types type = new Types();
                bool isTypeChosen = false;
                if (typeIndex > 0 && typeIndex < 3)
                {
                    type = SelectType(typeIndex);
                    isTypeChosen = true;
                }

                DateTime startDate;
                DateTime endDate;
                startDate = InputDate(Console.ReadLine());
                endDate = InputDate(Console.ReadLine());

                int attendeesCount = InputIndex(Console.ReadLine());
                if (attendeesCount == -1)
                {
                    attendeesCount = 0;
                }

                PrintFilteredMeetings(name, responsablePerson, category, isCategoryChosen, type, isTypeChosen, startDate, endDate, attendeesCount);
                return true;
            }
            //Console.WriteLine("There are no meetings yet");
            return false;
        }
    }
}
