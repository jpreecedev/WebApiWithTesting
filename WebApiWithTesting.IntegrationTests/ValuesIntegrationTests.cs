using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace WebApiWithTesting.IntegrationTests
{
    public class ValuesIntegrationTests : BaseIntegrationTest
    {
        [Theory]
        [InlineData("GET")]
        public async Task TestValuesAsync(string method)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod(method), "/api/values");

            // Act
            var response = await Client.SendAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}