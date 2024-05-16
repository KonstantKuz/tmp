using Fusion;
using UnityEngine;

namespace Service.InputService
{
    public struct DefaultInput : INetworkInput
    {
        public Vector2 Move;
        public NetworkButtons Buttons;
    }
}
