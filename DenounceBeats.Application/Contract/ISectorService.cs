using DenounceBeats.Application.Core;
using DenounceBeats.Application.Dtos.Sector;
using DenounceBeats.Domain.Entities;

namespace DenounceBeats.Application.Contract
{
    public interface ISectorService : IBaseService
    {
        Task<ServiceResult<IEnumerable<Sector>>> GetAllAsync();
        Task<ServiceResult<Sector>> GetByIdAsync(int id);
        Task<ServiceResult<Sector>> SaveAsync(SaveSectorDto dto);
        Task<ServiceResult<Sector>> UpdateAsync(UpdateSectorDto dto);
        Task<ServiceResult<bool>> DeleteAsync(int id);
    }
}