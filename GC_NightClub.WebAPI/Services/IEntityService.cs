using GC_NightClub.WebAPI.Domain.Interfaces;

namespace GC_NightClub.WebAPI.Services
{
    public interface IEntityService<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        TEntity Get(TKey id);

        IQueryable<TEntity> GetAll();

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

        bool Delete(TKey id);
    }
}
