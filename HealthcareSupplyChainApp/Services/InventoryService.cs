using HealthcareSupplyChainApp.Models;

namespace HealthcareSupplyChainApp.Services
{
    public class InventoryService : IInventoryService
    {
        public int CalculateReorderPoint(InventoryItem item)
        {
            // Reorder point = (DailyUsage × LeadTimeDays) + SafetyStock
            return (item.DailyUsage * item.LeadTimeDays) + item.SafetyStock;
        }

        public bool NeedsRestock(InventoryItem item)
        {
            int reorderPoint = CalculateReorderPoint(item);
            return item.CurrentStock <= reorderPoint;
        }
    }
}
