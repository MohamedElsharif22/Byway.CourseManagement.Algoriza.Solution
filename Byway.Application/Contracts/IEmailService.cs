using Byway.Application.DTOs.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Byway.Application.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(EmailRequest request);
        Task SendBulkEmailAsync(List<EmailRequest> requests);
    }
}
