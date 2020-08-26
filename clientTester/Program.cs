using System;
using System.Threading.Tasks;
using Client;

namespace clientTester
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().Wait();
        }
        static async Task MainAsync()
        {
            var authorizationToken = "jJWV5qrjvwTKGlKbmmxCKyBhYmn7E4StfWsGjBPNNHw";
            var homeId = "0e738d0f-7ab3-4e39-b0b8-788b6ad2ba26";
            var c = new Client.Tibber(authorizationToken);
            var result = await c.GetPriceListAsync(homeId);

            Console.ReadLine();
        }
    }
}
