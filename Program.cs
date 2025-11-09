using ABC_Retail_CloudApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register custom Azure services
builder.Services.AddSingleton<AzureTableService>();
builder.Services.AddSingleton<AzureBlobService>();
builder.Services.AddSingleton<AzureQueueService>();
builder.Services.AddSingleton<AzureFileService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route (set to CustomersController)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customers}/{action=Index}/{id?}");

app.Run();
