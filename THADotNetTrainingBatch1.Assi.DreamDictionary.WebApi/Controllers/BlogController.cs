using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Assi.Domain;

namespace THADotNetTrainingBatch1.Assi.DreamDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly BlogService _blogService;

        public BlogController(BlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet("{letterCode}")]
        public IActionResult GetBlog(int letterCode)
        {
            var model = _blogService.GetBlog(letterCode);
            return Ok(model);
        }
    }
}
