using CollegeWebsite.Data;
using CollegeWebsite.Models;
using CollegeWebsite.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CollegeWebsite.Controllers
{
    public class StudentController : Controller
    {

        private readonly ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }



        public IActionResult Index()
        {
            var id = User.FindFirst("Id").Value;

            RegistrationVM registrationVM = new RegistrationVM()
            {
                Form = new Form(),
            };

            //var temp = _db.User.Find(id);




           
            var obj = _db.Student.Find(int.Parse(id));
            registrationVM.Form.UserName = obj.UserName;
            registrationVM.Form.FirstName = obj.FirstName;
            registrationVM.Form.LastName = obj.LastName;
            registrationVM.Form.Email = obj.Email;
            registrationVM.Form.Role = obj.Role;
            registrationVM.Form.Password = obj.Password;
            registrationVM.Form.PhoneNo = obj.PhoneNo;
            registrationVM.Form.Id = obj.Id;
            registrationVM.Form.Stream = obj.Stream;
            registrationVM.IssuedBooks = _db.Book.Where(x => x.IssuedStudentId == obj.Id);
            registrationVM.Form.Fine = obj.Fine;

            
            return View(registrationVM);
        }
    }
}
