using AutoMapper;
using Domain.Models;

namespace Service.DrivingAdapters.RestAdapters.Dtos.Mappings;

public class PandaMappingProfile : Profile
{
    public PandaMappingProfile()
    {
        CreateMap<Panda, PandaDto>();
    }
}
