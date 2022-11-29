using AutoMapper;
using si653ebu201416643.API.Painting.Domain.Models;
using si653ebu201416643.API.Painting.Resources;

namespace si653ebu201416643.API.Painting.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Author, AuthorResource>();
    }
}