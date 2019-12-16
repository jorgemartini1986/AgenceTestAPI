using AgenceIntro.Core.Models;
using AgenceIntro.Domain.Services.Consultants.Dto;
using AutoMapper;

namespace AgenceIntro.Domain.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CaoUsuario, ConsultantDto>();
        }
    }
}
