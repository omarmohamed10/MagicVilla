using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.ISerivces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MagicVilla_Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new LoginRequestDTO();
            return View(loginRequestDTO);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDTO requestDTO)
        {
            var Response = await _authService.LoginAsync<APIResponse>(requestDTO);
            if (Response != null && Response.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(Response.Result));

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

                identity.AddClaim(new Claim(ClaimTypes.Name, loginResponseDTO.User.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Role, loginResponseDTO.User.Role));

                var principle = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,principle);

                HttpContext.Session.SetString("JWTToken", loginResponseDTO.Token);
                return RedirectToAction("Index" , "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError" , Response.ErrorMessages.FirstOrDefault());
                return View(requestDTO);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterationRequestDTO requestDTO)
        {
            var response = await _authService.RegisterAsync<APIResponse>(requestDTO);
            if (response != null && response.IsSuccess) 
            {
                RedirectToAction("Login");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWTToken","");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
