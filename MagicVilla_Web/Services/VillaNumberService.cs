using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.ISerivces;
using Newtonsoft.Json.Linq;

namespace MagicVilla_Web.Services
{
    public class VillaNumberService :BaseServices, IVillaNumberService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaNumberService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _clientFactory = ClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaNumberCreateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.POST,
                Url = villaUrl + "/api/VillaNumberAPI/" + "CreateVillaNumber",
                Data = dto,
                Token = token
            });
        }

        public Task<T> DeleteAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.DELETE,
                Url = villaUrl + "/api/VillaNumberAPI/" + "DeleteVillaNumber/" + id,
                Token = token
            });
        }

        public Task<T> GetAllAsync<T>(string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.GET,
                Url = villaUrl + "/api/VillaNumberAPI/" + "GetVillaNumbers",
                Token = token
            });
        }

        public Task<T> GetAsync<T>(int id, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.GET,
                Url = villaUrl + "/api/VillaNumberAPI/" + "GetVillaNumber/" + id,
                Token = token
            });
        }

        public Task<T> UpdateAsync<T>(VillaNumberUpdateDTO dto, string token)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.PUT,
                Url = villaUrl + "/api/VillaNumberAPI/" + "UpdateVillaNumber/" + dto.VillaNo,
                Data = dto,
                Token = token
            });
        }
    }
}
