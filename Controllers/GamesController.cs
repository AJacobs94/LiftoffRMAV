using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffRMAV.Data;
using LiftoffRMAV.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffRMAV.Controllers
{
    public class GamesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RmavUser> _userManager;
        public GamesController(ApplicationDbContext context, UserManager<RmavUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index(string searchString)
        {
            //collects search request based on game genre
            var searches = from s in _context.Games
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                searches = searches.Where(m => m.Genre.Contains(searchString));
            }
            return View(await searches.ToListAsync());
        }
        
        
        }
}
