using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Lab1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly FPTStoreContext _context = new FPTStoreContext();


        public IActionResult Index()
        {
            var fPTStoreContext = _context.Orders.Include(o => o.Member).ToList();

            return View(fPTStoreContext);
        }


        public IActionResult Details(int? id)
        {
            if (id == null || _context.Orders == null)
            {
                return NotFound();
            }

            var order = _context.Orders
                .Include(o => o.Member)
                .FirstOrDefault(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        private bool OrderExists(int id)
        {
            return (_context.Orders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
