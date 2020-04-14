using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpingHands.Data;
using HelpingHands.Models;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Vue2Spa.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseOrder.Include(p => p.Customers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.Customers).Include(p => p.PurchaseOrderItems)
                .FirstOrDefaultAsync(m => m.Id == id).ConfigureAwait(false);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        [Authorize]
        // GET: PurchaseOrders/Create
        public async Task<IActionResult> Create()
        {
            string userId = this.User.FindFirstValue(ClaimTypes.Name);

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.EmailAddress == userId).ConfigureAwait(false);
            //ViewBag.CustomerId = customer.Id;
            ViewBag.Email = userId;
            return View("Create");
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                purchaseOrder.Id = Guid.NewGuid();
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", purchaseOrder.CustomerId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", purchaseOrder.CustomerId);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,PaymentDate,Notes,PurchaseOrderNumber,CustomerId,Email,Amount")] PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", purchaseOrder.CustomerId);
            return View(purchaseOrder);
        }

        public async Task<IActionResult> Manage(Guid? id)
        {
            return View();
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrder
                .Include(p => p.Customers)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var purchaseOrder = await _context.PurchaseOrder.FindAsync(id);
            _context.PurchaseOrder.Remove(purchaseOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(Guid id)
        {
            return _context.PurchaseOrder.Any(e => e.Id == id);
        }

        public IActionResult PageData(IDataTablesRequest request)
        {
            // Nothing important here. Just creates some mock data.

            _context.Database.SetCommandTimeout(300);
            var orders = _context.PurchaseOrder.Where(x => string.IsNullOrEmpty(x.Status)).Select(a => new PurchaseOrder
            {
                Id = a.Id,
                Notes = a.Notes,
                PurchaseDate = a.PurchaseDate,
                Status = a.Status,
                PurchaseOrderNumber = a.PurchaseOrderNumber,
            }).ToList();



            var output = orders;
            var data = output;

            // Global filtering.
            // Filter is being manually applied due to in-memmory (IEnumerable) data.
            // If you want something rather easier, check IEnumerableExtensions Sample.
            var filteredData = String.IsNullOrWhiteSpace(request.Search.Value)
                ? data
               :
               data.Where(_item =>
               _item.Notes.ToLower().Contains(request.Search.Value.ToLower())

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
