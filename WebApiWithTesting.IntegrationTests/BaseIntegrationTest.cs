using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using WebApiWithTesting.API;

namespace WebApiWithTesting.IntegrationTests
{
    public class BaseIntegrationTest
    {
        protected readonly HttpClient Client;

        protected BaseIntegrationTest()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            Client = server.CreateClient();
        }
    }
}