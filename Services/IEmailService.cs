using FinalProject.Models;

namespace FinalProject.Services
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
}