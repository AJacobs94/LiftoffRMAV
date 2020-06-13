﻿using System;
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
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffRMAV.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<RmavUser> _userManager;
        public ItemsController(ApplicationDbContext context,  UserManager<RmavUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
        public IActionResult Add(int[] gameIds)
        {
            //Authenticates user to make a personal list
            if (ModelState.IsValid)
            {
                if (User.Identity.IsAuthenticated)
                {
                    foreach (int gameId in gameIds)
                    {

                        Games theGames = _context.Games.Single(g => g.ID == gameId);
                        Items newList = new Items
                        {
                            GamesID = gameId
                            
                        };
                       newList.UserId = (int.Parse(_userManager.GetUserId(User)));

                        //If there is already a game with the same ID, will redirect to an error page.
                        if (_context.Items.Any(c => c.GamesID.Equals(theGames.ID)))
                        {
                            
                            return Redirect("/Please/Duplicate");
                        }
                        //Adds game items to a list
                        else
                       {
                            _context.Items.Add(newList);
                            _context.SaveChanges();
                       }
                    }
                }
                else
               {
                   return Redirect("/Please/NotAuthorized");
               }
                
            }
            return Redirect("/Items/Index");

        }
       // private bool SearchExists(int id)
        //{
        //    return _context.Items.Any(e => e.ID == id);
       // }
    }
   


}


