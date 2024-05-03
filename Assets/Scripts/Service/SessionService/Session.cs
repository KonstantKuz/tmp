using Fusion;
using Service.Factory;
using Service.InputService;

namespace Service.SessionService
{
    public class Session
    {
        private readonly IInputService _inputService;

        public Session(NetworkRunner runner, NetworkEvents events, INetworkSceneManager sceneManager, IInputService inputService)
        {
            _inputService = inputService;
            Runner = runner;
            Events = events;
            SceneManager = sceneManager;
            Factory = new NetworkFactory(runner);
        }

        public NetworkRunner Runner { get; }
        public NetworkEvents Events { get; }
        public INetworkSceneManager SceneManager { get; }
        public NetworkFactory Factory { get; }

        public async void Start(StartGameArgs gameArgs)
        {
            _inputService.ActionsMap.Enable();
            Events.OnInput.AddListener(_inputService.PollInput);
            await Runner.StartGame(gameArgs);
        }

        public void Terminate()
        {
            _inputService.ActionsMap.Disable();
            Events.OnInput.RemoveListener(_inputService.PollInput);
        }
    }
}
