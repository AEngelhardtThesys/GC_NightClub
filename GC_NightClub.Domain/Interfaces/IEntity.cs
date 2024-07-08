namespace GC_NightClub.Domain.Interfaces
{
    public interface IEntity<TKey>
    {
        TKey Id { get; }
    }
}
