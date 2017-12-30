using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            Execute().Wait();

        }
        static async Task Execute()
        {
            var client = new SendGridClient("ADD-SENDGRID-API-KEY-HERE");
            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("michael@michaelcrump.net", "Azure Tips and Tricks"));

            var recipients = new List<EmailAddress>
                {
                    new EmailAddress("test@gmail.com"),
                    new EmailAddress("test@michaelcrump.net"),
                    new EmailAddress("test@michaelcrump.net")
                };
            msg.AddTos(recipients);

            msg.SetSubject("Testing the SendGrid C# Library");

            msg.AddContent(MimeType.Text, "Hello World plain text!");
            msg.AddContent(MimeType.Html, "<p>Hello World!</p>");
            var response = await client.SendEmailAsync(msg);

        }
    }
}
