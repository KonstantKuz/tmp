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

        public Session Current { get; private set; }

        private void CreatePlayer(NetworkRunner networkRunner, PlayerRef playerRef)
        {
            Current.Factory.Create(playerRef, _installer.PlayerPrefab);
        }

        void ISessionService.Start(StartGameArgs gameArgs)
        {
            if (Current != null && Current.Runner.IsRunning)
            {
                Debug.LogWarning("There is a running session. Shutdown.");
                Current.Runner.Shutdown();
            }

            Current = _sessionBuilder.Create();
            Current.Events.PlayerJoined.AddListener(CreatePlayer);
            Current.Start(gameArgs);
        }
    }
}
