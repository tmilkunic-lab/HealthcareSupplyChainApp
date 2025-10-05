using System.Net;                        
using Microsoft.AspNetCore.Mvc.Testing;  
using Xunit;
using FluentAssertions;

namespace HealthcareSupplyChainApp.IntegrationTests
{
    public class InventoryControllerTests : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public InventoryControllerTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Inventory_Index_ReturnsSuccess_And_ContainsKnownItem()
        {
            var response = await _client.GetAsync("/Inventory");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var html = await response.Content.ReadAsStringAsync();
            html.Should().Contain("Sterile Gloves");
        }
    }
}
