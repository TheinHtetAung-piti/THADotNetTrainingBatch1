using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Project1.Database.Models;
using THADotNetTrainingBatch1.Project1.Domain.Features;

namespace THADotNetTrainingBatch1.Project1.WebApi.Controllers
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

        [HttpGet]
        public IActionResult Get()
        {
          var model = _blogService.GetBlogs();
            return Ok(model);
        }

        [HttpGet("{pageNo}/{pageSize}")]
        public IActionResult Get(int pageNo = 1, int pageSize = 10)
        {
           var model = _blogService.GetBlogs(pageNo, pageSize);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            var model = _blogService.GetBlog(id);
            return Ok(model);
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody]TblBlog blog)
        {
           var model = _blogService.CreateBlog(blog);
            return Ok(model);
        }
    }
}
