using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MNSDotNetTrainingBatch1.Assigned.DreamDictionary.Domain.Features;

namespace MNSDotNetTrainingBatch1.Assigned.DreamDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DreamDictionaryController : ControllerBase
    {
        private readonly BlogService _blogService;

        public DreamDictionaryController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{Id}")]
        public IActionResult GetBlogHeader(int Id)
        {
            var model = _blogService.GetBlogHeader(Id);
            return Ok(model);
        }

        [HttpGet("BlogDetail/{Id}")]
        public IActionResult GetBlogDetail(int Id)
        {
            var model = _blogService.GetBlogDetail(Id);
            return Ok(model);
        }

    }
}
