using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Service.InputService
{
    public class InputService : IInputService
    {
        public GameInputActions ActionsMap { get; }

        public InputService()
        {
            ActionsMap = new GameInputActions();
        }

        void IInputService.PollInput(NetworkRunner runner, NetworkInput input)
        {
            DefaultInput defaultInput = new DefaultInput();
            defaultInput.Move = ActionsMap.Player.Move.ReadValue<Vector2>();
            defaultInput.Buttons.Set(InputActions.Jump, ActionsMap.Player.Jump.IsPressed());
            defaultInput.Buttons.Set(InputActions.Fire, ActionsMap.Player.Fire.IsPressed());
            input.Set(defaultInput);
        }
    }
}
