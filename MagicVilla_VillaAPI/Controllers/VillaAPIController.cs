using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Logging;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

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
        private readonly ILogging _logger;
        public VillaAPIController(ILogging logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("GetVillas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            //   _logger.LogInformation("Retrive All Villas");
            _logger.Log("Getting all Villas", "");  
            return Ok(VillaStore.VillaDTOs);
        }
        //[HttpGet("id")]
        [HttpGet]
       [Route("GetVilla" , Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Villa> GetVilla(int id)
        {
            if (id == 0)
            {
                //   _logger.LogError($"Get Villa with id {id}");
                _logger.Log($"Get Villa with id {id}", "error");
                return BadRequest();
            } 
               
            VillaDTO villa = VillaStore.VillaDTOs.FirstOrDefault(v => v.Id == id);
            if (villa == null) return NotFound();
            return Ok(villa);

        }
        [HttpPost]
        [Route("CreateVilla")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDTO)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(VillaStore.VillaDTOs.FirstOrDefault(u => u.Name == villaDTO.Name) != null)
            {
                ModelState.AddModelError("CustomError", "Villa is already Exist!");
                return BadRequest(ModelState);
            }
            if(villaDTO == null) return BadRequest();
            if(villaDTO.Id != 0) return StatusCode(StatusCodes.Status500InternalServerError);
            villaDTO.Id = VillaStore.VillaDTOs.Count() + 1;
            VillaStore.VillaDTOs.Add(villaDTO);
            return CreatedAtRoute("GetVilla" , new { id = villaDTO.Id }, villaDTO);

        }
        [HttpDelete]
        [Route("DeleteVilla" , Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if(id == 0) return BadRequest();
            var villa = VillaStore.VillaDTOs.FirstOrDefault(u => u.Id == id);
            if(villa == null) return NotFound();
            VillaStore.VillaDTOs.Remove(villa);
            return NoContent();
        }
        [HttpPut]
        [Route("UpdateVilla" , Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id , [FromBody] VillaDTO villaDTO)
        {
            if(villaDTO == null || id != villaDTO.Id) return BadRequest();
            var villa = VillaStore.VillaDTOs.FirstOrDefault(u => u.Id == id);
            villa.Name = villaDTO.Name;
            villa.Price = villaDTO.Price;
            return NoContent();
        }
        [HttpPatch]
        [Route("UpdatePartialVilla", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id , JsonPatchDocument<VillaDTO> PatchVilla)
        {
            if(id == 0 || PatchVilla == null) return BadRequest();
            var villa = VillaStore.VillaDTOs.FirstOrDefault(u => u.Id == id);
            if(villa == null) return BadRequest();
            PatchVilla.ApplyTo(villa , ModelState);
            if(!ModelState.IsValid) return BadRequest(ModelState);
            return NoContent();
        }
    }
}
