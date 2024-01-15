using Portafolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portafolio.Services
{
    public interface IEmailService
    {
        Task Send(Contact contact);
    }

    public class EmailServiceSendGrid : IEmailService
    {
        private readonly IConfiguration configuration;

        public EmailServiceSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Send(Contact contact)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var name = configuration.GetValue<string>("SENDGRID_NAME");

            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, name);
            var subject = $"El cliente {contact.Email} quiere contactarte";
            var to = new EmailAddress(email, name);
            var message = contact.Message;
            var htmlContent = @$"De: {contact.Name} - Email: {contact.Email} - Mensaje: {contact.Message}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, message, htmlContent);
            var response = await client.SendEmailAsync(singleEmail);
        }
    }
}
