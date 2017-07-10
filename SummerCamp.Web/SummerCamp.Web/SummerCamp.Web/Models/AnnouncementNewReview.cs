using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerCamp.Web.Models
{
    public class AnnouncementNewReview
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Comment { get; set; }

        public int Rating { get; set; }
    }
}