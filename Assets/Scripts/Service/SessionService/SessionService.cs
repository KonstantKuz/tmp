using Fusion;
using UnityEngine;

namespace Service.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly SessionServiceInstaller _installer;
        private readonly SessionBuilder _sessionBuilder;

        public SessionService(SessionServiceInstaller installer, SessionBuilder sessionBuilder)
        {
            _installer = installer;
            _sessionBuilder = sessionBuilder;
        }

        public ISession Current { get; private set; }

        void ISessionService.Start(StartGameArgs gameArgs)
        {
            if (Current != null && Current.Runner.IsRunning)
            {
                Debug.LogWarning("There is a running session. Shutdown.");
                Current.Runner.Shutdown();
            }

            Current = _sessionBuilder.Create();
            Current.Start(gameArgs);
            Current.Events.OnShutdown.AddListener(OnSessionTerminated);
        }

        private void OnSessionTerminated(NetworkRunner runner, ShutdownReason reason)
        {
            Current = null;
        }
    }
}
