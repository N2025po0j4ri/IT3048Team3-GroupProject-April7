using SQLite;
using System;
using System.Collections.Generic;

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

        [Column("speakers")]

        public string Speakers { get; set; }
        [Column("detail")]

        public string Detail { get; set; }

        [Column("image_name")]
        public string ImageName { get; set; }

        [Column("day")]
        public string Day { get; set; }

        [Column("is_favorite")]
        public bool IsFavorite { get; set; }

        public string FavoriteIcon => IsFavorite ? "★" : "☆";
    }
}
