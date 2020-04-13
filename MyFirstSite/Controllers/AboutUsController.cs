using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MyFirstSite.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "";
            return View("Index");
        }
    }
}