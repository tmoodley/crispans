using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HelpingHands.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ThankYouForContactingUs : PageModel
    {
        public void OnGet()
        {
        }
    }
}
