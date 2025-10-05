using HealthcareSupplyChainApp.Models;
using HealthcareSupplyChainApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace HealthcareSupplyChainApp.Controllers
{
    public class InventoryController : Controller
    {
        private readonly IInventoryService _svc;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryService svc, ILogger<InventoryController> logger)
        {
            _svc = svc;
            _logger = logger;
        }

        // GET: /Inventory
        public IActionResult Index()
        {
            // Imagine these come from your MMIS/ERP; fine to hardcode for the assignment.
            var seed = new List<InventoryItem>
            {
                new() { Id = 1, ItemName = "Sterile Gloves", CurrentStock = 120, DailyUsage = 20, LeadTimeDays = 3, SafetyStock = 30 },
                new() { Id = 2, ItemName = "IV Tubing",     CurrentStock = 80,  DailyUsage = 25, LeadTimeDays = 2, SafetyStock = 20 },
                new() { Id = 3, ItemName = "Syringes 10ml",  CurrentStock = 45,  DailyUsage = 15, LeadTimeDays = 2, SafetyStock = 15 }
            };

            var correlationId = Activity.Current?.Id ?? Guid.NewGuid().ToString("N");

            using (_logger.BeginScope(new Dictionary<string, object?>
            {
                ["CorrelationId"] = correlationId,
                ["Feature"] = "InventoryIndex",
                ["Facility"] = "Main OR Warehouse",
                ["User"] = User?.Identity?.Name ?? "anonymous"
            }))
            {
                _logger.LogInformation("Calculating reorder points for {Count} items", seed.Count);

                var rows = new List<InventoryRowVm>();
                foreach (var i in seed)
                {
                    var rop = _svc.CalculateReorderPoint(i);
                    var need = _svc.NeedsRestock(i);

                    _logger.LogInformation("Item {ItemName}: Current={Current}, ROP={ROP}, Restock={Restock}",
                        i.ItemName, i.CurrentStock, rop, need);

                    rows.Add(new InventoryRowVm
                    {
                        Id = i.Id,
                        ItemName = i.ItemName,
                        CurrentStock = i.CurrentStock,
                        DailyUsage = i.DailyUsage,
                        LeadTimeDays = i.LeadTimeDays,
                        SafetyStock = i.SafetyStock,
                        ReorderPoint = rop,
                        NeedsRestock = need
                    });
                }

                return View(rows);
            }
        }
    }
}
