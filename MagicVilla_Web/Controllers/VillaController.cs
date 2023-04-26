using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services;
using MagicVilla_Web.Services.ISerivces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MagicVilla_Web.Controllers
{
    public class VillaController : Controller
    {
        private readonly IVillaService _villaService;
        private readonly IMapper _mapper;
        public VillaController(IVillaService villaService , IMapper mapper)
        {
            _villaService = villaService;
            _mapper = mapper;
        }
        public async Task <IActionResult> CreateVilla()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVilla(VillaCreateDTO villaCreateDTO)
        {
            if(ModelState.IsValid)
            {
              
                var response = await _villaService.CreateAsync<APIResponse>(villaCreateDTO);
                if (response != null & response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            return View(villaCreateDTO);
        }
        public async Task<IActionResult> IndexVilla()
        {
            List<VillaDTO> villaDTOs = new List<VillaDTO>();
            var response = await _villaService.GetAllAsync<APIResponse>();
            if (response != null)
            {
                villaDTOs = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
            }
            return View(villaDTOs);
        }
    }
}
