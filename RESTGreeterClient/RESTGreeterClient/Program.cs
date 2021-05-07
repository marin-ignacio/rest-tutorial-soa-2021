using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RESTGreeterClient
{
    class Program
    {
        private static readonly HttpClient Client = new HttpClient();

        private static string APIUrl = "https://localhost:44305/greeter";

        static async Task Main(string[] args)
        {
            System.Net.ServicePointManager.SecurityProtocol |= SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

            Client.BaseAddress = new Uri(APIUrl);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/string"));

            var watch = new Stopwatch();
            watch.Start();

            var replyTask = Client.GetStringAsync(APIUrl);
            var reply = await replyTask;

            watch.Stop();
            var responseTime = watch.ElapsedMilliseconds;
            Console.WriteLine("Greeting: " + reply);
            Console.WriteLine("The reply lasted: " + responseTime + " ms");
            Console.WriteLine("Press any key to exit...");
        }
    }
}
