using Fusion;

namespace Service.SessionService
{
    public interface ISessionService
    {
        Session Current { get; }
        void Start(StartGameArgs gameArgs);
    }
}
