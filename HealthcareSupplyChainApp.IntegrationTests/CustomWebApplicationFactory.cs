using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;   // <-- required for WebApplicationFactory
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthcareSupplyChainApp.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");

            builder.ConfigureServices(services =>
            {
                // swap infrastructure for tests here if needed
            });
        }
    }
}
