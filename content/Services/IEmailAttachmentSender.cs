using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpingHands.Services
{
    public interface IEmailAttachmentSender
    {
        Task SendEmailAttachmentAsync(string email, string subject, string htmlMessage, bool isSendInfo);
    }
}
