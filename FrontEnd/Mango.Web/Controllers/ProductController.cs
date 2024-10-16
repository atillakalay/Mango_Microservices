using Mango.Web.Models;
using Mango.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<IActionResult> ProductIndex()
        {
            _logger.LogInformation("ProductIndex action called.");
            List<ProductDto>? list = new();

            ResponseDto? response = await _productService.GetAllProductsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ProductDto>>(Convert.ToString(response.Result));
                _logger.LogInformation("Successfully retrieved product list.");
            }
            else
            {
                TempData["error"] = response?.Message;
                _logger.LogError("Error retrieving product list: {Message}", response?.Message);
            }

            return View(list);
        }

        public async Task<IActionResult> ProductCreate()
        {
            _logger.LogInformation("ProductCreate GET action called.");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductDto model)
        {
            _logger.LogInformation("ProductCreate POST action called.");
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _productService.CreateProductsAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Product created successfully";
                    _logger.LogInformation("Product created successfully.");
                    return RedirectToAction(nameof(ProductIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                    _logger.LogError("Error creating product: {Message}", response?.Message);
                }
            }
            else
            {
                _logger.LogWarning("ModelState is invalid.");
            }

            return View(model);
        }

        public async Task<IActionResult> ProductDelete(int productId)
        {
            _logger.LogInformation("ProductDelete GET action called for productId: {ProductId}", productId);

            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                _logger.LogInformation("Successfully retrieved product for deletion.");
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
                _logger.LogError("Error retrieving product for deletion: {Message}", response?.Message);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductDto productDto)
        {
            _logger.LogInformation("ProductDelete POST action called for productId: {ProductId}", productDto.ProductId);

            ResponseDto? response = await _productService.DeleteProductsAsync(productDto.ProductId);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product deleted successfully";
                _logger.LogInformation("Product deleted successfully.");
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
                _logger.LogError("Error deleting product: {Message}", response?.Message);
            }

            return View(productDto);
        }

        public async Task<IActionResult> ProductEdit(int productId)
        {
            _logger.LogInformation("ProductEdit GET action called for productId: {ProductId}", productId);

            ResponseDto? response = await _productService.GetProductByIdAsync(productId);

            if (response != null && response.IsSuccess)
            {
                ProductDto? model = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
                _logger.LogInformation("Successfully retrieved product for editing.");
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
                _logger.LogError("Error retrieving product for editing: {Message}", response?.Message);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> ProductEdit(ProductDto productDto)
        {
            _logger.LogInformation("ProductEdit POST action called for productId: {ProductId}", productDto.ProductId);

            ResponseDto? response = await _productService.UpdateProductsAsync(productDto);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Product updated successfully";
                _logger.LogInformation("Product updated successfully.");
                return RedirectToAction(nameof(ProductIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
                _logger.LogError("Error updating product: {Message}", response?.Message);
            }

            return View(productDto);
        }
    }
}
