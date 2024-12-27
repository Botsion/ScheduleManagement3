using System;
using System.Collections.Generic;
using System.Linq;

namespace ScheduleManagement
{
    public class ScheduleManager
    {
        private List<ScheduleEntry> _entries;

        public ScheduleManager()
        {
            _entries = new List<ScheduleEntry>();
        }

        public void AddScheduleEntry(ScheduleEntry entry)
        {
            _entries.Add(entry);
        }

        public List<ScheduleEntry> GetScheduleForGroup(string groupName)
        {
            return _entries
                .Where(e => e.GroupName == groupName)
                .OrderBy(e => e.Date)
                .ToList();
        }

        public List<ScheduleEntry> GetScheduleForDate(DateTime date)
        {
            return _entries
                .Where(e => e.Date.Date == date.Date)
                .OrderBy(e => e.GroupName)
                .ToList();
        }

        public List<ScheduleEntry> GetFullSchedule()
        {
            return _entries.OrderBy(e => e.Date).ThenBy(e => e.GroupName).ToList();
        }
    }

    public class ScheduleEntry
    {
        public string GroupName { get; set; }
        public string Lecturer { get; set; }
        public string Room { get; set; }
        public DateTime Date { get; set; }
        public string Subject { get; set; }
    }
}

