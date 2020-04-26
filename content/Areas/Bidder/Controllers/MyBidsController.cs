using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using HelpingHands.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vue2Spa.Areas.Bidder.Models;
using Vue2Spa.Areas.Bidder.Models.DTO;
using Vue2Spa.Models.DTO;

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

        public async Task<IActionResult> Details(string id)
        {

            var currentBidderEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var currentBidder = await _context.Bidders.Where(a => a.EmailAddress == currentBidderEmail).FirstOrDefaultAsync();

            Guid currentBidderId = currentBidder.Id;

            var model = await _context.JobBids.Include(a => a.Job).Where(a => a.BidderId == currentBidderId&&a.JobId == id).FirstOrDefaultAsync();

            

            return View(model);
        }

        public async Task<IActionResult> POBidDetails(string id)
        {

            var currentBidderEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var currentBidder = await _context.Bidders.Where(a => a.EmailAddress == currentBidderEmail).FirstOrDefaultAsync();

            Guid currentBidderId = currentBidder.Id;

            var res = await _context.POBids.Include(a => a.PurchaseOrder).Include(a=>a.LineItems).Where(a => a.BidderId == currentBidderId && a.PurchaseOrderId == Guid.Parse(id)).FirstOrDefaultAsync();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<POBid, POBidDto>();
                cfg.CreateMap<POBidLineItem, POBidLineItemDto>();

                
            });
            // only during development, validate your mappings; remove it before release
            //configuration.AssertConfigurationIsValid();
            // use DI (http://docs.automapper.org/en/latest/Dependency-injection.html) or create the mapper yourself
            var mapper = configuration.CreateMapper();

            var model = mapper.Map<POBidDto>(res);

            return View(model);
        }

        public async Task<IActionResult> PageData(IDataTablesRequest request)
    {
        // Nothing important here. Just creates some mock data.

        _context.Database.SetCommandTimeout(300);
       

        var currentBidderEmail = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
            var currentBidder = await _context.Bidders.Where(a => a.EmailAddress == currentBidderEmail).FirstOrDefaultAsync();

        Guid currentBidderId = currentBidder.Id;

        var mybids = _context.JobBids.Include(a=>a.Job).Where(a => a.BidderId == currentBidderId).ToList();
        var myPoBids = _context.POBids.Include(a => a.PurchaseOrder).Where(a => a.BidderId == currentBidderId).ToList();

            var jobBids = mybids.Select(a => new MyBidsDto()
            {
               Id= a.JobId,
                Number = a.Job.Number,
                Name = a.Job.Name,
                BidStatus = a.Status,
                JobStatus = a.Job.Status,
                Source = "Tender"
            }).ToList();


            var poBids = myPoBids.Select(a => new MyBidsDto()
            {
                Id=a.PurchaseOrderId.ToString(),
                Number = a.PurchaseOrder.PurchaseOrderNumber,
                Name = a.PurchaseOrder.Notes,
                BidStatus = a.Status,
                JobStatus = a.PurchaseOrder.Status,
                Source = "Purchase Order"
            }).ToList();


            List<MyBidsDto> result = new List<MyBidsDto>();
            result.AddRange(jobBids);
            result.AddRange(poBids);

            var output = result;
        var data = output;

        // Global filtering.
        // Filter is being manually applied due to in-memmory (IEnumerable) data.
        // If you want something rather easier, check IEnumerableExtensions Sample.
        var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
            ? data
           :
           data.Where(_item =>
           _item.Number.ToLower().Contains(request.Search.Value.ToLower())

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
