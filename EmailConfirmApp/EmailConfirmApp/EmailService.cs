using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Admin", "login@ya.ru"));

            emailMessage.To.Add(new MailboxAddress("", email));

            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);
                await client.AuthenticateAsync("login@ya,ru", "password");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
    }

