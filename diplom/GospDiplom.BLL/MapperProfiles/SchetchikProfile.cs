using AutoMapper;
using GospDiplom.BLL.DTO;
using GospDiplom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.MapperProfiles
{
    class SchetchikProfile:Profile
    {
        public SchetchikProfile()
        {
            CreateMap<Schetchik, SchetchikDTO>().ReverseMap();
        }
    }
}
