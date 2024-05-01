using Fusion;
using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class NetworkFactory : IFactory<GameObject, GameObject>
    {
        private NetworkRunner _networkRunner;

        public NetworkFactory(NetworkRunner networkRunner)
        {
            _networkRunner = networkRunner;
        }

        public GameObject Create(GameObject prefab)
        {
            return _networkRunner.Spawn(prefab).gameObject;
        }
    }
}
