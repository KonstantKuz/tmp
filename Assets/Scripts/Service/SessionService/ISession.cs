using Fusion;

namespace Service.SessionService
{
    public interface ISession : ISessionContext
    {
        void Start(StartGameArgs startGameArgs);
        void Terminate();
    }
}
