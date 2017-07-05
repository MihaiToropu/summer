using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerCamp.Web.Models
{
    public class AnnouncementCreate
    {
        public string Phonenumber { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public int CategoryId { get; set; }
    }
}