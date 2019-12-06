using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpingHands.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelpingHands.Controllers
{ 
 
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly IEmailAttachmentSender _emailAttachmentSender;
        private IHostingEnvironment _host;
        public AdminController( IEmailAttachmentSender emailAttachmentSender, IHostingEnvironment _host)
        { 
            _emailAttachmentSender = emailAttachmentSender;
            this._host = _host;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public async Task<ActionResult> DetailsAsync(string email)
        {
            await _emailAttachmentSender.SendEmailAttachmentAsync(
                        email,
                        "Thank you for joining Life Helping Hands",
                        "Hi Member,<br>" +
                        "<br>" +
                        "I first want to thank you for supporting us doing our initial start-up.  Your support means everything to our Team at Life Helping Hands.<br>" +
                        "<br>" +
                        "You should have received your welcome letter.  Please <a href='https://lifehelpinghands.org/Identity/Account/Register'>Register</a> to begin using the services.<br>" +
                        "<br>" +
                        "Click on this link to <a href='https://lifehelpinghands.org//assets/Getting-Enrolled-Tela-Doc.pdf'>download</a> instructions about Getting Enrolled to Tela Doc.<br>" +
                        "<br>" + 
                        "To keep your services up to date, we have made upgrades to the site.  There is a new login to your account and to activate you will need to login and change your password.<br>" +
                        "<br>" +
                        "In the profile under update card, please update your card. In your initial set-up we did not save your card information.<br>" +
                        "<br>" +
                        "As I first customer, we are giving you two free months of service. Your next payment will be March 1st.<br>" +
                        "<br>" +
                        "Again thanks for your support.", false); 
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}