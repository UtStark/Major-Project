using CollegeWebsite.Data;
using CollegeWebsite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

public class LoginController : BaseController
{
    ApplicationDbContext db;
    public LoginController(ApplicationDbContext db)
    {
        this.db = db;
    }
    [HttpGet, AllowAnonymous]
    public IActionResult Index([FromQuery(Name = "returnurl")] string returnurl)
    {   
        TempData["returnurl"] = returnurl;
        return View();
    }

    [HttpPost, AllowAnonymous]
    public IActionResult LoginNow(User model, [FromQuery(Name = "returnurl")] String returnurl)
    {
        var admin = db.User.Where(x => x.UserName.Trim() == model.UserName.Trim() && x.Password == model.Password).FirstOrDefault();
        try
        {
            if (admin != null)
            {
                _ = CreateAuthenticationTicket(admin);
                // Show Success Message -"Welcome!"    
                // return RedirectToAction(nameof(ProfileController.CreateEditProfile), "Profile");
                //return RedirectToAction(nameof(HomeController.Privacy));

                if (TempData["returnurl"] != null)
                 {
                      this.Response.Redirect(TempData["returnurl"].ToString());
                     string[] values = TempData["returnurl"].ToString().Split("/");
                     return RedirectToAction(values[2],values[1]);
                 }

               
               
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //  Show Error Message- "Invalid Credentials."    
                return View("Index", model);
            }
        }
        catch (Exception ex)
        {
            //Show Error Message- ex.Message    
            return View("Index", model);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
    }
}