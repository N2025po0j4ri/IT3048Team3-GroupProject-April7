using System;
using System.Collections.Generic;

namespace ConferenceApp
{
    public class DayGroup : List<Session>
    {
        public string GroupName { get; set; }

        public DayGroup(string name, List<Session> sessions) : base(sessions)
        {
            GroupName = name;
        }
    }
}
