using AutoMapper;
using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Shared.Dtos.Eventi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Profiles
{
    public class EventiProfile : Profile
    {
        public EventiProfile()
        {
            CreateMap<Evento, EventoDto>();
            CreateMap<EventoForCreationDto, Evento>();
            CreateMap<EventoForUpdateDto, Evento>();
        }
    }
}