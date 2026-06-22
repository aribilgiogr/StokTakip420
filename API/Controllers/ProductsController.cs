using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService service;

        public ProductsController(IProductService service)
        {
            this.service = service;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAllAsync());
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await service.GetAsync(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound(); // 404 Not Found Error
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewProductDto newProduct)
        {
            try
            {
                await service.AddAsync(newProduct);
                return Ok(newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request Error
            }
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] NewProductDto updatedProduct)
        {
            if (await service.GetAsync(id) != null)
            {
                try
                {
                    await service.UpdateAsync(id, updatedProduct);
                    return Ok(updatedProduct);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (await service.GetAsync(id) != null)
            {
                await service.DeleteAsync(id);
                return NoContent(); // 204 No Content
            }
            else
            {
                return NotFound();
            }
        }
    }
}
