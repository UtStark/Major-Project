using System.Collections.Generic;

namespace CollegeWebsite.Models
{
    public class Student : User
    {
        public string Stream { get; set; }

        public int Fine { get; set; }

       // public List<string> BookIds { get; set; }
    }
}
