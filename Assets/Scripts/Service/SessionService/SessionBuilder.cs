using Fusion;
using Service.Factory;
using UnityEngine;
using Zenject;

namespace Service.SessionService
{
    public class SessionBuilder
    {
        private readonly DiContainer _container;
        private readonly DefaultFactory _defaultFactory;
        private readonly GameObject _networkPrefab;

        public SessionBuilder(DiContainer container, DefaultFactory defaultFactory, GameObject networkPrefab)
        {
            _container = container;
            _defaultFactory = defaultFactory;
            _networkPrefab = networkPrefab;
        }

        public Session Create()
        {
            GameObject network = _defaultFactory.Create(_networkPrefab);
            NetworkRunner runner = network.GetComponent<NetworkRunner>();
            NetworkEvents events = network.GetComponent<NetworkEvents>();
            INetworkSceneManager sceneManager = network.GetComponent<INetworkSceneManager>();

            runner.ProvideInput = true;

            return _container.Instantiate<Session>(new object[] {runner, events, sceneManager});
        }
    }
}
