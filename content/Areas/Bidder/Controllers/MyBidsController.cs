using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using HelpingHands.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Vue2Spa.Areas.Bidder.Controllers
{ 
    [Area("Bidder")]
    [Authorize(Roles = "Bidder")]
    public class MyBidsController : Controller
    {

    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MyBidsController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
        public IActionResult Index()
        {

            

            return View();
        }

    public async Task<IActionResult> PageData(IDataTablesRequest request)
    {
        // Nothing important here. Just creates some mock data.

        _context.Database.SetCommandTimeout(300);
       

        var currentBidderEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var currentBidder = await _context.Bidders.Where(a => a.EmailAddress == currentBidderEmail).FirstOrDefaultAsync();

        Guid currentBidderId = currentBidder.Id;

        var mybids = _context.JobBids.Include(a=>a.Job).Where(a => a.BidderId == currentBidderId).ToList();



        var output = mybids;
        var data = output;

        // Global filtering.
        // Filter is being manually applied due to in-memmory (IEnumerable) data.
        // If you want something rather easier, check IEnumerableExtensions Sample.
        var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
            ? data
           :
           data.Where(_item =>
           _item.Job.Number.ToLower().Contains(request.Search.Value.ToLower())

           );

        // Paging filtered data.
        // Paging is rather manual due to in-memmory (IEnumerable) data.
        var dataPage = filteredData.Skip(request.Start).Take(request.Length);

        // Response creation. To create your response you need to reference your request, to avoid
        // request/response tampering and to ensure response will be correctly created.
        var response = DataTablesResponse.Create(request, data.Count(), filteredData.Count(), dataPage);

        // Easier way is to return a new 'DataTablesJsonResult', which will automatically convert your
        // response to a json-compatible content, so DataTables can read it when received.
        return new DataTablesJsonResult(response, true);
    }



}
}
