using Byway.Application.Contracts;
using Byway.Application.DTOs.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;
        private readonly string _smtpHost;
        private readonly int _smtpPort;
        private readonly string _fromEmail;
        private readonly string _fromName;
        private readonly string _password;
        private readonly bool _enableSsl;

        public EmailService(IConfiguration config, ILogger<EmailService> logger)
        {
            _config = config;
            _logger = logger;

            // Load SMTP settings from configuration
            _smtpHost = _config["EmailSettings:SmtpHost"];
            _smtpPort = int.Parse(_config["EmailSettings:SmtpPort"]);
            _fromEmail = _config["EmailSettings:FromEmail"];
            _fromName = _config["EmailSettings:FromName"];
            _password = _config["EmailSettings:Password"];
            _enableSsl = bool.Parse(_config["EmailSettings:EnableSsl"]);
        }

        public async Task SendEmailAsync(EmailRequest request)
        {
            try
            {
                using var message = new MailMessage();
                message.From = new MailAddress(_fromEmail, _fromName);
                message.To.Add(new MailAddress(request.ToEmail, request.ToName));
                message.Subject = request.Subject;
                message.Body = request.Body;
                message.IsBodyHtml = request.IsHtml;

                if (!string.IsNullOrEmpty(request.CcEmail))
                    message.CC.Add(request.CcEmail);

                if (!string.IsNullOrEmpty(request.BccEmail))
                    message.Bcc.Add(request.BccEmail);

                using var smtpClient = CreateSmtpClient();
                await smtpClient.SendMailAsync(message);

                _logger.LogInformation("Email sent successfully to {Email}", request.ToEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email to {Email}", request.ToEmail);
                throw;
            }
        }

        public async Task SendEmailWithAttachmentAsync(EmailRequest request, List<EmailAttachment> attachments)
        {
            try
            {
                using var message = new MailMessage();
                message.From = new MailAddress(_fromEmail, _fromName);
                message.To.Add(new MailAddress(request.ToEmail, request.ToName));
                message.Subject = request.Subject;
                message.Body = request.Body;
                message.IsBodyHtml = request.IsHtml;

                if (!string.IsNullOrEmpty(request.CcEmail))
                    message.CC.Add(request.CcEmail);

                if (!string.IsNullOrEmpty(request.BccEmail))
                    message.Bcc.Add(request.BccEmail);

                // Add attachments
                foreach (var attachment in attachments)
                {
                    var stream = new MemoryStream(attachment.Content);
                    var mailAttachment = new Attachment(stream, attachment.FileName, attachment.ContentType);
                    message.Attachments.Add(mailAttachment);
                }

                using var smtpClient = CreateSmtpClient();
                await smtpClient.SendMailAsync(message);

                _logger.LogInformation("Email with attachments sent successfully to {Email}", request.ToEmail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email with attachments to {Email}", request.ToEmail);
                throw;
            }
        }

        public async Task SendBulkEmailAsync(List<EmailRequest> requests)
        {
            var tasks = requests.Select(request => SendEmailAsync(request));
            await Task.WhenAll(tasks);
        }

        private SmtpClient CreateSmtpClient()
        {
            return new SmtpClient(_smtpHost, _smtpPort)
            {
                Credentials = new NetworkCredential(_fromEmail, _password),
                EnableSsl = _enableSsl,
                DeliveryMethod = SmtpDeliveryMethod.Network
            };
        }
    }

}
