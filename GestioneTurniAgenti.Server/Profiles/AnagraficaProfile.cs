using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Shared.Dtos.Anagrafica;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Profiles
{
    public class AnagraficaProfile : Profile
    {
        public AnagraficaProfile()
        {
            CreateMap<Agente, AgenteDto>()
                .ForMember(dest => dest.NomeReparto,
                    opt => opt.MapFrom(src => src.Reparto.Nome));

            CreateMap<Reparto, RepartoDto>().ReverseMap();
        }
    }
}