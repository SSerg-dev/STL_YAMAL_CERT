using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
        [InlineData("test_user_nopassword", "123", false)]        
        [InlineData("bad_user", "bad_password", false)]
        [InlineData("root", "root_pwd_18", true)]
        [InlineData("root", "root_pwd_000", false)]
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
                var responseText = await response.Content.ReadAsStringAsync();
                JObject loginInfo = JObject.Parse(responseText);
                               
                Assert.NotEmpty(loginInfo["Token"].Value<string>());
                Assert.Equal(username, loginInfo["UserInfo"]["UserName"].Value<string>());                
            }
            else
            {
                Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
            }
            
        }


    }
}
