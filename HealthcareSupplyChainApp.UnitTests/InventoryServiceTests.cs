using FluentAssertions;
using HealthcareSupplyChainApp.Models;
using HealthcareSupplyChainApp.Services;
using Xunit;

namespace HealthcareSupplyChainApp.UnitTests.Services
{
    public class InventoryServiceTests
    {
        private readonly InventoryService _svc = new();

        [Fact]
        public void CalculateReorderPoint_Computes_Correctly()
        {
            var item = new InventoryItem { DailyUsage = 20, LeadTimeDays = 3, SafetyStock = 30 };
            _svc.CalculateReorderPoint(item).Should().Be(90);
        }

        [Fact]
        public void NeedsRestock_IsTrue_When_CurrentStock_BelowROP()
        {
            var item = new InventoryItem { CurrentStock = 60, DailyUsage = 20, LeadTimeDays = 3, SafetyStock = 30 };
            _svc.NeedsRestock(item).Should().BeTrue();
        }
    }
}
