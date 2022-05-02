using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTask
{
    public class Meeting
    {
        public string Name { get; set; }
        public string ResponsablePerson { get; set; }
        public string Description { get; set; }
        public Categories Category { get; set; }
        public Types Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> Attendees { get; set; }

        public Meeting() { }

        public Meeting(string name, string responsablePerson, string description, Categories category, Types type, DateTime startDate, DateTime endDate, List<string> attendees)
        {
            Name = name;
            ResponsablePerson = responsablePerson;
            Description = description;
            Category = category;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
            Attendees = attendees;
        }
    }
}
