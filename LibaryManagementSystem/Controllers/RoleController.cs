using CollegeWebsite.Data;
using CollegeWebsite.Models;
using DemoIntro.filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeWebsite.Controllers
{
    [Authorize("Admin")]
    
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;

        public RoleController(ApplicationDbContext db)
        {   
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Roles> obj = _db.Roles;
            return View(obj);
        }

        //Get-Upsert
        public IActionResult Upsert(int? id)
        {
            
            Roles obj = new Roles();
            if (id == null)
            {

                return View(obj);
            }

            obj = _db.Roles.Find(id);

            if (obj == null)
            {
                return NotFound();
            }


            return View(obj);
        }

        //POST-Upsert

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Roles obj)
        {
            if (ModelState.IsValid)
            {

                if (obj.Id == 0)
                {
                    //Create

                    _db.Roles.Add(obj);

                }

                else
                {
                    //Update

                    //how is it tracking two instances
                    _db.Roles.Update(obj);

                }

                //why on updating the value need to be assigned again
                _db.SaveChanges();
                return RedirectToAction("Index");

            }



            return View(obj);
        }



        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            var obj = _db.Roles.Find(id);


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
        public IActionResult DeletePost(int? id)
        {

            var obj = _db.Roles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }








            _db.Roles.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");



        }


    }
}
