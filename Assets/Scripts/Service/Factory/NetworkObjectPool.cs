using Fusion;
using Zenject;

namespace Service.Factory
{
    public class NetworkObjectPool : NetworkObjectProviderDefault
    {
        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        protected override NetworkObject InstantiatePrefab(NetworkRunner runner, NetworkObject prefab)
        {
            return _container.InstantiatePrefabForComponent<NetworkObject>(prefab);
        }
    }
}
