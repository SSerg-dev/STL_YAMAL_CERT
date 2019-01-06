using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartQA.DB;
using SmartQA.DB.Models.Auth;

namespace SmartQA.Tests
{

    public class WebAppFactory<TStartup>
        : WebApplicationFactory<SmartQA.Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                builder.UseSolutionRelativeContentRoot(".");

                // Create a new service provider.
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkProxies()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                // Add a database context (ApplicationDbContext) using an in-memory 
                // database for testing.
                services.AddDbContext<DataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);

                });
                //services.AddEntityFrameworkProxies();

                // Build the service provider.
                var sp = services.BuildServiceProvider();

                // Create a scope to obtain a reference to the database
                // context (ApplicationDbContext).
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<DataContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<WebAppFactory<TStartup>>>();

                    // Ensure the database is created.
                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                        Util.DB.InitializeDbForTests(db);
                        var c = db.Set<AppUser>().Count();


                        logger.LogInformation($"Hello there! {c}");
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"An error occurred seeding the " +
                                            "database with test messages. Error: {ex.Message}");
                        throw;
                    }
                }

            });
        }

        protected override IWebHostBuilder CreateWebHostBuilder()
        {
            return base.CreateWebHostBuilder();
        }
    }

}
