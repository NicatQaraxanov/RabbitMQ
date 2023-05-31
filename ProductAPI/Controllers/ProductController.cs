using Microsoft.AspNetCore.Mvc;
using ProductAPI.Models;
using ProductAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMessageBusClient _messageBusClient;

        public ProductController(IMessageBusClient messageBusClient)
        {
            _messageBusClient = messageBusClient;
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _messageBusClient.PublishNewProduct(product);

            return Ok(product);
        }
    }
}
