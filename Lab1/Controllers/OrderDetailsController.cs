using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace Lab1.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly FPTStoreContext _context = new FPTStoreContext();

        public async Task<IActionResult> Index(int id)
        {
            var fPTStoreContext = _context.OrderDetails
                .Where(x => x.OrderId == id)
                .Include(o => o.Order).Include(o => o.Product);
            return View( fPTStoreContext.ToList());
        }

        
       
       
    }
}
