namespace MotoWash.Services
{
    public interface IEnumFactory<TEnum, KInterface>
    {
        KInterface Resolve(TEnum action);
    }
}