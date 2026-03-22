using DenounceBeats.Domain.Entities;

namespace DenounceBeats.Domain.Repository
{
    public interface ISectorRepository
    {
        Task<List<Sector>> GetAllAsync();
        Task<Sector?> GetByIdAsync(int id);
        Task<Sector> CreateAsync(Sector sector);
        Task<Sector?> UpdateAsync(int id, Sector sector);
        Task<bool> DeleteAsync(int id);
    }
}