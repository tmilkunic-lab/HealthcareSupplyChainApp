namespace HealthcareSupplyChainApp.Models
{
    public class InventoryRowVm
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = string.Empty;
        public int CurrentStock { get; set; }
        public int DailyUsage { get; set; }
        public int LeadTimeDays { get; set; }
        public int SafetyStock { get; set; }

        // Calculated
        public int ReorderPoint { get; set; }
        public bool NeedsRestock { get; set; }
    }
}
