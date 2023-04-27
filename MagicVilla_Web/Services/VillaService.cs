using MagicVilla_Utility;
using MagicVilla_Web.Models;
using MagicVilla_Web.Models.Dto;
using MagicVilla_Web.Services.ISerivces;
using Newtonsoft.Json.Linq;

namespace MagicVilla_Web.Services
{
    public class VillaService :BaseServices, IVillaService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string villaUrl;
        public VillaService(IHttpClientFactory ClientFactory, IConfiguration configuration) : base(ClientFactory)
        {
            _clientFactory = ClientFactory;
            villaUrl = configuration.GetValue<string>("ServiceUrls:VillaAPI");
        }

        public Task<T> CreateAsync<T>(VillaCreateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.POST,
                Url = villaUrl + "/api/VillaAPI/" + "CreateVilla",
                Data = dto
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.DELETE,
                Url = villaUrl + "/api/VillaAPI/" + "DeleteVilla/"+id,
               
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.GET,
                Url = villaUrl + "/api/villaAPI/" + "GetVillas",
            
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.GET,
                Url = villaUrl + "/api/villaAPI/" + "GetVilla/" + id,

            });
        }

        public Task<T> UpdateAsync<T>(VillaUpdateDTO dto)
        {
            return SendAsync<T>(new APIRequest()
            {
                apiType = RequestType.ApiType.PUT,
                Url = villaUrl + "/api/VillaAPI/" + "UpdateVilla/" + dto.Id,
                Data = dto
            });
        }
    }
}
