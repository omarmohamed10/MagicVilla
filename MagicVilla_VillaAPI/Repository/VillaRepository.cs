using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models;
using MagicVilla_VillaAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_VillaAPI.Repository
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;
        public VillaRepository(ApplicationDbContext db, ILogger<VillaRepository> logger):base(db,logger) 
        {
            _db = db;
            _logger = logger;
        }
        public async Task<Villa> UpdateAsync(Villa entity)
        {

            _db.Villas.Update(entity);
            entity.UpdatedDate = DateTime.Now;
            await _db.SaveChangesAsync();
            return entity;

        }
    }
}
