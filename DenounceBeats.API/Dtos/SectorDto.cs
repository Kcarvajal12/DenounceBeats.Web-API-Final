namespace DenounceBeats.API.DTOs
{
    public class SectorDto
    {
        public string Name { get; set; } = string.Empty;
        public string? PostalCode { get; set; }
        public int MunicipalityId { get; set; }
    }
}

