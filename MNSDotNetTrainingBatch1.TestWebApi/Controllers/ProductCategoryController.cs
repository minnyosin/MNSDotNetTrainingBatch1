using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MNSDotNetTrainingBatch1.TestShared;
using MNSDotNetTrainingBatch1.TestWebApi.Models;
using MNSDotNetTrainingBatch1.TestWebApi.Services;

namespace MNSDotNetTrainingBatch1.TestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public IActionResult GetProductCategory()
        {
            var model = _productCategoryService.GetProductCategory();
            return Ok(model);
        }

        [HttpGet("{code}")]
        public IActionResult GetDetailedProductCategory(string code)
        {
            var model = _productCategoryService.GetDetailedProductCategory(code);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult GetProductCategoryByPageNo(int pageNo, int pageSize)
        {
            var model = _productCategoryService.GetProductCategoryByPageNo(pageNo, pageSize);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateProductCategory([FromBody] ProductCategory productCategory)
        {
            var model = _productCategoryService.CreateProductCategory(productCategory);
            return Ok(model);
        }

        //[HttpPut]
        [HttpPatch("{id}")]
        public IActionResult UpdateProductCategory([FromBody] ProductCategory productCategory, int id)
        {
            var model = _productCategoryService.UpdateProductCategory(productCategory, id);
            return Ok(model);
        }

        [HttpDelete("{code}")]
        public IActionResult DeleteProductCategory(string code)
        {
            var model = _productCategoryService.DeleteProductCategory(code);
            return Ok(model);
        }
    }
}

//Wait 5 min