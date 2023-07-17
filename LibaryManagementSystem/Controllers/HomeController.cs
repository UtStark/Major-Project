using CollegeWebsite.Models;
using DemoIntro.filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace CollegeWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*
            string cs = "data source=https://remotemysql.com/phpmyadmin/sql.php?db=LUEVgZzMje&table=bookdatabase&pos=0;Database=bookdatabase;User Id=LUEVgZzMje;Password=Kym5G5pVas;integrated security = SSPI";
            SqlConnection con = new SqlConnection(cs);
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from bookdatabase", con);
                con.Open();
                var result = cmd.ExecuteReader();

            }
            catch  { }

            finally { con.Close(); }
            */
            return View();
        }
        [Authorize("Admin")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
