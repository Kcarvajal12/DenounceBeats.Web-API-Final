using DenounceBeats.Application.Contract;
using DenounceBeats.Application.Core;
using DenounceBeats.Application.Dtos.Sector;
using DenounceBeats.Domain.Entities;
using DenounceBeats.Domain.Repository;

namespace DenounceBeats.Application.Services
{
    public class SectorService : BaseService, ISectorService
    {
        private readonly ISectorRepository _sectorRepository;

        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<ServiceResult<IEnumerable<Sector>>> GetAllAsync()
        {
            var result = new ServiceResult<IEnumerable<Sector>>();

            try
            {
                var sectors = await _sectorRepository.GetAllAsync();
                result.Success = true;
                result.Data = sectors;
                result.Message = "Sectors retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error getting sectors: {ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult<Sector>> GetByIdAsync(int id)
        {
            var result = new ServiceResult<Sector>();

            try
            {
                if (id <= 0)
                {
                    result.Success = false;
                    result.Message = "The sector id must be greater than zero.";
                    return result;
                }

                var sector = await _sectorRepository.GetByIdAsync(id);

                if (sector == null)
                {
                    result.Success = false;
                    result.Message = "Sector not found.";
                    return result;
                }

                result.Success = true;
                result.Data = sector;
                result.Message = "Sector retrieved successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error getting sector: {ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult<Sector>> SaveAsync(SaveSectorDto dto)
        {
            var result = new ServiceResult<Sector>();

            try
            {
                if (string.IsNullOrWhiteSpace(dto.Name))
                {
                    result.Success = false;
                    result.Message = "The Name field is required.";
                    return result;
                }

                if (dto.MunicipalityId <= 0)
                {
                    result.Success = false;
                    result.Message = "The MunicipalityId field must be greater than zero.";
                    return result;
                }

                var sector = new Sector
                {
                    Name = dto.Name,
                    PostalCode = dto.PostalCode,
                    MunicipalityId = dto.MunicipalityId
                };

                var createdSector = await _sectorRepository.CreateAsync(sector);

                result.Success = true;
                result.Data = createdSector;
                result.Message = "Sector created successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error saving sector: {ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult<Sector>> UpdateAsync(UpdateSectorDto dto)
        {
            var result = new ServiceResult<Sector>();

            try
            {
                if (dto.Id <= 0)
                {
                    result.Success = false;
                    result.Message = "The Id field must be greater than zero.";
                    return result;
                }

                if (string.IsNullOrWhiteSpace(dto.Name))
                {
                    result.Success = false;
                    result.Message = "The Name field is required.";
                    return result;
                }

                if (dto.MunicipalityId <= 0)
                {
                    result.Success = false;
                    result.Message = "The MunicipalityId field must be greater than zero.";
                    return result;
                }

                var sector = new Sector
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    PostalCode = dto.PostalCode,
                    MunicipalityId = dto.MunicipalityId
                };

                var updatedSector = await _sectorRepository.UpdateAsync(dto.Id, sector);

                if (updatedSector == null)
                {
                    result.Success = false;
                    result.Message = "Sector not found.";
                    return result;
                }

                result.Success = true;
                result.Data = updatedSector;
                result.Message = "Sector updated successfully.";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error updating sector: {ex.Message}";
            }

            return result;
        }

        public async Task<ServiceResult<bool>> DeleteAsync(int id)
        {
            var result = new ServiceResult<bool>();

            try
            {
                if (id <= 0)
                {
                    result.Success = false;
                    result.Message = "The sector id must be greater than zero.";
                    result.Data = false;
                    return result;
                }

                var deleted = await _sectorRepository.DeleteAsync(id);

                if (!deleted)
                {
                    result.Success = false;
                    result.Message = "Sector not found.";
                    result.Data = false;
                    return result;
                }

                result.Success = true;
                result.Message = "Sector deleted successfully.";
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Error deleting sector: {ex.Message}";
                result.Data = false;
            }

            return result;
        }
    }
}