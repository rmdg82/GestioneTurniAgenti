using GestioneTurniAgenti.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GestioneTurniAgenti.Server.Services
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetByFilter(params Expression<Func<TEntity, bool>>[] filters);

        Task<TEntity> GetById(Guid id);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<bool> Commit();
    }
}