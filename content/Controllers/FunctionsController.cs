using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelpingHands.Models;

namespace HelpingHands.Controllers
{
    public class FunctionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OrderSearch()
        {
            return View();
        }

        public IActionResult OrderManagement()
        {
            return View();
        }

        public IActionResult CreateBids()
        {
            return View();
        }

        public IActionResult QuoteManagement()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
