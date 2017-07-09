using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerCamp.Web.Models
{
    public class Announcement
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Closed { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
        public string Email { get; set; }

        internal bool DeleteAnnouncement(int id)
        {
            throw new NotImplementedException();
        }

    }
}