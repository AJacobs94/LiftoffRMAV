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
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            var searches = from s in _context.Games
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                searches = searches.Where(m => m.Genre.Contains(searchString));
            }
            return View(await searches.ToListAsync());
        }
    }
    // GET: /<controller>/
    /* public async Task<IActionResult> Index()
     {
         return View(await _context.Search.ToListAsync());
     }
 }*/
}
