using AutoMapper;
using Domain.Models;

namespace Service.DrivenAdapters.DatabaseAdapters.Entities.Mappings;

public class PandaMappingProfile : Profile
{
    public PandaMappingProfile()
    {
        CreateMap<PandaEntity, Panda>()
            .ForMember(dest => dest.LastKnownAddress, opt => opt.Ignore());
    }
}
