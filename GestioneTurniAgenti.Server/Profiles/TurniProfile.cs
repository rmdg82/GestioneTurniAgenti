using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Shared.Dtos.Turno;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Profiles
{
    public class TurniProfile : Profile
    {
        public TurniProfile()
        {
            CreateMap<Turno, TurnoDto>()
                .ForMember(dest => dest.AgenteCognome,
                    opt => opt.MapFrom(src => src.Agente.Cognome))
                .ForMember(dest => dest.AgenteNome,
                    opt => opt.MapFrom(src => src.Agente.Nome))
                .ForMember(dest => dest.AgenteMatricola,
                    opt => opt.MapFrom(src => src.Agente.Matricola))
                .ForMember(dest => dest.EventoNome,
                    opt => opt.MapFrom(src => src.Evento.Nome))
                .ForMember(dest => dest.Data,
                    opt => opt.MapFrom(src => src.Data.Date));

            CreateMap<TurnoForCreationDto, Turno>();
            CreateMap<TurnoForUpdateDto, Turno>();
        }
    }
}