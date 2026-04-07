using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceApp
{
    public class DayGroup : List<Topic>
    {
        public string GroupName { get; set; }

        public DayGroup(string name, List<Topic> topics) : base(topics)
        {
            GroupName = name;
        }
    }
}
