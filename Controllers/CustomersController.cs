using Microsoft.AspNetCore.Mvc;
using Azure;
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


        // LIST ALL CUSTOMERS
        public async Task<IActionResult> Index()
        {
            var table = await _tableService.GetTableClientAsync("Customers");

            var customers = table.Query<CustomerEntity>().ToList();

            return View(customers);
        }


        // VIEW CUSTOMER DETAILS
        public async Task<IActionResult> Details(string partitionKey, string rowKey)
        {
            if (partitionKey == null || rowKey == null)
                return NotFound();

            var table = await _tableService.GetTableClientAsync("Customers");

            var customer = await table.GetEntityAsync<CustomerEntity>(partitionKey, rowKey);

            if (customer == null)
                return NotFound();

            return View(customer.Value);
        }


        // CREATE CUSTOMER (GET)
        [HttpGet]
        public IActionResult Create()
        {
            return View(new CustomerEntity());
        }


        // CREATE CUSTOMER (POST)
        [HttpPost]
        public async Task<IActionResult> Create(CustomerEntity customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            var table = await _tableService.GetTableClientAsync("Customers");
            await table.AddEntityAsync(customer);

            return RedirectToAction(nameof(Index));
        }


        // EDIT CUSTOMER (GET)
        [HttpGet]
        public async Task<IActionResult> Edit(string partitionKey, string rowKey)
        {
            if (partitionKey == null || rowKey == null)
                return NotFound();

            var table = await _tableService.GetTableClientAsync("Customers");
            var result = await table.GetEntityAsync<CustomerEntity>(partitionKey, rowKey);

            if (result == null)
                return NotFound();

            return View(result.Value);
        }


        // EDIT CUSTOMER (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(CustomerEntity customer)
        {
            if (!ModelState.IsValid)
                return View(customer);

            var table = await _tableService.GetTableClientAsync("Customers");
            await table.UpdateEntityAsync(customer, ETag.All, TableUpdateMode.Replace);

            return RedirectToAction(nameof(Index));
        }

    
        // DELETE CUSTOMER (GET CONFIRMATION)
        [HttpGet]
        public async Task<IActionResult> Delete(string partitionKey, string rowKey)
        {
            if (partitionKey == null || rowKey == null)
                return NotFound();

            var table = await _tableService.GetTableClientAsync("Customers");
            var result = await table.GetEntityAsync<CustomerEntity>(partitionKey, rowKey);

            if (result == null)
                return NotFound();

            return View(result.Value);
        }


        // DELETE CUSTOMER (POST)
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string partitionKey, string rowKey)
        {
            var table = await _tableService.GetTableClientAsync("Customers");

            await table.DeleteEntityAsync(partitionKey, rowKey);

            return RedirectToAction(nameof(Index));
        }
    }
}
