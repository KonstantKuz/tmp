using Service.Factory;
using UnityEngine;

namespace Service.SessionService
{
    public class SessionBuilder
    {
        private readonly DefaultFactory _defaultFactory;
        private readonly GameObject _networkPrefab;

        public SessionBuilder(DefaultFactory defaultFactory, GameObject networkPrefab)
        {
            _defaultFactory = defaultFactory;
            _networkPrefab = networkPrefab;
        }

        public ISession Create()
        {
            ISession sessionContext = _defaultFactory.Create(_networkPrefab).GetComponent<ISession>();
            sessionContext.Runner.ProvideInput = true;
            return sessionContext;
        }
    }
}
