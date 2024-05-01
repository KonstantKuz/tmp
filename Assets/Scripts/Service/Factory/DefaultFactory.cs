using UnityEngine;
using Zenject;

namespace Service.Factory
{
    public class DefaultFactory : IFactory<GameObject, GameObject>
    {
        private DiContainer _container;

        [Inject]
        public DefaultFactory(DiContainer container)
        {
            _container = container;
        }

        public GameObject Create(GameObject prefab)
        {
            return _container.InstantiatePrefab(prefab);
        }
    }
}
