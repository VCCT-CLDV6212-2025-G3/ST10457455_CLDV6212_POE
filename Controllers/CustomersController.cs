using Microsoft.AspNetCore.Mvc;
using Azure.Data.Tables;
using ABC_Retail_CloudApp.Models;
using ABC_Retail_CloudApp.Services;

namespace ABC_Retail_CloudApp.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AzureTableService _tableService;

        public CustomersController(AzureTableService tableService)
        {
            _tableService = tableService;
        }

        // Display all customers
        public async Task<IActionResult> Index()
        {
            var tableClient = await _tableService.GetTableClientAsync("Customers");
            var customers = tableClient.Query<CustomerEntity>().ToList();
            return View(customers);
        }

        // Create a new customer
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerEntity customer)
        {
            if (ModelState.IsValid)
            {
                var tableClient = await _tableService.GetTableClientAsync("Customers");
                await tableClient.AddEntityAsync(customer);
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
    }
}
