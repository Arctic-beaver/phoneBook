using Api.Dtos.OrganizationDtos;
using Api.Dtos.PersonDtos;
using API.Entities;
using AutoMapper;

namespace Api
{
    public static class MapperConfig
    {
        private static Mapper _instance;
        public static Mapper GetInstance()
        {
            if (_instance == null)
                InitMapper();
            return _instance;
        }
        private static void InitMapper()
        {
            _instance = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateOrganizationRequestDto, Organization>();
                cfg.CreateMap<CreatePersonRequestDto, Person>();

                cfg.CreateMap<Organization, OrganizationToFrontDto>();
                cfg.CreateMap<Person, CreatePersonRequestDto>();

                cfg.CreateMap<UpdateOrganizationRequestDto, Organization>()
                    .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name != null))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.Condition(src => src.PhoneNumber != null))
                    .ForMember(dest => dest.Comments, opt => opt.Condition(src => src.Comments != null))
                    .ForMember(dest => dest.OrganizationType, opt => opt.Condition(src => src.OrganizationType != null))
                    .ForMember(dest => dest.Email, opt => opt.Condition(src => src.Email != null));

                cfg.CreateMap<UpdatePersonRequestDto, Person>()
                    .ForMember(dest => dest.Name, opt => opt.Condition(src => src.Name != null))
                    .ForMember(dest => dest.PhoneNumber, opt => opt.Condition(src => src.PhoneNumber != null))
                    .ForMember(dest => dest.Comments, opt => opt.Condition(src => src.Comments != null))
                    .ForMember(dest => dest.BirthDate, opt => opt.Condition(src => src.BirthDate != null))
                    .ForMember(dest => dest.Gender, opt => opt.Condition(src => src.Gender != null));

            }));
        }
    }
}
