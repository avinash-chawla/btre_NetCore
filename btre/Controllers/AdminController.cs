using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace btre.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateListing()
        {
            return View();
        }

        public IActionResult CreateRealtor()
        {
            return View();
        }
    }
}
