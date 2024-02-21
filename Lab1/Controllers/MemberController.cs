using Lab1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab1.Controllers
{
    public class MemberController : Controller
    {
        public FPTStoreContext context = new FPTStoreContext();
        public IActionResult Index()
        {
            return View(context.Members.ToList());
        }
    }
}
