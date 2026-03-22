using DenounceBeats.Domain.Core;

namespace DenounceBeats.Domain.Entities
{
    public class Sector : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public int MunicipalityId { get; set; }
    }
}
