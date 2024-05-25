using Fusion;

namespace Component.Character
{
    public struct NetworkCharacterParams : INetworkStruct
    {
        public float Speed;
        public float JumpForce;
        public int MaxInAirJumpCount;
        public float RootMotionSpeedMultiplier;
        public float JumpInputSupportMultiplier;
    }
}
