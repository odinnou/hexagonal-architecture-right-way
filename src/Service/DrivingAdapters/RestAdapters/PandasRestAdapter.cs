using AutoMapper;
using Domain.Models;
using Domain.Ports.Driving;
using Microsoft.AspNetCore.Mvc;
using Service.DrivingAdapters.RestAdapters.Dtos;
using System.Net.Mime;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Service.DrivingAdapters.RestAdapters;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Route("api/pandas")]
public class PandasRestAdapter : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IPandaFetcher _pandaFetcher;

    public PandasRestAdapter(IMapper mapper, IPandaFetcher pandaFetcher)
    {
        _mapper = mapper;
        _pandaFetcher = pandaFetcher;
    }

    /// <summary>
    /// Get panda for id
    /// </summary>
    /// <param name="pandaId" example="54322345-5432-2345-5432-543223455432">Panda Id to fetch</param>
    /// <response code="200">OK, Panda fetched</response>
    [HttpGet("{pandaId:guid:required}")]
    [ProducesResponseType(typeof(PandaDto), Status200OK)]
    public async Task<PandaDto> Get(Guid pandaId)
    {
        Panda panda = await _pandaFetcher.Execute(pandaId);

        return _mapper.Map<PandaDto>(panda);
    }
}