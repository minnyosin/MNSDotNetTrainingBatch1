using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using MNSDotNetTrainingBatch1.Shared;
using MNSDotNetTrainingBatch1.WebApi.Models;
using MNSDotNetTrainingBatch1.WebApi.Services;

namespace MNSDotNetTrainingBatch1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController()
        {
            _productService = new ProductService();
        }
        [HttpGet]
        public IActionResult GetProduct()
        {
            var model = _productService.GetProduct();
            return Ok(model);
        }

        [HttpGet("Edit/{Id}")]
        [HttpGet("{Id}")]
        public IActionResult GetProductV2(int Id)
        {
            var model = _productService.GetProductById(Id);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel product)
        {
            string message = product.ToJson();
            Console.WriteLine("Create Product => " + message);
            var model = _productService.CreateProduct(product);
            return Ok(model);
        }

        
        [HttpPut("{Id}")]
        public IActionResult CreateOrUpdateProduct(int Id, [FromBody] ProductModel product)
        {
            var model = _productService.GetProductById(Id);
            if (model.IsSuccess == false)
            {
                var model1 = _productService.CreateProduct(product);
                return Ok(model1);
            }
            var model2 = _productService.UpdateProduct(Id, product);
            return Ok(model2);
        }

        [HttpPatch("{Id}")]
        public IActionResult UpdateProduct(int Id, [FromBody] ProductModel product)
        {
            var model = _productService.UpdateProduct(Id, product);
            return Ok(model);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteProduct(int Id)
        {
            var model = _productService.DeleteProduct(Id);
            return Ok(model);
        }
    }

}
