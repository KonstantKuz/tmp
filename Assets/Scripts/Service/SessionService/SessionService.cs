using Fusion;
using Service.Factory;
using UnityEngine;
using Zenject;

namespace Service.SessionService
{
    public class SessionService : ISessionService, IInitializable
    {
        private readonly SessionServiceInstaller _installer;
        private readonly DefaultFactory _defaultFactory;

        public SessionService(SessionServiceInstaller installer, DefaultFactory defaultFactory)
        {
            _installer = installer;
            _defaultFactory = defaultFactory;
        }

        public Session Current { get; private set; }

        private void CreatePlayer(NetworkRunner networkRunner, PlayerRef playerRef)
        {
            if (playerRef != Current.Runner.LocalPlayer)
            {
                return;
            }

            Current.Factory.Create(_installer.PlayerPrefab);
        }

        async void ISessionService.Start(StartGameArgs gameArgs)
        {
            if (Current != null)
            {
                Debug.LogError("Session is already running.");
                return;
            }

            GameObject network = _defaultFactory.Create(_installer.NetworkPrefab);
            NetworkRunner runner = network.GetComponent<NetworkRunner>();
            NetworkEvents events = network.GetComponent<NetworkEvents>();
            INetworkSceneManager sceneManager = network.GetComponent<INetworkSceneManager>();

            events.PlayerJoined.AddListener(CreatePlayer);
            runner.ProvideInput = true;

            await runner.StartGame(gameArgs);

            Current = new Session(runner, events, sceneManager);
        }

        void IInitializable.Initialize()
        {
            StartGameArgs gameArgs = new StartGameArgs()
            {
                GameMode = GameMode.Shared,
                SessionName = "TestRoom",
                Scene = SceneRef.FromIndex(0)
            };

            ((ISessionService) this).Start(gameArgs);
        }
    }
}
