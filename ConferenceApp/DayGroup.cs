using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ConferenceApp
{
    public class DayGroup : ObservableCollection<Session>
    {
        public string GroupName { get; set; }

        public DayGroup(string name, List<Session> sessions) : base(sessions)
        {
            GroupName = name;
        }
    }
}
