using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetTask;
using System;
using System.Collections.Generic;

namespace NetTaskTest
{
    [TestClass]
    public class NetTaskUnitTest
    {
        [TestMethod]
        public void TestContainsName()
        {
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            string filterOfName = "Jono.NET meetas";
            string filterNameFaulty = "adrrdvffcdd";

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            var actual = meetingsContainer.ContainsName(filterOfName);
            var actualFaulty = meetingsContainer.ContainsName(filterNameFaulty);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");

        }
        [TestMethod]
        public void TestAddPersonToTheMeeting()
        {
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            string meetingName = "Jono.NET meetas";
            string meetingNameFaulty = "adrrdvffcdd";
            string meetingNameFaulty2 = "";

            string personToAdd = "Jonas Kitas Draugas";
            string personToAddFaulty = "";

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            var actual = meetingsContainer.AddPersonToTheMeeting(personToAdd, meetingName);

            var actualFaulty = meetingsContainer.AddPersonToTheMeeting(personToAddFaulty, meetingName);
            var actualFaulty2 = meetingsContainer.AddPersonToTheMeeting(personToAddFaulty, meetingNameFaulty);
            var actualFaulty3 = meetingsContainer.AddPersonToTheMeeting(personToAddFaulty, meetingNameFaulty2);

            var actualFaulty4 = meetingsContainer.AddPersonToTheMeeting(personToAdd, meetingNameFaulty);
            var actualFaulty5 = meetingsContainer.AddPersonToTheMeeting(personToAdd, meetingNameFaulty2);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");
            Assert.IsFalse(actualFaulty2, "Is not false");
            Assert.IsFalse(actualFaulty3, "Is not false");
            Assert.IsFalse(actualFaulty4, "Is not false");
            Assert.IsFalse(actualFaulty5, "Is not false");
        }
        [TestMethod]
        public void TestRemovePersonFromTheMeeting()
        {
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            string meetingName = "Jono.NET meetas";
            string meetingNameFaulty = "adrrdvffcdd";
            string meetingNameFaulty2 = "";

            string personToRemove = "Jono Draugas";
            string personToRemoveFaulty = "Jonas";
            string personToRemoveFaulty2 = "";

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            var actual = meetingsContainer.RemovePersonFromTheMeeting(personToRemove, meetingName);

            var actualFaulty = meetingsContainer.RemovePersonFromTheMeeting(personToRemove, meetingNameFaulty);
            var actualFaulty2 = meetingsContainer.RemovePersonFromTheMeeting(personToRemove, meetingNameFaulty2);

            var actualFaulty3 = meetingsContainer.RemovePersonFromTheMeeting(personToRemoveFaulty, meetingName);
            var actualFaulty4 = meetingsContainer.RemovePersonFromTheMeeting(personToRemoveFaulty, meetingNameFaulty);
            var actualFaulty5 = meetingsContainer.RemovePersonFromTheMeeting(personToRemoveFaulty, meetingNameFaulty2);

            var actualFaulty6 = meetingsContainer.RemovePersonFromTheMeeting(personToRemoveFaulty2, meetingName);
            var actualFaulty7 = meetingsContainer.RemovePersonFromTheMeeting(personToRemoveFaulty2, meetingNameFaulty);
            var actualFaulty8 = meetingsContainer.RemovePersonFromTheMeeting(personToRemoveFaulty2, meetingNameFaulty2);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");
            Assert.IsFalse(actualFaulty2, "Is not false");
            Assert.IsFalse(actualFaulty3, "Is not false");
            Assert.IsFalse(actualFaulty4, "Is not false");
            Assert.IsFalse(actualFaulty5, "Is not false");
            Assert.IsFalse(actualFaulty6, "Is not false");
            Assert.IsFalse(actualFaulty7, "Is not false");
            Assert.IsFalse(actualFaulty8, "Is not false");
        }
        [TestMethod]
        public void TestCheckFirstFilters()
        {
            //Data for the test
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            string filterOfName = ".NET";
            string filterNameFaulty = "adrrdvffcdd";

            string filterResponsablePerson = "Jonas";
            string filterResponsablePersonFaulty = "dsadas";

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            //Test Part

            var actual = meetingsContainer.CheckFirstFilters(meeting, filterOfName, filterResponsablePerson, 0);
            var actualFaulty = meetingsContainer.CheckFirstFilters(meeting, filterNameFaulty, filterResponsablePerson, 0);
            var actualFaulty2 = meetingsContainer.CheckFirstFilters(meeting, filterOfName, filterResponsablePersonFaulty, 0);
            var actualFaulty3 = meetingsContainer.CheckFirstFilters(meeting, filterOfName, filterResponsablePerson, 10);
            var actualFaulty4 = meetingsContainer.CheckFirstFilters(meeting, filterNameFaulty, filterResponsablePersonFaulty, 10);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");
            Assert.IsFalse(actualFaulty2, "Is not false");
            Assert.IsFalse(actualFaulty3, "Is not false");
            Assert.IsFalse(actualFaulty4, "Is not false");
        }
        [TestMethod]
        public void TestRemoveMeeting()
        {
            //Data for the test
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);


            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            string loggedInPerson = "Jonas";
            string loggedInPersonFaulty = "adasds";
            string loggedInPersonFaulty2 = "";

            string meetingName = "Jono.NET meetas";
            string meetingNameFaulty = "gdfgdfgdfgdf";
            string meetingNameFaulty2 = "";

            //Test Part

            var actual = meetingsContainer.RemoveMeeting(loggedInPerson, meetingName);

            var actualFaulty = meetingsContainer.RemoveMeeting(loggedInPerson, meetingNameFaulty);
            var actualFaulty2 = meetingsContainer.RemoveMeeting(loggedInPerson, meetingNameFaulty2);

            var actualFaulty3 = meetingsContainer.RemoveMeeting(loggedInPersonFaulty, meetingName);
            var actualFaulty4 = meetingsContainer.RemoveMeeting(loggedInPersonFaulty, meetingNameFaulty);
            var actualFaulty5 = meetingsContainer.RemoveMeeting(loggedInPersonFaulty, meetingNameFaulty2);

            var actualFaulty6 = meetingsContainer.RemoveMeeting(loggedInPersonFaulty2, meetingName);
            var actualFaulty7 = meetingsContainer.RemoveMeeting(loggedInPersonFaulty2, meetingNameFaulty);
            var actualFaulty8 = meetingsContainer.RemoveMeeting(loggedInPersonFaulty2, meetingNameFaulty2);


            Assert.IsTrue(actual,  "Is not true");
            Assert.IsFalse(actualFaulty, "Is not true");
            Assert.IsFalse(actualFaulty2, "Is not true");
            Assert.IsFalse(actualFaulty3, "Is not true");
            Assert.IsFalse(actualFaulty4, "Is not true");
            Assert.IsFalse(actualFaulty5, "Is not true");
            Assert.IsFalse(actualFaulty6, "Is not true");
            Assert.IsFalse(actualFaulty7, "Is not true");
            Assert.IsFalse(actualFaulty8, "Is not true");
        }
        [TestMethod]
        public void TestInputDate()
        {
            //Data for the test
            List<Meeting> meetings = new List<Meeting>();

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            string input = "2022-05-02 19:00:00";
            string inputFaulty = "ddddddd";
            string inputFaulty2 = "";

            DateTime expected = DateTime.Parse("2022-05-02 19:00:00");
            DateTime expectedFaulty = DateTime.Parse("0001-01-01 00:00:00");


            //Test Part

            var actual = meetingsContainer.InputDate(input);
            var actualFaulty = meetingsContainer.InputDate(inputFaulty);
            var actualFaulty2 = meetingsContainer.InputDate(inputFaulty2);


            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedFaulty, actualFaulty);
            Assert.AreEqual(expectedFaulty, actualFaulty2);

        }
        [TestMethod]
        public void TestInputIndex()
        {
            //Data for the test
            List<Meeting> meetings = new List<Meeting>();

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            string input = "1";
            string inputFaulty = "ddddddd";
            string inputFaulty2 = "";

            int expected = 1;
            int expectedFaulty = -1;


            //Test Part

            var actual = meetingsContainer.InputIndex(input);
            var actualFaulty = meetingsContainer.InputIndex(inputFaulty);
            var actualFaulty2 = meetingsContainer.InputIndex(inputFaulty2);


            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedFaulty, actualFaulty);
            Assert.AreEqual(expectedFaulty, actualFaulty2);
        }
        [TestMethod]
        public void TestFilterByType()
        {
            //Data for the test
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            Types type = Types.inPerson;
            Types type2 = Types.Live;

            //Test Part

            var actual = meetingsContainer.FilterByType(meeting, type);
            var actualFaulty = meetingsContainer.FilterByType(meeting, type2);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");
        }
        [TestMethod]
        public void TestFilterByCategory()
        {
            //Data for the test
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            Categories category = Categories.Hub;
            Categories category2 = Categories.TeamBuilding;

            //Test Part

            var actual = meetingsContainer.FilterByCategory(meeting, category);
            var actualFaulty = meetingsContainer.FilterByCategory(meeting, category2);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");
        }
        [TestMethod]
        public void TestFilterByDate()
        {
            //Data for the test
            DateTime startDate = DateTime.Parse("2022-05-02 19:00:00");
            DateTime endDate = DateTime.Parse("2022-05-03 06:00:00");
            List<string> attendees = new List<string>();
            attendees.Add("Jonas");
            attendees.Add("Jono Draugas");

            List<Meeting> meetings = new List<Meeting>();

            Meeting meeting = new Meeting
            {
                Name = "Jono.NET meetas",
                ResponsablePerson = "Jonas",
                Description = "Jono meetas",
                Category = Categories.Hub,
                Type = Types.inPerson,
                StartDate = startDate,
                EndDate = endDate,
                Attendees = attendees
            };

            meetings.Add(meeting);

            MeetingsContainerForTests meetingsContainer = new MeetingsContainerForTests(meetings);

            DateTime startDate1 = DateTime.Parse("2022-05-02 18:00:00");
            DateTime endDate1 = DateTime.Parse("2022-05-03 07:00:00");

            DateTime startDateFaulty = DateTime.Parse("2022-05-03 07:00:00");
            DateTime endDateFaulty = DateTime.Parse("2022-05-02 18:00:00");

            DateTime starDateNotSet = DateTime.Parse("0001-01-01 00:00:00");
            DateTime endDateNotSet = DateTime.Parse("0001-01-01 00:00:00");

            //Test Part

            var actual = meetingsContainer.FilterByDate(meeting, startDate1, endDate1);
            var actual2 = meetingsContainer.FilterByDate(meeting, starDateNotSet, endDate1);
            var actual3 = meetingsContainer.FilterByDate(meeting, starDateNotSet, endDateNotSet);
            var actual4 = meetingsContainer.FilterByDate(meeting, startDate1, endDateNotSet);
            var actualFaulty = meetingsContainer.FilterByDate(meeting, startDateFaulty, endDateFaulty);

            Assert.IsTrue(actual, "Is not true");
            Assert.IsTrue(actual2, "Is not true");
            Assert.IsTrue(actual3, "Is not true");
            Assert.IsTrue(actual4, "Is not true");
            Assert.IsFalse(actualFaulty, "Is not false");
        }
    }
}