using HealthcareSupplyChainApp.Models;

namespace HealthcareSupplyChainApp.Services
{
    public interface IInventoryService
    {
        int CalculateReorderPoint(InventoryItem item);
        bool NeedsRestock(InventoryItem item);
    }
}
