#nullable disable warnings

namespace Domain.Models
{
    public class Panda
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string? LastKnownAddress { get; set; }
    }
}
