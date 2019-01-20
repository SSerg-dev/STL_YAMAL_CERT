using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SmartQA.Models.Account;
using Xunit;

namespace SmartQA.Tests
{
  
    public class AuthApiTest: IDisposable
    {
        private readonly WebAppFactory<Startup> _factory;

        public AuthApiTest()
        {
            _factory = new WebAppFactory<Startup>();            
        }

        public void Dispose()
        {
            _factory.Dispose();
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

        private async Task<HttpClient> ClientLogin(HttpClient client, string username, string password)
        {            
            var content = new StringContent(
                JsonConvert.SerializeObject(new LoginViewModel()
                {
                    UserName = username,
                    Password = password

                }), Encoding.UTF8, "application/json");
            
            var response = await client.PostAsync("api/Account/Login", content);
            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            JObject loginInfo = JObject.Parse(await response.Content.ReadAsStringAsync());    
            
            client.DefaultRequestHeaders.Add(
                "Authorization",
                $"Bearer {loginInfo["Token"].Value<string>()}"
            );
            
            return client;
        }
        
        [Theory]
        [InlineData("test_user", "test_password", "test_password", "new_password", true)]        
        [InlineData("test_user", "test_password", "test_password", null, false)]
        [InlineData("test_user", "test_password", "test_password", "1", false)]
        [InlineData("test_user", "test_password", "bad_old_password", "new_password", false)]        
        [InlineData("test_user", "test_password", null, "new_password", false)]        
        public async Task ChangePasswordWorks(
            string username, 
            string password, 
            string oldPassword, 
            string newPassword,
            bool shouldSucceed)
        {           
            var client = await ClientLogin(_factory.CreateClient(), username, password);

            var content = new StringContent(
                JsonConvert.SerializeObject(new ChangePasswordViewModel()
                {
                    OldPassword = oldPassword,
                    NewPassword = newPassword

                }), Encoding.UTF8, "application/json");
               
            var response = await client.PostAsync("api/Account/ChangePassword", content);        
            
            if (shouldSucceed)
            {
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);               
            
                // check that user can login with new password
                await ClientLogin(_factory.CreateClient(), username, newPassword);  
            }
            else
            {
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
            
          
        }


    }
}
