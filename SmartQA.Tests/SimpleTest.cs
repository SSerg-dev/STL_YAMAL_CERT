using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SmartQA.Tests
{
    public class SimpleTest : IClassFixture<WebAppFactory<SmartQA.Startup>>
    {
        private readonly WebAppFactory<SmartQA.Startup> _factory;

        public SimpleTest(WebAppFactory<SmartQA.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task Get_EndpointsWork(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }

}
