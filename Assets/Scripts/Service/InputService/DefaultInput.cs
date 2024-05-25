using Fusion;
using UnityEngine;

namespace Service.InputService
{
    public struct DefaultInput : INetworkInput
    {
        public Vector2 MoveDirection;
        public Vector2 LookDirection;
        public NetworkButtons Buttons;
    }
}
