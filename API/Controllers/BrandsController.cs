using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandService service;

        public BrandsController(IBrandService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var brand = await service.GetAsync(id);
            if (brand != null)
            {
                return Ok(brand);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name)
        {
            try
            {
                await service.CreateAsync(name);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // 400 Bad Request Error
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] string name)
        {
            if (await service.GetAsync(id) != null)
            {
                try
                {
                    await service.UpdateAsync(new BrandDto { Id = id, Name = name });
                    return Ok();
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
