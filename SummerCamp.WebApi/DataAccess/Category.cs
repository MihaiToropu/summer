using System.Collections.Generic;

namespace SummerCamp.WebAPI.DataAccess
{
    public class Category
    {
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Announcement> Announcements { get; set; }

        public Category()
        {
            Announcements = new List<Announcement>();
        }
    }
}