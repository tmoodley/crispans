using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Rewrite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpingHands.rules
{
    public class RedirectToNonWwwRule : IRule
    {
        public virtual void ApplyRule(RewriteContext context)
        {
            var req = context.HttpContext.Request;
            var currentHost = req.Host;
            if (currentHost.Host.StartsWith("www."))
            {
                var newHost = new HostString(currentHost.Host.Substring(4), currentHost.Port ?? 80);
                var newUrl = new StringBuilder().Append("http://").Append(newHost).Append(req.PathBase).Append(req.Path).Append(req.QueryString);
                context.HttpContext.Response.Redirect(newUrl.ToString(), true);
                context.Result = RuleResult.EndResponse;
            }
        }
    }
}
