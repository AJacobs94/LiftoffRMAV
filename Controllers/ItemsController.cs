using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiftoffRMAV.Data;
using LiftoffRMAV.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using NToastNotify;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffRMAV.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
     
        private readonly ApplicationDbContext _context;
        private readonly UserManager<RmavUser> _userManager;
        private readonly IToastNotification _toastNotification;
        public ItemsController(ApplicationDbContext context,  UserManager<RmavUser> userManager, IToastNotification toastNotification)
        {
            _context = context;
            _userManager = userManager;
            _toastNotification = toastNotification;

        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            //Returns list of items in reference to genre search
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            IList<Items> lists = _context.Items.Include(l => l.Games).Where(x => x.UserId == user.Id).ToList();

            return View(lists);

        }
        public IActionResult Add()
        {
            return View();
        }

       
        
        [HttpPost]
        public async Task<IActionResult> Add(int[] gameIds)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //Authenticates user to make a personal list
            if (ModelState.IsValid)
            {
                    foreach (int gameId in gameIds)
                    {
                    
                        Games theGames = _context.Games.Single(g => g.ID == gameId);
                        Items newList = new Items
                        {
                            GamesID = gameId
                            
                        };
                       newList.UserId = (int.Parse(_userManager.GetUserId(User)));
                        //If there is already a game with the same ID, will redirect to landing page with pop-up error
                        if (_context.Items.Any(c => c.GamesID.Equals(theGames.ID) && c.UserId == user.Id))
                        {
                            _toastNotification.AddErrorToastMessage("You Have Already Added This Game!");
                            return Redirect("/");
                        }
                        //Adds game items to a list
                        else
                       {
                            _context.Items.Add(newList);
                            _context.SaveChanges();
                       }
                    }
              
                
            }
            return Redirect("/Items/Index");

        }

      


       
    }
   


}



