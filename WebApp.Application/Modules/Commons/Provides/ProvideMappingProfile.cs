using AutoMapper;
using WebApp.Application.Modules.Commons.Provides.Commands.CreateProvide;
using WebApp.Application.Modules.Commons.Provides.Commands.UpdateProvide;
using WebApp.Application.Modules.Commons.Provides.Dtos;
using WebApp.Domain;

namespace WebApp.Application.Modules.Commons.Provides
{
    public class ProvideMappingProfile : Profile
    {
        public ProvideMappingProfile()
        {
            CreateMap<CreateProvideCommand, Provide>();
            CreateMap<UpdateProvideCommand, Provide>();

            CreateMap<Provide, ProvideDto>();

        }
    }
}