using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        FPTStoreContext context = new FPTStoreContext();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            Member m = context.Members.FirstOrDefault(x => x.Email == email && x.Password == password);
            if(m == null)
            {
                ViewBag.Mess = "Email or password incorrect!";
                return View();
            }
            else
            {
                Models.SessionExtensions.SetObject<Member>(HttpContext.Session, "User", m);
                return RedirectToAction("Index", "Products");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
