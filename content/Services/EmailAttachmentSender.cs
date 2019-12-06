using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HelpingHands.Services
{
    public class EmailAttachmentSender : IEmailAttachmentSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;
        private IHostingEnvironment _host;

        // Get our parameterized configuration
        public EmailAttachmentSender(string host, int port, bool enableSSL, string userName, string password, IHostingEnvironment _host)
        {
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
            this.userName = userName;
            this.password = password;
            this._host = _host;
        }

        // Use our configuration to send the email by using SmtpClient
        
        public Task SendEmailAttachmentAsync(string email, string subject, string htmlMessage, bool isSendInfo = false)
        {
            var client = new SmtpClient(host, port)
            {
                Credentials = new NetworkCredential(userName, password),
                EnableSsl = enableSSL
            };

            MailMessage mail = new MailMessage(userName, email, subject, htmlMessage)
            {
                IsBodyHtml = true
            };
            if (isSendInfo)
            {
                mail.Attachments.Add(new Attachment(_host.WebRootPath + "/assets/Getting-Enrolled-Tela-Doc.pdf"));
            }

            return client.SendMailAsync(mail); 
        }
    }
}
