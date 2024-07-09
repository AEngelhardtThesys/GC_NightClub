namespace GC_NightClub.WebAPI.Domain.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
