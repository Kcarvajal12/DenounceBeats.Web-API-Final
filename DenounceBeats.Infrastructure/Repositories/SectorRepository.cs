using Microsoft.EntityFrameworkCore;
using DenounceBeats.Domain.Entities;
using DenounceBeats.Domain.Repository;
using DenounceBeats.Infrastructure.Context;

namespace DenounceBeats.Infrastructure.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly ApplicationDbContext _context;

        public SectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sector>> GetAllAsync()
        {
            return await _context.Sectors.ToListAsync();
        }

        public async Task<Sector?> GetByIdAsync(int id)
        {
            return await _context.Sectors.FindAsync(id);
        }

        public async Task<Sector> CreateAsync(Sector sector)
        {
            sector.Created = DateTime.Now;
            sector.Updated = DateTime.Now;
            sector.IsActive = true;

            _context.Sectors.Add(sector);
            await _context.SaveChangesAsync();

            return sector;
        }

        public async Task<Sector?> UpdateAsync(int id, Sector sector)
        {
            var existingSector = await _context.Sectors.FindAsync(id);

            if (existingSector == null)
                return null;

            existingSector.Name = sector.Name;
            existingSector.PostalCode = sector.PostalCode;
            existingSector.MunicipalityId = sector.MunicipalityId;
            existingSector.Updated = DateTime.Now;

            await _context.SaveChangesAsync();

            return existingSector;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sector = await _context.Sectors.FindAsync(id);

            if (sector == null)
                return false;

            _context.Sectors.Remove(sector);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}