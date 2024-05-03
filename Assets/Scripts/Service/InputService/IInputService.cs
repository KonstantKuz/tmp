using Fusion;
using UnityEngine.InputSystem;

namespace Service.InputService
{
    public interface IInputService
    {
        GameInputActions ActionsMap { get; }
        void PollInput(NetworkRunner runner, NetworkInput input);
    }
}
