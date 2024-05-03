using Fusion;
using Service.SessionService;
using UnityEngine;
using Zenject;

namespace UI
{
    public class GameStart : MonoBehaviour
    {
        private ISessionService _sessionService;
        private StartGameArgs _defaultArgs = new()
        {
            GameMode = GameMode.Shared,
            SessionName = "TestRoom",
            Scene = SceneRef.FromIndex(0)
        };

        [Inject]
        private void Construct(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        public void Host()
        {
            _defaultArgs.GameMode = GameMode.Host;
            _sessionService.Start(_defaultArgs);
        }

        public void Client()
        {
            _defaultArgs.GameMode = GameMode.Client;
            _sessionService.Start(_defaultArgs);
        }

        public void Shared()
        {
            _defaultArgs.GameMode = GameMode.Shared;
            _sessionService.Start(_defaultArgs);
        }
    }
}
