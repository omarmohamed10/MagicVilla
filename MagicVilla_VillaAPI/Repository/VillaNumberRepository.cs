using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaNumberRepository : Repository<VillaNumber>, IVillaNumberRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        public VillaNumberRepository(ApplicationDbContext db , ILogger<VillaNumberRepository> logger) : base(db,logger)
        {
            _db = db;
            _logger = logger;

        }

        public async Task<VillaNumber> UpdateAsync(VillaNumber entity)
        {
            _db.VillaNumbers.Update(entity);
            entity.UpdateDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
