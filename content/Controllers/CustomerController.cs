using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using HelpingHands.Models;
using Square.Connect.Client;
using Square.Connect.Api;
using Square.Connect.Model;
using System.Diagnostics;
using AutoMapper;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace HelpingHands.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly Configuration configuration;
        // Create a field to store the mapper object
        private readonly IMapper _mapper;

        public CustomerController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            this.configuration = new Configuration(new ApiClient("https://connect.squareupsandbox.com"));
            //this.configuration = new Configuration(new ApiClient("https://connect.squareup.com"));
            this.configuration.AccessToken = "EAAAEPifucqbA8vreB6MeiFuDhKfgNou57029RQFvaOawHiX_JZkUtHea7Qseztf"; 
        }
        // GET: Customers/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PartnerId,PrimarySourceMemberId,Username,Gender,Address1,City,State,PostalCode,StartDate,PhoneNumber,CellPhone,WorkPhone,SubscriptionPlan,Id,CreatedAt,UpdatedAt,GivenName,FamilyName,Nickname,CompanyName,EmailAddress,Birthday,ReferenceId,Note")] Models.Customer customer)
        { 
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return RedirectToAction("Index","PurchaseOrders");
            }
            return View(customer);
        }
        
        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.Name);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.EmailAddress == userId); 
             
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Models.Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return LocalRedirect("/Identity/Account/Manage");
            }
            return View(customer);
        }


        // GET: Customers/Cancel/5
        public async Task<IActionResult> Cancel()
        { 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cancel(string id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.Name);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.EmailAddress == userId);

            if (ModelState.IsValid)
            {
                try
                {
                    customer.isActive = false;
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return LocalRedirect("/Identity/Account/Manage");
            }
            return View(customer);
        }

        // GET: Customers/Enable/5
        public async Task<IActionResult> Enable()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enable(string id)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.Name);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.EmailAddress == userId);

            if (ModelState.IsValid)
            {
                try
                {
                    customer.isActive = true;
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return LocalRedirect("/Identity/Account/Manage");
            }
            return View(customer);
        }

        private bool CustomerExists(string id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
