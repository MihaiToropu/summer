using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SummerCamp.Web.Models
{
    public class AnnouncementDetails
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public bool Closed { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public string Email { get; set; }

        public string Phonenumber { get; set; }

        public int CategoryId { get; set; }

        public DateTime ExpirationDate { get; set; }

        public DateTime PostDate { get; set; }

    }
}