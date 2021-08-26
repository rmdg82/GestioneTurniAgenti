﻿using GestioneTurniAgenti.Server.Entities;
using GestioneTurniAgenti.Server.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Repositories.Contracts
{
    public interface IEventiRepository : IBaseRepository<Evento>
    {
        Task<bool> CheckDuplicatedEvento(DateTime inizio, DateTime fine, string nome);

        Task<bool> CheckTurniLinkedToEvento(Guid eventoId);
    }
}