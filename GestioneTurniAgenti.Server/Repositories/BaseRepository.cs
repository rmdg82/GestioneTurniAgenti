using GestioneTurniAgenti.Server.Contexts;
using GestioneTurniAgenti.Server.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GestioneTurniAgenti.Server.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly GestioneTurniDbContext _context;

        public BaseRepository(GestioneTurniDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> Commit()
        {
            var utcNow = DateTime.UtcNow;

            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.Entity is BaseEntity entity)
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedOn = utcNow;
                            entity.UpdatedOn = utcNow;
                            break;

                        case EntityState.Modified:
                            entry.Property("CreatedOn").IsModified = false;
                            entity.UpdatedOn = utcNow;
                            break;
                    }
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetByFilter(params Expression<Func<TEntity, bool>>[] filters)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
    }
}