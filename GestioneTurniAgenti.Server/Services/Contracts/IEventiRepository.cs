using GestioneTurniAgenti.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Services.Contracts
{
    public interface IEventiRepository : IBaseRepository<Evento>
    {
    }
}