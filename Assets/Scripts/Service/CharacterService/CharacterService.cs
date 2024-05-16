using Fusion;
using Service.SessionService;
using Zenject;

namespace Service.CharacterService
{
    public class CharacterService : IInitializable
    {
        private readonly CharacterServiceInstaller _installer;
        private readonly ISessionContext _sessionContext;

        public CharacterService(CharacterServiceInstaller installer, ISessionContext sessionContext)
        {
            _installer = installer;
            _sessionContext = sessionContext;
        }

        private void CreatePlayer(NetworkRunner networkRunner, PlayerRef playerRef)
        {
            _sessionContext.Factory.Create(playerRef, _installer.PlayerPrefab);
        }

        void IInitializable.Initialize()
        {
            _sessionContext.Events.PlayerJoined.AddListener(CreatePlayer);
        }
    }
}
