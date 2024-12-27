using System;
using System.Collections.Generic;
using Xunit;
using ScheduleManagement;

namespace ScheduleManagement.Tests
{
    public class ScheduleManagerTests
    {
        [Fact]
        public void GetScheduleForGroup_ReturnsCorrectEntries()
        {
            // Arrange
            var manager = new ScheduleManager();
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupA",
                Lecturer = "Dr. Smith",
                Room = "101",
                Date = new DateTime(2024, 12, 1, 9, 0, 0),
                Subject = "Math"
            });
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupB",
                Lecturer = "Dr. Johnson",
                Room = "102",
                Date = new DateTime(2024, 12, 1, 10, 0, 0),
                Subject = "Physics"
            });

            // Act
            var schedule = manager.GetScheduleForGroup("GroupA");

            // Assert
            Assert.Single(schedule);
            Assert.Equal("Math", schedule[0].Subject);
        }
        [Fact]
        public void GetScheduleForDate_ReturnsCorrectEntries()
        {
            // Arrange
            var manager = new ScheduleManager();
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupA",
                Lecturer = "Dr. Smith",
                Room = "101",
                Date = new DateTime(2024, 12, 1, 9, 0, 0),
                Subject = "Math"
            });
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupB",
                Lecturer = "Dr. Johnson",
                Room = "102",
                Date = new DateTime(2024, 12, 1, 10, 0, 0),
                Subject = "Physics"
            });
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupA",
                Lecturer = "Dr. Smith",
                Room = "101",
                Date = new DateTime(2024, 12, 2, 9, 0, 0),
                Subject = "Chemistry"
            });

            // Act
            var schedule = manager.GetScheduleForDate(new DateTime(2024, 12, 1));

            // Assert
            Assert.Equal(2, schedule.Count);
            Assert.Contains(schedule, e => e.Subject == "Math");
            Assert.Contains(schedule, e => e.Subject == "Physics");
        }
        [Fact]
        public void GetFullSchedule_ReturnsAllEntriesSorted()
        {
            // Arrange
            var manager = new ScheduleManager();
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupB",
                Lecturer = "Dr. Johnson",
                Room = "102",
                Date = new DateTime(2024, 12, 2, 10, 0, 0),
                Subject = "Physics"
            });
            manager.AddScheduleEntry(new ScheduleEntry
            {
                GroupName = "GroupA",
                Lecturer = "Dr. Smith",
                Room = "101",
                Date = new DateTime(2024, 12, 1, 9, 0, 0),
                Subject = "Math"
            });

            // Act
            var schedule = manager.GetFullSchedule();

            // Assert
            Assert.Equal(2, schedule.Count);
            Assert.Equal("Math", schedule[0].Subject);
            Assert.Equal("Physics", schedule[1].Subject);
        }

    }

}
