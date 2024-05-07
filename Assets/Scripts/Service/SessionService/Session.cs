using Fusion;
using Service.Factory;
using Service.InputService;
using UnityEngine;

namespace Service.SessionService
{
    public class Session
    {
        private readonly IInputService _inputService;

        public Session(NetworkRunner runner, NetworkEvents events, IInputService inputService)
        {
            _inputService = inputService;
            Runner = runner;
            Events = events;
            Factory = new NetworkFactory(runner);
        }

        public NetworkRunner Runner { get; }
        public NetworkEvents Events { get; }
        public NetworkFactory Factory { get; }

        public async void Start(StartGameArgs gameArgs)
        {
            _inputService.ActionsMap.Enable();
            Events.OnInput.AddListener(_inputService.PollInput);
            Events.OnShutdown.AddListener(OnShutDown);
            await Runner.StartGame(gameArgs);
        }

        public void Terminate()
        {
            _inputService.ActionsMap.Disable();
            Events.OnInput.RemoveListener(_inputService.PollInput);
            Events.OnShutdown.RemoveListener(OnShutDown);
            if (!Runner.IsShutdown)
            {
                Runner.Shutdown();
            }
        }

        private void OnShutDown(NetworkRunner runner, ShutdownReason reason)
        {
            Debug.Log($"Terminate session. Reason: {reason.ToString()}");
            Terminate();
        }
    }
}
