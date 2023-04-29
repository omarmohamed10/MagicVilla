using MagicVilla_Web.Models;
using MagicVilla_Web.Services.ISerivces;
using Microsoft.AspNetCore.Http.HttpResults;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

using static MagicVilla_Utility.RequestType;

namespace MagicVilla_Web.Services
{
    public class BaseServices : IBaseService
    {
        public APIResponse responseModel { get ; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseServices(IHttpClientFactory httpClientFactory) 
        {
            this.responseModel = new();
            this.httpClient = httpClientFactory;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                }
                switch (apiRequest.apiType)
                {
                    case ApiType.GET:
                        message.Method = HttpMethod.Get; break;
                    case ApiType.POST:
                        message.Method = HttpMethod.Post; break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put; break;
                    default:
                        message.Method = HttpMethod.Delete; break;

                }
                HttpResponseMessage apiResonse = null;
                apiResonse = await client.SendAsync(message);
                var apiContent = await apiResonse.Content.ReadAsStringAsync();
                try
                {
                    APIResponse APiResponse = JsonConvert.DeserializeObject<APIResponse>(apiContent);
                    if (APiResponse.StatusCode == System.Net.HttpStatusCode.BadRequest || APiResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
                    {
                        APiResponse.StatusCode = System.Net.HttpStatusCode.BadRequest;
                        APiResponse.IsSuccess = false;
                        var res = JsonConvert.SerializeObject(APiResponse);
                        var ResponseObj = JsonConvert.DeserializeObject<T>(res);
                        return ResponseObj;
                    }

                }
                catch (Exception ex)
                {
                    var APiResponse = JsonConvert.DeserializeObject<T>(apiContent);
                    return APiResponse;
                }
                var Response = JsonConvert.DeserializeObject<T>(apiContent);
                return Response;

            }
            catch (Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
               };
                var res = JsonConvert.SerializeObject(dto);
                var Response = JsonConvert.DeserializeObject<T>(res);
                return Response;
             }
            }
         }
    }


