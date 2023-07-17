using CollegeWebsite.Data;
using CollegeWebsite.Models;
using CollegeWebsite.Models.ViewModel;
using DemoIntro.filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeWebsite.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RegistrationController(ApplicationDbContext db)
        {
            _db = db;
        }

       [Authorize("Admin")]

        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["UnameSortParm"] = sortOrder == "Uname" ? "uname_desc" : "Uname";

            if (User.HasClaim("Role", "Admin"))

            {
                
                if (sortOrder == null && searchString == null)
                {
                    IEnumerable<User> obj = _db.User;
                    return View(obj);
                }
                

                ViewData["CurrentFilter"] = searchString;

                var students = from s in _db.User
                               select s;
                if (!String.IsNullOrEmpty(searchString))
                {
                    students = students.Where(s => s.LastName.Contains(searchString)
                                           || s.FirstName.Contains(searchString));
                }
                switch (sortOrder)
                {
                    case "name_desc":
                        students = students.OrderByDescending(s => s.FirstName);
                        break;
                    case "Uname":
                        students = students.OrderBy(s => s.UserName);
                        break;
                    case "uname_desc":
                        students = students.OrderByDescending(s => s.UserName);
                        break;
                    default:
                        students = students.OrderBy(s => s.FirstName);
                        break;
                }
                return View(await students.AsNoTracking().ToListAsync());
            }

            else if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");

            }

            else 
            {
                return RedirectToAction("Upsert", "Registration");
            }
            
        }


        //Get-Upsert


        public IActionResult Upsert(int? id)
        {
            RegistrationVM registrationVM = new RegistrationVM() {
                Form = new Form(),
                RoleSelectList = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Role,
                    Value = i.Role.ToString()

                }),
                
            };
            

            /*
            ProductVM productVM = new ProductVM()
            {
                Product = new Product(),
                CategorySelectList = _db.Category.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                ApplicationTypeSelectList = _db.ApplicationType.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };
            */
            
            if (id == null)
            {
                
                return View(registrationVM);
            }



             //registrationVM.User = _db.User.Find(id);
             var temp= _db.User.Find(id);


            if (temp == null)
            {
                return NotFound();
            }

            

            if (temp.Role == "Student")
            {   
                var obj = _db.Student.Find(id);
                registrationVM.Form.UserName = obj.UserName;
                registrationVM.Form.FirstName = obj.FirstName;
                registrationVM.Form.LastName = obj.LastName;
                registrationVM.Form.Email = obj.Email;
                registrationVM.Form.Role = obj.Role;
                registrationVM.Form.Password = obj.Password;
                registrationVM.Form.PhoneNo = obj.PhoneNo;
                registrationVM.Form.Id = obj.Id;
                registrationVM.Form.Stream = obj.Stream;
                registrationVM.IssuedBooks = _db.Book.Where(x=>x.IssuedStudentId == obj.Id);
                registrationVM.Form.Fine = obj.Fine;
            
            }
            else 
            {

                var obj = _db.Employee.Find(id);
                registrationVM.Form.UserName = obj.UserName;
                registrationVM.Form.FirstName = obj.FirstName;
                registrationVM.Form.LastName = obj.LastName;
                registrationVM.Form.Email = obj.Email;
                registrationVM.Form.Role = obj.Role;
                registrationVM.Form.Password = obj.Password;
                registrationVM.Form.PhoneNo = obj.PhoneNo;
                registrationVM.Form.Id = obj.Id;
                registrationVM.Form.Designation = obj.Designation;

            }
            return View(registrationVM);
        }

        //POST-Upsert

        [HttpPost]
        [ValidateAntiForgeryToken]

        
     
        public IActionResult Upsert(RegistrationVM obj)
        {
            if (ModelState.IsValid)
            {
                
                if (obj.Form.Id == 0)
                {
                    //Create

                    if (obj.Form.Role == "Student")
                    {
                        var temp = new Student();
                        temp.UserName = obj.Form.UserName;
                        temp.FirstName = obj.Form.FirstName;
                        temp.LastName = obj.Form.LastName;
                        temp.Email = obj.Form.Email;
                        temp.Role = obj.Form.Role;
                        temp.Password = obj.Form.Password;
                        temp.PhoneNo = obj.Form.PhoneNo;
                        temp.Id = obj.Form.Id;
                        temp.Stream = obj.Form.Stream;
                        temp.Fine = obj.Form.Fine;
                        _db.User.Add(temp);
                    }
                    else 
                    {
                        var temp = new Employee();
                        temp.UserName = obj.Form.UserName;
                        temp.FirstName = obj.Form.FirstName;
                        temp.LastName = obj.Form.LastName;
                        temp.Email = obj.Form.Email;
                        temp.Role = obj.Form.Role;
                        temp.Password = obj.Form.Password;
                        temp.PhoneNo = obj.Form.PhoneNo;
                        temp.Id = obj.Form.Id;
                        temp.Designation = obj.Form.Designation;
                        _db.User.Add(temp);
                    }
                     
                    

                }

                else
                {
                    //Update
                    if (obj.Form.Role == "Student")
                    {
                        var temp = new Student();
                        temp.UserName = obj.Form.UserName;
                        temp.FirstName = obj.Form.FirstName;
                        temp.LastName = obj.Form.LastName;
                        temp.Email = obj.Form.Email;
                        temp.Role = obj.Form.Role;
                        temp.Password = obj.Form.Password;
                        temp.PhoneNo = obj.Form.PhoneNo;
                        temp.Id = obj.Form.Id;
                        temp.Stream = obj.Form.Stream;
                        temp.Fine = obj.Form.Fine;

                        
                        _db.User.Update(temp);
                    }
                    else
                    {
                        var temp = new Employee();
                        temp.UserName = obj.Form.UserName;
                        temp.FirstName = obj.Form.FirstName;
                        temp.LastName = obj.Form.LastName;
                        temp.Email = obj.Form.Email;
                        temp.Role = obj.Form.Role;
                        temp.Password = obj.Form.Password;
                        temp.PhoneNo = obj.Form.PhoneNo;
                        temp.Id = obj.Form.Id;
                        temp.Designation = obj.Form.Designation;
                        
                        _db.User.Update(temp);
                    }
                    //how is it tracking two instances
                    

                }

                //why on updating the value need to be assigned again
                _db.SaveChanges();
                return RedirectToAction("Index");

            }

            

            return View(obj);
        }


        
        [Authorize("Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            var obj = _db.User.Find(id);


            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [Authorize("Admin")]
        
        //POST-delete
        //????????????????????????????????????????????????????????????????????????????????????
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.User.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            


            



            _db.User.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");



        }

        public async Task<IActionResult> Return(int? id, int? studentId)
        {
            
            var temp = _db.Book.Find(id);
            temp.DueDate = "";
            temp.Issued = false;
            temp.IssueDate = "";
            temp.IssuedStudentId = 0;

            _db.Book.Update(temp);
            _db.SaveChanges();
            return RedirectToAction("Upsert", new { id = studentId });
        }


        public async Task<IActionResult> Reissue(int? id, int? studentId)
        {

            var obj = _db.Book.Find(id);
            
            obj.IssueDate = obj.DueDate;

            string dueDate = obj.DueDate;
            var split = dueDate.Split("-");
            var date = Int32.Parse(split[0]);
            var month = Int32.Parse(split[1]);
            var year = Int32.Parse(split[2]);

            DateTime temp = new DateTime(year, month, date);
            var t=temp.AddDays(7);
            obj.DueDate = t.ToString("dd-MM-yyyy");

            _db.Book.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Upsert", new { id = studentId });
        }


    }
}
