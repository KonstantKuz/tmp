using UnityEngine.InputSystem;

namespace Service.InputService
{
    public interface IInputService
    {
        GameInputActions ActionsMap { get; }
    }
}