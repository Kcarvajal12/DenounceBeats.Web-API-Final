using DenounceBeats.Application.Dtos;

namespace DenounceBeats.Application.Dtos.Sector
{
    public class UpdateSectorDto : DtoBase
    {
        public string Name { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public int MunicipalityId { get; set; }
    }
}
