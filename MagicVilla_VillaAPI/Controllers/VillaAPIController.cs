using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController : ControllerBase
    {
        /*
        private readonly ILogger<VillaAPIController> _logger;
        public VillaAPIController(ILogger<VillaAPIController> logger) 
        {
            _logger = logger;
        }
        */
        private readonly ApplicationDbContext _db;
        public VillaAPIController(ApplicationDbContext db)
        {  
            _db = db;
        }

        [HttpGet]
        [Route("GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<VillaDTO>>> GetVillas()
        {
            //   _logger.LogInformation("Retrive All Villas");
            return Ok(await _db.Villas.ToListAsync());
        }
        //[HttpGet("id")]
       [HttpGet]
       [Route("GetVilla" , Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Villa>> GetVilla(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            } 
               
            var villa = await _db.Villas.FirstOrDefaultAsync(x => x.Id == id);
            if (villa == null) return NotFound();
            return Ok(villa);

        }
        [HttpPost]
        [Route("CreateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Villa>> CreateVilla([FromBody] VillaCreateDTO villaDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(await _db.Villas.FirstOrDefaultAsync(u => u.Name == villaDTO.Name) != null)
            {
                ModelState.AddModelError("CustomError", "Villa is already Exist!");
                return BadRequest(ModelState);
            }
            if(villaDTO == null) return BadRequest();
           // if(villaDTO.Id != 0) return StatusCode(StatusCodes.Status500InternalServerError);
        //    villaDTO.Id = _db.Villas.Count() + 1;
            Villa villa = new Villa
            {
               //  Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                ImageUrl = villaDTO.ImageUrl,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Amenity = villaDTO.Amenity,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };
            _db.Villas.AddAsync(villa);
            _db.SaveChangesAsync();
            return CreatedAtRoute("GetVilla" , new { id = villa.Id }, villaDTO);

        }
        [HttpDelete]
        [Route("DeleteVilla" , Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if(id == 0) return BadRequest();
            var villa =await _db.Villas.FirstOrDefaultAsync(u => u.Id == id);
            if(villa == null) return NotFound();
            _db.Villas.Remove(villa);
           await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPut]
        [Route("UpdateVilla" , Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateVilla(int id , [FromBody] VillaUpdateDTO villaDTO)
        {
            if(villaDTO == null || id != villaDTO.Id) return BadRequest();
            //var villa = _db.Villas.FirstOrDefault(u => u.Id == id);
            // villa.Name = villaDTO.Name;
            Villa villa = new Villa
            {
                Id = villaDTO.Id,
                Name = villaDTO.Name,
                Details = villaDTO.Details,
                ImageUrl = villaDTO.ImageUrl,
                Occupancy = villaDTO.Occupancy,
                Rate = villaDTO.Rate,
                Sqft = villaDTO.Sqft,
                Amenity = villaDTO.Amenity,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now

            };
            _db.Villas.Update(villa);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        [HttpPatch]
        [Route("UpdatePartialVilla", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id , JsonPatchDocument<VillaUpdateDTO> PatchVilla)
        {
            if(id == 0 || PatchVilla == null) return BadRequest();
            var villa = await _db.Villas.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            if(villa == null) return BadRequest();
            VillaUpdateDTO villaDto = new VillaUpdateDTO()
            {
                Id = villa.Id,
                Name = villa.Name,
                Details = villa.Details,
                ImageUrl = villa.ImageUrl,
                Occupancy = villa.Occupancy,
                Rate = villa.Rate,
                Sqft = villa.Sqft,
                Amenity = villa.Amenity,
            };

            PatchVilla.ApplyTo(villaDto , ModelState);
            Villa model = new Villa
            {
                Id = villaDto.Id,
                Name = villaDto.Name,
                Details = villaDto.Details,
                ImageUrl = villaDto.ImageUrl,
                Occupancy = villaDto.Occupancy,
                Rate = villaDto.Rate,
                Sqft = villaDto.Sqft,
                Amenity = villaDto.Amenity,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now

            };
            _db.Villas.Update(model);
           await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
