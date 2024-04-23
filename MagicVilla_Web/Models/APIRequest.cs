using static MagicVilla_Utility.RequestType;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public ApiType apiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string Token { get; set; }
    }
}
