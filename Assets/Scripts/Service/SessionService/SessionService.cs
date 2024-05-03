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
            if (playerRef != Current.Runner.LocalPlayer)
            {
                return;
            }

            Current.Factory.Create(networkRunner.LocalPlayer, _installer.PlayerPrefab);
        }

        private void Terminate(NetworkRunner runner, ShutdownReason reason)
        {
            Debug.Log($"Terminate session. Reason: {reason.ToString()}");
            Current.Terminate();
            Current = null;
        }

        void ISessionService.Start(StartGameArgs gameArgs)
        {
            if (Current != null)
            {
                Debug.LogError("Session is already running.");
                return;
            }

            Current = _sessionBuilder.Create();
            Current.Events.PlayerJoined.AddListener(CreatePlayer);
            Current.Events.OnShutdown.AddListener(Terminate);
            Current.Start(gameArgs);
        }
    }
}
