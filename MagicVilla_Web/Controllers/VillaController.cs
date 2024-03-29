﻿using AutoMapper;
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
                    TempData["success"] = "Villa Created Successfully";
                    return RedirectToAction(nameof(IndexVilla));
                }
            }
            TempData["error"] = "Error encountered";
            return View(villaCreateDTO);
        }
		public async Task<IActionResult> UpdateVilla(int villaId)
		{
			if(ModelState.IsValid)
			{

				var response = await _villaService.GetAsync<APIResponse>(villaId);
				if (response != null & response.IsSuccess)
				{
                    VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                    return View(_mapper.Map<VillaUpdateDTO>(model));
				}
			}
			return NotFound();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> UpdateVilla(VillaUpdateDTO villaUpdateDTO)
		{
			if (ModelState.IsValid)
			{

				var response = await _villaService.UpdateAsync<APIResponse>(villaUpdateDTO);
				if (response != null & response.IsSuccess)
				{
                    TempData["success"] = "Villa Updated Successfully";
                    return RedirectToAction(nameof(IndexVilla));
				}
			}
            TempData["error"] = "Error encountered";
            return View(villaUpdateDTO);
		}
        public async Task<IActionResult> DeleteVilla(int villaId)
        {
            if (ModelState.IsValid)
            {

                var response = await _villaService.GetAsync<APIResponse>(villaId);
                if (response != null & response.IsSuccess)
                {
                    VillaDTO model = JsonConvert.DeserializeObject<VillaDTO>(Convert.ToString(response.Result));
                    return View(model);
                }
            }

            return NotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteVilla(VillaDTO villaDTO)
        {
          
                var response = await _villaService.DeleteAsync<APIResponse>(villaDTO.Id);
                if (response != null & response.IsSuccess)
                {
                TempData["success"] = "Villa Deleted Successfully";
                return RedirectToAction(nameof(IndexVilla));
                }
            TempData["error"] = "Error encountered";
            return View(villaDTO);
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
