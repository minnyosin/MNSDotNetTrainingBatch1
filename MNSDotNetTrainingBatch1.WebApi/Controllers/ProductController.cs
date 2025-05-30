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
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var model = _productService.GetProducts();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetProduct(int pageNo = 1, int pageSize = 10)
        {
            var model = _productService.GetProduct(pageNo, pageSize);
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
        public IActionResult GetProductWithPost([FromBody] int id)
        {
            var model = _productService.GetProductById(id);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        //[HttpPost]
        //public IActionResult CreateProduct([FromBody] ProductModel product)
        //{
        //    string message = product.ToJson();
        //    Console.WriteLine("Create Product => " + message);
        //    var model = _productService.CreateProduct(product);
        //    return Ok(model);
        //}

        
        [HttpPut("{Id}")]
        public IActionResult CreateOrUpdateProduct(int Id, [FromBody] ProductModel product)
        {
            var model = _productService.GetProductById(Id);
            if (!model.IsSuccess)
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
