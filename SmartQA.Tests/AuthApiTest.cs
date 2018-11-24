using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SmartQA.Models.Account;
using Xunit;

namespace SmartQA.Tests
{
  
    public class AuthApiTest: IClassFixture<WebAppFactory<Startup>>
    {
        private readonly WebAppFactory<Startup> _factory;

        public AuthApiTest(WebAppFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("test_user", "test_password", true)]
        [InlineData("test_user", "bad_password", false)]
        [InlineData("bad_user", "bad_password", false)]
        public async Task LoginIsWorking(string username, string password, bool shouldSucceed)
        {
            var client = _factory.CreateClient();
            var content = new StringContent(
                JsonConvert.SerializeObject(new LoginViewModel()
                {
                    UserName = username,
                    Password = password

                }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/Account/Login", content);
            if (shouldSucceed)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
            else
            {
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            
        }


    }
}
