using Fusion;

namespace Service.SessionService
{
    public interface ISessionService
    {
        ISession Current { get; }
        void Start(StartGameArgs gameArgs);
    }
}
