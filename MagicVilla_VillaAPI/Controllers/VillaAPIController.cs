using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/VillaAPI")]
    [ApiController]
    public class VillaAPIController: ControllerBase
    {
        
        [HttpGet]
        [Route("GetVillas")]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            return Ok(VillaStore.VillaDTOs);
        }
        //[HttpGet("id")]
        [HttpGet]
        [Route("GetVilla")]
        public ActionResult<Villa> GetVilla(int id)
        {
            if (id == 0) return BadRequest();
            VillaDTO villa = VillaStore.VillaDTOs.FirstOrDefault(v => v.Id == id);
            if(villa == null) return NotFound(); 
            return Ok(villa);
          
        }
    }
}
