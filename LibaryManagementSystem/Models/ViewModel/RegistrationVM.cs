using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace CollegeWebsite.Models.ViewModel
{
    public class RegistrationVM
    {

        public Form Form { get; set; }

        public IEnumerable<SelectListItem> RoleSelectList { get; set; }

        public IEnumerable<Book> IssuedBooks { get; set; }
    }
}
