using Microsoft.AspNetCore.Mvc;
using Shop.DTO;
using Shop.Interfaces;
using Shop.Model;
using Shop.Service;
using Shop.UsersDTO;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> Register(ProductDTO productDTO)
        {
            await _productService.CreateAsync(productDTO);

            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult<Product>> GetProductById(int productID)
        {
            var product = await _productService.GetByIdAsync(productID);

            if (product != null)
            {
                return Ok(product);
            }
            return NotFound(new { Messge = "Такого продукта нету" });
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(string search = "", int paginateSize = 10, int page = 1)
        {
            var products = await _productService.GetAllAsync(search, paginateSize,page);
            if (products != null)
            {
                return Ok(products);
            }
            return NotFound(new { Messge = "Нету продуктов с таким названием или описанием" });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int productId)
        {
            await _productService.DeleteAsync(productId);

            return RedirectToAction("GetProducts");
        }

        [HttpPut]
        public async Task<IActionResult> ChangeProduct(ProductDTO productDTO)
        {
            await _productService.UpdateAsync(productDTO);

            return RedirectToAction("GetProducts");
        }

        [HttpPut("price")]
        public async Task<IActionResult> ChangePriceProduct(ProductDTO productDTO)
        {
            await ((ProductService)_productService).ChangePriceAsync(productDTO);

            return RedirectToAction("GetProducts");
        }
    }
}
