using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace OnlineCinema
{
    internal class SenGridEmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        //private readonly ILogger _logger;
        public SenGridEmailSender(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var apiKey = _configuration["SenGridApiKey"];
            var client = new SendGridClient(apiKey);
            var message = new SendGridMessage()
            {
                From = new EmailAddress("stepan.stetsko666@gmail.com", "Stepan"),
                Subject = subject,
                PlainTextContent = htmlMessage,
                HtmlContent = htmlMessage
            };
            message.AddTo(email);

            var response = await client.SendEmailAsync(message);

/*            if (response.IsSuccessStatusCode)
                _logger.LogInformation("Email Send");
            else
                _logger.LogInformation("error");*/
        }
    }
}
