using CollegeWebsite.Data;
using CollegeWebsite.Models;
using DemoIntro.filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeWebsite.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize("Admin")]
        public async Task<IActionResult> Index(string sortOrder,string currentFilter,string searchString,int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["AuthSortParm"] = sortOrder == "Authname" ? "Authname_desc" : "Authname";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }



            ViewData["CurrentFilter"] = searchString;

            var students = from s in _db.Book
                            select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.BookName.Contains(searchString)
                                        || s.AuthorName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    students = students.OrderByDescending(s => s.BookName);
                    break;
                case "Authname":
                    students = students.OrderBy(s => s.AuthorName);
                    break;
                case "Authname_desc":
                    students = students.OrderByDescending(s => s.AuthorName);
                    break;
                default:
                    students = students.OrderBy(s => s.BookName);
                    break;
            }
            int pageSize = 4;
            var temp = await PaginatedList<Book>.CreateAsync(students.AsNoTracking(), pageNumber ?? 1, pageSize);
            return View(temp);
            //return View(await students.AsNoTracking().ToListAsync());
            

            

            

        }


        //Get-Upsert
        public IActionResult Upsert(int? id)
        {
            Book book = new Book();

            if (id == null)
            {
                
                return View(book);
                
            }

            var temp = _db.Book.Find(id);

            if (temp == null)
            {
                return NotFound();
            }


            return View(temp);
        }

        //POST-Upsert

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("Admin")]
        public async Task<IActionResult> Upsert(Book book)
        {
            if (ModelState.IsValid)
            {
                
                if (book.Id == 0)
                {
                    //Create
                    book.ISBN = Guid.NewGuid().ToString();
                    _db.Book.Add(book);

                }

                else
                {
                    //Update
                    //how is it tracking two instances
                    if (!book.Issued) 
                    { 
                        book.IssueDate = "";
                        book.IssuedStudentId = 0;
                        book.DueDate = "";


                    }
                    _db.Book.Update(book);

                }

                //why on updating the value need to be assigned again
                _db.SaveChanges();
                var students = from s in _db.Book
                               select s;
                var temp = await PaginatedList<Book>.CreateAsync(students.AsNoTracking(), 1, 4);
                var htmlx = Helper.RenderRazorViewToString(this, "_ViewAll",temp);
                //PaginatedList<Book>.CreateAsync(students.AsNoTracking(), 1, 3)



                return Json(new { isValid = true,html=  htmlx });
                //return RedirectToAction("Index");

            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Upsert", book ) });

            // return View(Book);
        }



        //get delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Book.Find(id);
            //var obj = _db.Category.Find(id);

            //Product product = _db.Product.Find(id);  not efficient approach 
            //Eager Loading 
            ////////////////////////////////here i got a problemmmm
           // Product product = _db.Product.Include(u => u.Category).Include(u => u.ApplicationType).FirstOrDefault(u => u.Id == id);
            //above is eager loading

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //POST-delete
        //????????????????????????????????????????????????????????????????????????????????????
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePostAsync(int? id)
        {

            var obj = _db.Book.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            



            _db.Book.Remove(obj);
            _db.SaveChanges();
            var students = from s in _db.Book
                           select s;
            var temp = await PaginatedList<Book>.CreateAsync(students.AsNoTracking(), 1, 4);
            var htmlx = Helper.RenderRazorViewToString(this, "_ViewAll", temp);
            //PaginatedList<Book>.CreateAsync(students.AsNoTracking(), 1, 3)



            return Json(new { isValid = true, html = htmlx });

            //return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _db.Book.ToList()) });
            //return RedirectToAction("Index");



        }

        public async Task<IActionResult> Return(int? id)
        {
            var temp = _db.Book.Find(id);
            temp.DueDate = "";
            temp.Issued = false;
            temp.IssueDate = "";
            temp.IssuedStudentId = 0;

            _db.Book.Update(temp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //get delete
        public IActionResult Issue(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Book.Find(id);
            

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }


        //POST-delete
        //????????????????????????????????????????????????????????????????????????????????????
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("Admin")]
        public async Task<IActionResult> Issue(Book book)
        {
            if (ModelState.IsValid)
            {


                book.Issued = true;

                    _db.Book.Update(book);

                

                //why on updating the value need to be assigned again
                _db.SaveChanges();
                var students = from s in _db.Book
                               select s;
                var temp = await PaginatedList<Book>.CreateAsync(students.AsNoTracking(), 1, 4);
                var htmlx = Helper.RenderRazorViewToString(this, "_ViewAll", temp);
                //PaginatedList<Book>.CreateAsync(students.AsNoTracking(), 1, 3)



                return Json(new { isValid = true, html = htmlx });
                //return RedirectToAction("Index");

            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Upsert", book) });

            // return View(Book);
        }




    }
}
