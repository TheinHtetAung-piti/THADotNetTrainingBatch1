using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace THADotNetTrainingBatch1.WebApi.Controllers
{
    //https://Localhost:3000/api/Product
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok("GetProduct"); 
        }

        [HttpPost]
        public IActionResult PostProduct()
        {
            return Ok("PostProduct");
        }

        [HttpPut]
        public IActionResult PutProduct()
        {
            return Ok("PutProduct");
        }

        [HttpPatch]
        public IActionResult PatchProduct()
        {
            return Ok("PatchProduct");    
        }

        [HttpDelete]
        public IActionResult DeleteProduct()
        {
            return Ok("Delete Product");
        }
    }
}
