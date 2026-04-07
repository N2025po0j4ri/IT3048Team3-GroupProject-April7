using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceApp
{
    [Table("Session")]
    public class Session
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("topic_name")]
        public string TopicName { get; set; }
        [Column("mobile")]
        public string Speakers { get; set; }
        [Column("email")]
        public string Detail { get; set; }
    }
}
