using GC_NightClub.WebAPI.Domain.Interfaces;
using GC_NightClub.WebAPI.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace GC_NightClub.WebAPI.Services
{
    public class EntityService<TEntity, TKey> : IEntityService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        private readonly NightClubDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public EntityService(NightClubDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public TEntity Get(TKey id)
            => _dbSet.Find(id) ?? throw new ItemNotFoundException($"No {nameof(TEntity)} found with ID \"{id}\".");

        public IQueryable<TEntity> GetAll()
            => _dbSet;

        public TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);
            var result = _context.SaveChanges();
            return result >= 0 ? entity : null;
        }

        public TEntity Update(TEntity entity)
        {
            _dbSet.Update(entity);
            var result = _context.SaveChanges();
            return result >= 0 ? entity : null;
        }

        public bool Delete(TKey id)
        {
            var entity = _dbSet.Find(id);

            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            var result = _context.SaveChanges();
            return result >= 0;

        }
    }
}
