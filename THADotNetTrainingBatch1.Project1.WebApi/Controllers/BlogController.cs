using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using THADotNetTrainingBatch1.Project1.Database.Models;

namespace THADotNetTrainingBatch1.Project1.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public BlogController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
    }
}
