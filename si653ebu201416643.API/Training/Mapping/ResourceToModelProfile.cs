using AutoMapper;
using si653ebu201416643.API.Training.Domain.Models;
using si653ebu201416643.API.Training.Resources;

namespace si653ebu201416643.API.Training.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveProviderResource, Provider>();
    }
}