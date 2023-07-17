using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeWebsite.Models
{
    public class Book
    {   [Key]
        public int Id { get; set; }

        public string BookName  { get; set; }

        public string AuthorName { get; set; }

        public string ISBN { get; set; }

        public int IssuedStudentId { get; set; }

        public string IssueDate { get; set; }

        public string DueDate { get; set; }

        public bool Issued { get; set; }

        //date issue,date due , issued to, status

    }
}
