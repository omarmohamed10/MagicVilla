using AutoMapper;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;

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
        private readonly IVillaRepository _dbVilla;
        private readonly IMapper _mapper;
        protected APIResponse _response;
        private readonly ILogger<VillaAPIController> _logger;
        public VillaAPIController(IVillaRepository db , IMapper mapper , ILogger<VillaAPIController> logger)
        {  
            _dbVilla = db;
            _mapper = mapper;
            this._response = new APIResponse();
            _logger = logger;
        }

        [HttpGet]
        [Route("GetVillas")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetVillas()
        {
            try
            {
                var villas = await _dbVilla.GetAllAsync();
                _response.IsSuccess = true;
                _response.Result = _mapper.Map<List<VillaDTO>>(villas);
                _response.StatusCode = HttpStatusCode.OK;
                _logger.LogDebug("(Controller) Getting All Villas");
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString()};

            }
            return _response;

          
        }
    // [HttpGet("{id}")]
        [HttpGet]
       [Route("GetVilla/{id:int}" , Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> GetVilla(int id)
        {
            try
            {
                var timer = new Stopwatch();
                timer.Start();
                if (id == 0)
                {
                 //   var ex =  new BadHttpRequestException("Error when getting Villa with id (0)");
                 //   throw ex;
                    
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);

                }

                var villa = await _dbVilla.GetAsync(x => x.Id == id, true);
                timer.Stop();
                if (villa == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                _logger.LogInformation("(Controller) Getting Villa with id {id}", id);
                _logger.LogInformation("(Controller) Querying Get Villa finished in {milliseconds} milliseconds", timer.ElapsedMilliseconds);

                return Ok(_response);
            }
            catch (Exception ex)
            {
              //  throw ex;
                _logger.LogWarning("Error when Getting Villa with id {id}",id);
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPost]
        [Route("CreateVilla")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<APIResponse>> CreateVilla([FromBody] VillaCreateDTO villaDTO)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                if (await _dbVilla.GetAsync(u => u.Name == villaDTO.Name) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Villa is already Exist!");
                    return BadRequest(ModelState);
                }
                if (villaDTO == null) return BadRequest();

                var villa = _mapper.Map<Villa>(villaDTO);
                await _dbVilla.CreateAsync(villa);

                _response.Result = _mapper.Map<VillaDTO>(villa);
                _response.StatusCode = HttpStatusCode.Created;
                _response.IsSuccess = true;

                // await _db.SaveChangesAsync();
                return CreatedAtRoute("GetVilla", new { id = villa.Id }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;

        }
        [HttpDelete]
        [Route("DeleteVilla/{id:int}", Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<APIResponse>> DeleteVilla(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                var villa = await _dbVilla.GetAsync(u => u.Id == id);
                if (villa == null) return NotFound();
                await _dbVilla.RemoveAsync(villa);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                //await _db.SaveChangesAsync();
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPut]
        [Route("UpdateVilla/{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateVilla(int id , [FromBody] VillaUpdateDTO villaDTO)
        {
            try
            {
                if (villaDTO == null || id != villaDTO.Id) return BadRequest();

                var villa = _mapper.Map<Villa>(villaDTO);
                await _dbVilla.UpdateAsync(villa);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
        [HttpPatch]
        [Route("UpdatePartialVilla/{id:int}", Name = "UpdatePartialVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id , JsonPatchDocument<VillaUpdateDTO> PatchVilla)
        {
            if(id == 0 || PatchVilla == null) return BadRequest();
            var villa = await _dbVilla.GetAsync(u => u.Id == id , false);
            if(villa == null) return BadRequest();
      
            var villaDto = _mapper.Map<VillaUpdateDTO>(villa);
            PatchVilla.ApplyTo(villaDto , ModelState);
       
            var model = _mapper.Map<Villa>(villaDto);
            await _dbVilla.UpdateAsync(model);
       
            return NoContent();
        }
    }
}
