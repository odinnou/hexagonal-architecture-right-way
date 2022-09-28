#nullable disable warnings

namespace Service.DrivingAdapters.RestAdapters.Dtos;

public class PandaDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public string? LastKnownAddress { get; set; }
}
