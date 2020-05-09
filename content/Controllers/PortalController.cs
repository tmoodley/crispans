using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{
    [Authorize(Roles = "Partner, Supplier, Broker, Buyer")]
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
