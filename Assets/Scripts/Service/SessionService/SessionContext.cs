using Fusion;
using Service.Factory;
using Service.InputService;
using UnityEngine;
using Zenject;

namespace Service.SessionService
{
    public class SessionContext : GameObjectContext, ISession
    {
        [field:SerializeField]
        public NetworkRunner Runner { get; private set; }

        [field:SerializeField]
        public NetworkEvents Events { get; private set; }

        public NetworkFactory Factory { get; private set; }

        private IInputService _inputService;

        [Inject]
        private void Construct(IInputService inputService)
        {
            _inputService = inputService;
            Factory = new NetworkFactory(Runner);
        }

        async void ISession.Start(StartGameArgs gameArgs)
        {
            _inputService.ActionsMap.Enable();
            Events.OnInput.AddListener(_inputService.PollInput);
            Events.OnShutdown.AddListener(OnShutDown);
            await Runner.StartGame(gameArgs);
        }

        void ISession.Terminate()
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
            ((ISession) this).Terminate();
        }
    }
}
