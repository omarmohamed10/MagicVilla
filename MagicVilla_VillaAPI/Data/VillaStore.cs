using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> VillaDTOs = new List<VillaDTO>
        {
              new VillaDTO{Id = 1, Name = "Pool view"},
              new VillaDTO{Id = 2,Name = "Garden view"}
        };
    }
}
