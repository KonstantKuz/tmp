using Fusion;
using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class NetworkFactory : IFactory<PlayerRef, GameObject, GameObject>
    {
        private NetworkRunner _networkRunner;

        public NetworkFactory(NetworkRunner networkRunner)
        {
            _networkRunner = networkRunner;
        }

        public GameObject Create(PlayerRef playerRef, GameObject prefab)
        {
            return _networkRunner.Spawn(prefab, inputAuthority: playerRef).gameObject;
        }
    }
}
