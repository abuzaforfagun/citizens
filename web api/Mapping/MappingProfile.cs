using AutoMapper;
using web_api.Models.Citizen;
using web_api.Presistance;

namespace web_api.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CitizenPresistance, Citizen>().ReverseMap();
        }
    }
}