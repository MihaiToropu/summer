﻿namespace SummerCamp.WebAPI.DataAccess
{
    public class Review
    {
        public int ReviewId { get; set; }

        public int? Rating { get; set; }

        public string Comment { get; set; }

        public string Username { get; set; }

        public int AnnouncementId { get; set; }

        public virtual Announcement Announcement { get; set; }
    }
}