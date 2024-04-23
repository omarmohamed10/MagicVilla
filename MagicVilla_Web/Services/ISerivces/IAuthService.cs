using MagicVilla_Web.Models.Dto;

namespace MagicVilla_Web.Services.ISerivces
{
    public interface IAuthService
    {
        Task<T> LoginAsync<T>(LoginRequestDTO loginRequestDTO);
        Task<T>RegisterAsync<T>(RegisterationRequestDTO registerationRequestDTO);
    }
}
