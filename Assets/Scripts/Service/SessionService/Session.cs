using Fusion;
using Service.Factory;

namespace Service.SessionService
{
    public class Session
    {
        public Session(NetworkRunner runner, NetworkEvents events, INetworkSceneManager sceneManager)
        {
            Runner = runner;
            Events = events;
            SceneManager = sceneManager;
            Factory = new NetworkFactory(runner);
        }

        public NetworkRunner Runner { get; }
        public NetworkEvents Events { get; }
        public INetworkSceneManager SceneManager { get; }
        public NetworkFactory Factory { get; }
    }
}