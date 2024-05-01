using UnityEngine.InputSystem;
using Zenject;

namespace Service.InputService
{
    public class InputService : IInputService
    {
        public GameInputActions ActionsMap { get; }

        public InputService()
        {
            ActionsMap = new GameInputActions();
        }
    }
}
