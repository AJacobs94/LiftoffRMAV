using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffRMAV.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffRMAV.Controllers
{
    public class GameSearchController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GameSearchController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(string searchString)
        {
            var searches = from s in _context.Search
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                searches = searches.Where(m => m.Title.Contains(searchString));
            }
            return View(await searches.ToListAsync());
        }
    }
}
