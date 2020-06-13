using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LiftoffRMAV.Controllers
{
    public class PleaseController : Controller
    {
        // Error Controller for all user errors pertaining to user
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Duplicate()
        {
            return View();
        }

        public IActionResult NotAuthorized()
        {
            return View();
        }
    }
}
