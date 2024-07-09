namespace GC_NightClub.WebAPI.Exceptions
{
    public class ItemNotFoundException(string message, Exception inner = null) : Exception(message, inner);
}
