namespace HealthcareSupplyChainApp.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public int DailyUsage { get; set; }   // Average Daily Usage
        public int LeadTimeDays { get; set; } // Days to restock
        public int SafetyStock { get; set; }
    }
}
