using Quartz;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace QuartzApp.Services
{
    public class EmailSender : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using (MailMessage message = new MailMessage("admin@yandex.ru", "user@yandex.ru"))
            {
                message.Subject = "Новостная рассылка";
                message.Body = "Новости сайта: бла бла бла";
                using (SmtpClient client = new SmtpClient
                {
                    EnableSsl = true,
                    Host = "smtp.yandex.ru",
                    Port = 25,
                    Credentials = new NetworkCredential("xor8@yandex.ru", "password")
                })
                {
                    await client.SendMailAsync(message);
                }
            }
        }
    }
}
