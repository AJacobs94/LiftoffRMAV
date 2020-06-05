using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffRMAV.Data;
using LiftoffRMAV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffRMAV.Controllers
{
    public class ListController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ListController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            

            IList<List> lists = _context.List.Include(l => l.Games).ToList();
            return View(lists);

           // return View(await lists.ToListAsync());
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(int[] gameIds)
        {
            if (ModelState.IsValid)
            {
                foreach (int gameId in gameIds)
                {

                    Games theGames = _context.Games.Single(g => g.ID == gameId);
                    List newList = new List
                    {
                        GamesID = gameId
                    };
                    if (_context.List.Any(c => c.ID.Equals(theGames.ID))){
                        return Redirect ("/");
                    }
                    else {
                        _context.List.Add(newList);
                        _context.SaveChanges();
                    }
                }
                
            }
            return Redirect("/List/Index");

        }
        
     }
    

    }
       /* private bool SearchExists(int id)
        {
            return _context.List.Any(e => e.ID == id);
        }*/

    

