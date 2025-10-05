using HealthcareSupplyChainApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInventoryService, InventoryService>();


if (builder.Environment.IsDevelopment())
{
    builder.Logging
        .ClearProviders()
        .AddConsole()
        .AddJsonConsole();
}

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inventory}/{action=Index}/{id?}");

app.Run();

public partial class Program { }
