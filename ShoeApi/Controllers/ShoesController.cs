using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoeApi.Entities;
using ShoeApi.Models;
using ShoeApi.Repositories;
using ShoeApi.Services;

namespace ShoeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        private readonly IShoeService _shoeService;

        public ShoeController(IShoeService shoeService)
        {
            _shoeService = shoeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Shoe>> GetAllShoe()
        {
            try
            {
                var sepatuList = _shoeService.GetAllShoe();
                return Ok(sepatuList);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Shoe> GetShoeById(int id)
        {
            try
            {
                var sepatu = _shoeService.GetShoeById(id);

                if (sepatu == null)
                {
                    return NotFound($"Shoe dengan ID {id} tidak ditemukan");
                }

                return Ok(sepatu);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPost]
        public ActionResult<Shoe> CreateShoe([FromBody] ShoeCreationDTO shoeCreationDTO)
        {
            try
            {
                var newShoe = _shoeService.CreateShoe(shoeCreationDTO);
                return CreatedAtAction(nameof(GetShoeById), new { id = newShoe.Id }, newShoe);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<Shoe> UpdateShoe(int id, [FromBody] ShoeCreationDTO shoeCreationDTO)
        {
            try
            {
                var updatedShoe = _shoeService.UpdateShoe(id, shoeCreationDTO);

                if (updatedShoe == null)
                {
                    return NotFound($"Shoe dengan ID {id} tidak ditemukan");
                }

                return Ok(updatedShoe);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Shoe> DeleteShoe(int id)
        {
            try
            {
                var deletedShoe = _shoeService.DeleteShoe(id);

                if (deletedShoe == null)
                {
                    return NotFound($"Shoe dengan ID {id} tidak ditemukan");
                }

                return Ok(deletedShoe);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }
    }
}
