using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.ISerivces;

namespace MagicVilla_Web.Services
{
    public class AuthService : BaseServices,IAuthService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public AuthService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _clientFactory = ClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }
        public Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.POST,
                Url = villaUrl + "/api/UsersAuth/" + "login",
                Data = loginRequestDTO
            });
        }

        public Task<T> RegisterAsync<T>(RegisterationRequestDTO registerationRequestDTO)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.POST,
                Url = villaUrl + "/api/UsersAuth/" + "regiser",
                Data = registerationRequestDTO
            });
        }
    }
}
