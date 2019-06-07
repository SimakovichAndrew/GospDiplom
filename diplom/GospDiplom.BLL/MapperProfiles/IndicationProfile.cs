using AutoMapper;
using GospDiplom.BLL.DTO;
using GospDiplom.DAL.Entities;

namespace GospDiplom.BLL.MapperProfiles
{
    class IndicationProfile:Profile
    {
        public IndicationProfile()
        {
            CreateMap<Indication, IndicationDTO>().ReverseMap();
        }
    }
}
