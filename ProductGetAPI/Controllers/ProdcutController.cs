using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductGetAPI.Models;
using ProductGetAPI.Models.Statics;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductGetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdcutController : ControllerBase
    {
        // GET: api/<ProdcutController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return StaticProductList.Products;
        }

        // GET api/<ProdcutController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            Product product = StaticProductList.Products.FirstOrDefault(x => x.Id == id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
