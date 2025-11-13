using Microsoft.AspNetCore.Mvc;
using Azure.Data.Tables;
using ABC_Retail_CloudApp.Models;
using ABC_Retail_CloudApp.Services;

namespace ABC_Retail_CloudApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AzureTableService _tableService;
        private readonly AzureBlobService _blobService;
        private readonly ILogger<ProductsController> _logger;

        private const string ContainerName = "product-images";

        public ProductsController(
            AzureTableService tableService,
            AzureBlobService blobService,
            ILogger<ProductsController> logger)
        {
            _tableService = tableService;
            _blobService = blobService;
            _logger = logger;
        }

        // 🧩 Display all products
        public async Task<IActionResult> Index(string? searchTerm)
        {
            var tableClient = await _tableService.GetTableClientAsync("Products");
            var products = tableClient.Query<ProductEntity>().ToList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products
                    .Where(p =>
                        (p.ProductName != null && p.ProductName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)) ||
                        (p.Category != null && p.Category.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
                    .ToList();
            }

            ViewBag.SearchTerm = searchTerm;
            return View(products);
        }

        // ✅ GET: Products/Create — shows the Add Product form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // ✅ POST: Products/Create — handles form submission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductUploadModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                // Upload image to Blob Storage (if provided)
                string imageUrl = model.ProductImage != null
                    ? await _blobService.UploadFileAsync(ContainerName, model.ProductImage)
                    : string.Empty;

                // Create a new product entity
                var product = new ProductEntity
                {
                    PartitionKey = "Products",
                    RowKey = Guid.NewGuid().ToString(),
                    ProductName = model.ProductName ?? string.Empty,
                    Category = model.Category ?? string.Empty,
                    Price = (double)model.Price,
                    ImageUrl = imageUrl
                };

                var tableClient = await _tableService.GetTableClientAsync("Products");
                await tableClient.AddEntityAsync(product);

                TempData["Success"] = "Product created successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                TempData["Error"] = "An error occurred while creating the product.";
                return View(model);
            }
        }
    }
}
