﻿using AutoMapper;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.ISerivces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace MagicVilla_Web.Controllers
{
    public class HomeController : Controller
    {
		private readonly IVillaService _villaService;
		private readonly IMapper _mapper;
		public HomeController(IVillaService villaService, IMapper mapper)
		{
			_villaService = villaService;
			_mapper = mapper;
		}
		public async Task<IActionResult> Index(VillaCreateDTO villaCreateDTO)
		{

			    List<VillaDTO> villaList = new List<VillaDTO>();
				var response = await _villaService.GetAllAsync<APIResponse>(HttpContext.Session.GetString("JWTToken"));
				if (response != null & response.IsSuccess)
				{
					villaList = JsonConvert.DeserializeObject<List<VillaDTO>>(Convert.ToString(response.Result));
				}
			
			return View(villaList);
		}
	}
}