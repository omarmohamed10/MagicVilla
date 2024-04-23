using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Models.Dto;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MagicVilla_VillaAPI.Controllers
{
    [Route("api/UsersAuth/")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        protected APIResponse _apiResponse;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _apiResponse = new APIResponse();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model) 
        {
            var loginResponse = await _userRepository.Login(model);
            if (loginResponse.User == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("incorrect userName or passowrd");
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_apiResponse);
            }
            _apiResponse.IsSuccess = true;
            _apiResponse.StatusCode = HttpStatusCode.OK;
            _apiResponse.Result = loginResponse;
            return Ok(_apiResponse);
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterationRequestDTO model)
        {
            bool userNameUnique = _userRepository.IsUniqueUser(model.UserName);
            if (!userNameUnique)
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("User Name already Exists!");
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_apiResponse);
            }
            var user = await _userRepository.Register(model);
            if (user == null) 
            {
                _apiResponse.IsSuccess = false;
                _apiResponse.ErrorMessages.Add("Error while Registeration");
                _apiResponse.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_apiResponse);
            }
          
           _apiResponse.IsSuccess = true;
           _apiResponse.StatusCode = HttpStatusCode.OK;
           return Ok(_apiResponse);
            
        }
    }
}
