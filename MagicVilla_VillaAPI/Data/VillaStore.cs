using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data
{
    public class VillaStore
    {
        public static List<VillaDTO> VillaDTOs = new List<VillaDTO>
        {
              new VillaDTO{Id = 1, Name = "Pool view",Price = 100000.00},
              new VillaDTO{Id = 2,Name = "Garden view" , Price = 155000.00},
              new VillaDTO{Id = 3,Name = "See view" , Price = 180000.00}

        };
    }
}
