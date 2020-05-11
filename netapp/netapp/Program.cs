using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace netapp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var googleHost = Dns.GetHostEntry("www.google.com");

            foreach (var item in googleHost.AddressList)
            {
                Console.WriteLine(item);
            }

           // await SleepAsync();

            var requestModel = new ViberRequestModel { Receiver = "rYMNyLkWUvHOtOum5trmEQ==", Text = "Введите e-mail: ", Type = "text" };

            var requestText = JsonSerializer.Serialize(requestModel);

            string site = @"https://chatapi.viber.com/pa/send_message";
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(site);

            request.Method = "POST";

            request.ContentType = "application/json";

            request.Headers.Add("X-Viber-Auth-Token", "4af953f58627dc18-5816e24ed52fe58a-4af299d75bf21704");

            WebResponse response = await request.GetResponseAsync();

            using (Stream responseStream = response.GetResponseStream())
            {
                using (StreamReader sr = new StreamReader(responseStream))
                {
                    string responseString = sr.ReadToEnd();
                }
            }
            
            Console.ReadKey();
        }

        public static async Task SleepAsync()
        {
            WebClient client = new WebClient();

            await client.DownloadFileTaskAsync(new Uri("http://chelduma.ru/sites/default/files/2d06r13.pdf"), "myfile.pdf");
        }
    }
}
