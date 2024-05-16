using Fusion;
using Service.Factory;

namespace Service.SessionService
{
    public interface ISessionContext
    {
        NetworkRunner Runner { get; }
        NetworkEvents Events { get; }
        NetworkFactory Factory { get; }
    }
}
