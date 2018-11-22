using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SmartQA.DB;
using SmartQA.Models.Account;
using Xunit;

namespace SmartQA.Tests
{
  
    public class AuthApiTest: IClassFixture<WebAppFactory<SmartQA.Startup>>
    {
        private readonly WebAppFactory<SmartQA.Startup> _factory;

        public AuthApiTest(WebAppFactory<SmartQA.Startup> factory)
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
