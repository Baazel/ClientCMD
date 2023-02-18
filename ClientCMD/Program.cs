using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Configuration;

namespace ClientCMD
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string IP = ConfigurationManager.AppSettings["IP"];
        private static readonly string PORT = ConfigurationManager.AppSettings["PORT"];
        static async Task Main(string[] args)
        {
            Console.WriteLine(args[0]);
            var values = new Dictionary<string, string>
            {
                { "command", args[0] }
            };

            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(@"http:\\"+IP+":"+ PORT, content);
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseString);
        }
    }
}
